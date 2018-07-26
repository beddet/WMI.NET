using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Management;
using System.Reflection;
using System.Text;
using WMI.NET.Model.Shared;
using WMI.NET.Model.Shared.Attributes;

namespace WMI.NET.QueryProvider
{
	public abstract class WMIQueryProvider : IWMIQueryProvider
	{
		//FIX lav denne metode om så den returnerer ikke-formateret tekst, men derimod kan jeg formatere det senere (kræver deserialiseiring)
		protected string CustomQueryImplementation(string query, ManagementScope scope, int maxResult = -1)
		{
			StringBuilder sb = new StringBuilder();
			int count = 0;
			sb.Append("[");
			ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, new ObjectQuery(query));
			ManagementObjectCollection moc = searcher.Get();

			foreach (ManagementObject item in moc)
			{
				if (maxResult != -1 && count >= maxResult)
				{
					break;
				}

				sb.Append("\n\t{");
				foreach (PropertyData itemProperty in item.Properties)
				{
					sb.Append("\n\t\t\"");
					sb.Append(itemProperty.Name);
					sb.Append("\"");
					sb.Append("\t:\t");
					sb.Append("\"");
					sb.Append(itemProperty.Value);
					sb.Append("\"");
					sb.Append(",");
				}

				sb.Append("\n\t},");
				count++;
			}

			moc.Dispose();
			searcher.Dispose();


			sb.Append("\n]");

			return sb.ToString();
		}

		protected IEnumerable<T> GetObjectsImplementation<T>(ManagementScope scope, int maxResult = -1) where T : IWMIClass
		{
			Type type = typeof(T);
			return GetObjectsImplementation(type, scope, maxResult).Select(x => (T)x);
		}

		public abstract IEnumerable<T> GetObjects<T>(int maxResult = -1) where T : IWMIClass;

		protected IEnumerable<IWMIClass> GetObjectsImplementation(Type type, ManagementScope scope, int maxResult = -1) 
		{
			if (!IsQueryable(type))
			{
				throw new Exception("Cannot query type");
			}

			return GetObjectsImplementation(type, BaseQuery(type), scope, maxResult);
		}

		public abstract IEnumerable<IWMIClass> GetObjects(Type type, int maxResult = -1);

		private string NameOfProperty(Expression expression, ParameterExpression parameter)
		{
			string left = expression.ToString();

			string nameOfParameter = left.Substring(left.IndexOf(parameter.Name) + parameter.Name.Length + 1);

			if (nameOfParameter.EndsWith(")"))
			{
				nameOfParameter = nameOfParameter.Substring(0, nameOfParameter.Length - 6);
			}

			return nameOfParameter;
		}

		public bool IsQueryable(Type type)
		{
			bool queryable = false;
			foreach (var v in type.GetCustomAttributes(true))
			{
				var className = v as WMIClassName;
				if (className != null)
				{
					if (className.IsQueryable)
					{
						queryable = true;
						break;
					}
				}
			}
			return queryable;
		}

		private bool IsQueryable<T>()
		{
			var type = typeof(T);
			return IsQueryable(type);
		}

		public abstract IEnumerable<T> GetObjects<T>(Expression<Func<T, bool>> func, int maxResult = -1) where T : IWMIClass;

		private string GetExpression(ExpressionType nodeType)
		{
			switch (nodeType)
			{
				case ExpressionType.Equal:
					return "=";
				case ExpressionType.LessThan:
					return "<";
				case ExpressionType.LessThanOrEqual:
					return "<=";
				case ExpressionType.GreaterThan:
					return ">";
				case ExpressionType.GreaterThanOrEqual:
					return ">=";
				case ExpressionType.NotEqual:
					return "!=";
			}

			throw new InvalidExpressionException("could not parse type");
		}

		private string BaseQuery(Type type)
		{
			if (type.IsInterface)
			{
				throw new Exception("Cannot instantiate objects from an interface");
			}
			return string.Format("select * from {0}", type.Name);
		}

		private string BaseQuery<T>()
		{
			Type t = typeof(T);
			return BaseQuery(t);
		}

		private string Query<T>(string type, string expression, string value)
		{
			Type queryType = typeof(T);
			return Query(queryType, type, expression, value);
		}

		private string Query(Type queryType, string type, string expression, string value)
		{
			if (queryType.IsInterface)
			{
				throw new Exception("Cannot instantiate objects from an interface");
			}
			return string.Format("select * from {0} where {1} {2} {3}", queryType.Name, type, expression, value);
		}

		private IEnumerable<IWMIClass> GetObjectsImplementation(Type wmiType, string query, ManagementScope scope, int maxResult = -1)
		{
			if (string.IsNullOrEmpty(query))
			{
				throw new ArgumentException("query");
			}

			if (wmiType.IsInterface)
			{
				throw new ArgumentException("Cannot instantiate objects from an interface");
			}

			if (maxResult == 0)
			{
				return Enumerable.Empty<IWMIClass>();
			}

			IList<IWMIClass> items = new List<IWMIClass>();
			int count = 0;

			ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, new ObjectQuery(query));
			ManagementObjectCollection moc = searcher.Get();
			foreach (ManagementObject item in moc)
			{
				if (maxResult != -1 && count >= maxResult)
				{
					break;
				}

				IWMIClass t = (IWMIClass)Activator.CreateInstance(wmiType);
				PropertyInfo[] tProps = t.GetType().GetProperties();
				foreach (PropertyData itemProperty in item.Properties)
				{
					PropertyInfo firstOrDefault = tProps.FirstOrDefault(x => x.Name == itemProperty.Name);
					if (firstOrDefault != null)
					{
						firstOrDefault.SetValue(t, item[itemProperty.Name], null);
					}
				}

				items.Add(t);
				count++;
			}
			moc.Dispose();
			searcher.Dispose();

			return items;
		}

		protected IEnumerable<T> GetObjectsImplementation<T>(string query, ManagementScope scope, int maxResult = -1)
		{
			Type type = typeof(T);

			return GetObjectsImplementation(type, query, scope, maxResult).Select(x => (T)x);
		}

		protected IEnumerable<T> GetObjectsImplementation<T>(Expression<Func<T, bool>> func, ManagementScope scope, int maxResult = -1) where T : IWMIClass
		{
			if (!IsQueryable<T>())
			{
				throw new Exception("Cannot query type");
			}

			ParameterExpression param = func.Parameters[0];
			BinaryExpression operation = func.Body as BinaryExpression;
			Expression left = operation.Left;
			ConstantExpression right = operation.Right as ConstantExpression;

			string nodeType = GetExpression(operation.NodeType);
			string nameOfParameter = NameOfProperty(left, param);

			return GetObjectsImplementation<T>(Query<T>(nameOfParameter, nodeType, right.Value.ToString()), scope);
		}

		public IEnumerable<Type> QueryableClasses()
		{
			IList<Type> result = new List<Type>();

			Type[] types = Assembly.GetAssembly(typeof(LocalWMIQueryProvider)).GetTypes();

			foreach (Type type in types)
			{
				if (IsQueryable(type))
				{
					result.Add(type);
				}
			}

			return result;
		}

		public abstract string CustomQuery(string query, int maxResult = -1);
	}
}