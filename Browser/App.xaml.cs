using System;
using System.Linq;
using System.Windows;
using System.Windows.Threading;
using Browser.Controls.Browse;
using Browser.Controls.CustomQuery;
using Browser.Controls.Demo;
using Browser.Misc;
using WMI.NET;
using WMI.NET.Model.Win32.OperatingSystem.FileSystem.LogicalDisk;
using WMI.NET.QueryProvider;

namespace Browser
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private readonly WindsorFactory _factory;
		private ViewModel viewModel;

		public App()
		{
			_factory = WindsorFactory.Instance;
		}

		private DispatcherTimer timer;
		private DateTime start;
		private DateTime last;


		private void ApplicationStartUp(object sender, StartupEventArgs e)
		{
			var mainWindow = _factory.CreateMainWindow();
			mainWindow.customQueryTabPanel.Children.Add(mainWindow.AddControl<CustomQueryControl>(_factory.CreateCustomQueryControl()));
			mainWindow.BrowseTabPanel.Children.Add(mainWindow.AddControl<BrowseControl>(_factory.CreateBrowseControl()));

			viewModel = _factory.Resolve<ViewModel>();

			mainWindow.demoTabPanel.Children.Add(mainWindow.AddControl<DemoControl>(new DemoControl(viewModel)));
			mainWindow.Show();

			//ShowDemoGraph();
		}

		private void ShowDemoGraph()
		{
			timer = new DispatcherTimer
				{
					Interval = TimeSpan.FromMilliseconds(5)
				};
			timer.Tick += timer_Tick;
			last = start = DateTime.Now;
			timer.IsEnabled = true;
		}

		void timer_Tick(object sender, EventArgs e)
		{
			// add new items each tick
			TimeSpan span = DateTime.Now - last;
			TimeSpan totalSpan = DateTime.Now - start;
			int previousTime = viewModel.List.Count > 0 ? viewModel.List[viewModel.List.Count - 1].Time : 0;
			var freeSpace = _factory.Resolve<LocalWMIQueryProvider>().GetObjects<Win32_LogicalDisk>(1).ToList()[0].FreeSpace;
			RealtimeGraphItem newItem = new RealtimeGraphItem
			{
				Time = (int)(previousTime + span.TotalMilliseconds),
				Value = freeSpace / (1024*1024*1024)
			};

			viewModel.List.Add(newItem);
			last = DateTime.Now;
		}
	}
}
