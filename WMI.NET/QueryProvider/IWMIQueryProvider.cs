using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WMI.NET.Model.Shared;

namespace WMI.NET.QueryProvider
{
	public interface IWMIQueryProvider
	{
		IEnumerable<T> GetObjects<T>(int maxResult = -1) where T : IWMIClass;
		IEnumerable<IWMIClass> GetObjects(Type type, int maxResult = -1);
		bool IsQueryable(Type type);
		IEnumerable<T> GetObjects<T>(Expression<Func<T, bool>> func, int maxResult = -1) where T : IWMIClass;
		IEnumerable<Type> QueryableClasses();
		string CustomQuery(string query, int maxResult = -1);
	}
}