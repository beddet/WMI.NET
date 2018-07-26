using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Browser.Model;
using WMI.NET;
using WMI.NET.QueryProvider;

namespace Browser.Controls.CustomQuery
{
	/// <summary>
	/// Interaction logic for CustomQuery.xaml
	/// </summary>
	public partial class CustomQueryControl : BaseControl
	{
		public CustomQueryControl()
		{
			InitializeComponent();
		}

		private void QueryText_KeyUp(object sender, KeyEventArgs e)
		{
			switch (e.Key)
			{
				case Key.F5:
					QueryButton.Command.Execute(null);
					break;
			}
		}
	}
}
