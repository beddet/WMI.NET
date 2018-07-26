using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Management;
using WMI.NET.Model.Shared;

namespace WMI.NET.QueryProvider
{
	public class LocalWMIQueryProvider : WMIQueryProvider
	{
		private static readonly ManagementScope _scope = new ManagementScope();

		public override IEnumerable<T> GetObjects<T>(int maxResult = -1)
		{
			return GetObjectsImplementation<T>(_scope, maxResult);
		}

		public override IEnumerable<IWMIClass> GetObjects(Type type, int maxResult = -1)
		{
			return GetObjectsImplementation(type, _scope, maxResult);
		}

		public override IEnumerable<T> GetObjects<T>(Expression<Func<T, bool>> func, int maxResult = -1)
		{
			return GetObjectsImplementation<T>(func, _scope, maxResult);
		}

		public override string CustomQuery(string query, int maxResult = -1)
		{
			return CustomQueryImplementation(query, _scope, maxResult);
		}
	}
}