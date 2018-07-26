using System;

namespace WMI.NET
{
	public class Credentials
	{
		private readonly string _password;
		private readonly string _userName;

		public Credentials(string userName)
		{
			if (string.IsNullOrWhiteSpace(userName))
			{
				throw new ArgumentNullException("userName");
			}

			_userName = userName;
		}

		public Credentials(string userName, string password)
		{
			if (string.IsNullOrWhiteSpace(userName))
			{
				throw new ArgumentNullException("userName");
			}

			if (string.IsNullOrWhiteSpace("password"))
			{
				throw new ArgumentNullException("password");
			}

			_userName = userName;
			_password = password;
			RequirePassword = true;
		}

		public string Password
		{
			get { return _password; }
		}

		public string UserName
		{
			get { return _userName; }
		}

		public bool RequirePassword { get; private set; }
	}
}