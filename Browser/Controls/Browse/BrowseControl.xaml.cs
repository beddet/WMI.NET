using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using Browser.Model;
using WMI.NET;
using WMI.NET.QueryProvider;

namespace Browser.Controls.Browse
{
	/// <summary>
	/// Interaction logic for BrowseControl.xaml
	/// </summary>
	public partial class BrowseControl : BaseControl
	{
		public BrowseControl()
		{
			InitializeComponent();
		}

		private void HandleDoubleClick(object sender, MouseButtonEventArgs e)
		{
			string type = (((ListViewItem) sender).Content as ListViewFrontend).Key;

			Assembly assembly = Assembly.Load("WMI.NET");
			Type t = assembly.GetType(type);

			var wmiClasses = new LocalWMIQueryProvider() .GetObjects(t, 5).Select(x => x.ToString());
			StringBuilder sb = new StringBuilder();
			foreach (var v in wmiClasses)
			{
				sb.Append(v);
				sb.Append("\n\n");
			}

			ResultText.Text = sb.ToString();
		}
	}
}
