using System.Management;

namespace WMI.NET
{
	public static class ManagementScopeFactory
	{
		/// <summary>
		/// Creates the scope.
		/// </summary>
		/// <param name="credentials">The credentials.</param>
		/// <param name="server">The server, can be in the form of an ip-address or a machine name</param>
		/// <returns></returns>
		public static ManagementScope CreateScope(Credentials credentials, string server)
		{
			ConnectionOptions connectionOptions = new ConnectionOptions
				{
					Username = credentials.UserName,
					EnablePrivileges = true,
					Impersonation = ImpersonationLevel.Impersonate
				};
			
			if(credentials.RequirePassword)
			{
				connectionOptions.Password = credentials.Password;
			}

			var scope = CreateInitialManagementScope(server);
			scope.Options = connectionOptions;

			return new ManagementScope(new ManagementPath(CreateRemotePath(server)), connectionOptions);
		}

		private static ManagementScope CreateInitialManagementScope(string server)
		{
			return new ManagementScope(CreateRemotePath(server));
		}

		/// <summary>
		/// Creates the scope with no connection options, used for remote querying where special credentials are not needed
		/// </summary>
		/// <param name="server">The server.</param>
		/// <returns></returns>
		public static ManagementScope CreateScope(string server)
		{
			return CreateInitialManagementScope(server);
		}

		private static string CreateRemotePath(string server)
		{
			return  @"\\" + server + @"\root\CIMV2";
		}
	}
}