using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Management;
using WMI.NET.Model.Shared;

namespace WMI.NET.QueryProvider
{
	public class RemoteWMIQueryProvider : WMIQueryProvider
	{
		private readonly ManagementScope _managementScope;

		public RemoteWMIQueryProvider(ManagementScope managementScope)
		{
			_managementScope = managementScope;
		}

		public override IEnumerable<T> GetObjects<T>(int maxResult = -1)
		{
			return GetObjectsImplementation<T>(_managementScope, maxResult);
		}

		public override IEnumerable<IWMIClass> GetObjects(Type type, int maxResult = -1)
		{
			return GetObjectsImplementation(type, _managementScope, maxResult);
		}

		public override IEnumerable<T> GetObjects<T>(Expression<Func<T, bool>> func, int maxResult = -1)
		{
			return GetObjectsImplementation<T>(func, _managementScope, maxResult);
		}

		public override string CustomQuery(string query, int maxResult = -1)
		{
			return CustomQueryImplementation(query, _managementScope, maxResult);
		}
	}
}