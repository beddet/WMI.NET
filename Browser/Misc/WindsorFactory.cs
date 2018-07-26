using System;
using System.Linq;
using System.Windows.Controls;
using Browser.Controls.Browse;
using Browser.Controls.CustomQuery;
using Browser.Controls.CustomQuery.ViewModels;
using Browser.Model;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using WMI.NET;
using WMI.NET.QueryProvider;

namespace Browser.Misc
{
	public class WindsorFactory : IFactory
	{
		private readonly WindsorContainer _container;

		private static WindsorFactory _instance;
		private static readonly object _locker = new object();

		private WindsorFactory()
		{
			_container = new WindsorContainer();
			Install();
		}

		public static WindsorFactory Instance
		{
			get
			{
				lock (_locker)
				{
					if (_instance == null)
					{
						_instance = new WindsorFactory();
					}
					return _instance;
				}
			}
		}

		public T Resolve<T>()
		{
			return _container.Resolve<T>();
		}

		public MainWindow CreateMainWindow()
		{
			return _container.Resolve<MainWindow>();
		}

		public CustomQueryControl CreateCustomQueryControl()
		{
			var control = _container.Resolve<CustomQueryControl>();
			control.DataContext = _container.Resolve<CustomQueryControlViewModel>();
			var resultsControl = CreateResultsControl();
			resultsControl.DataContext = _container.Resolve<CustomQueryControlViewModel>();
			control.ResultsPanel.Children.Add(resultsControl);
			var outputControl = CreateOutputControl();
			outputControl.DataContext = _container.Resolve<CustomQueryControlViewModel>();
			control.OutputPanel.Children.Add(outputControl);
			return control;
		}

		public OutputControl CreateOutputControl()
		{
			return _container.Resolve<OutputControl>();
		}

		public ResultsControl CreateResultsControl()
		{
			return _container.Resolve<ResultsControl>();
		}

		private void Install()
		{
			_container.Install(FromAssembly.This());
			_container.Register(Component.For<LocalWMIQueryProvider>());
			_container.Register(Component.For<CustomQueryControlViewModel>().LifestyleSingleton());
		}

		public BrowseControl CreateBrowseControl()
		{
			var browseControl = _container.Resolve<BrowseControl>();
			browseControl.QueryableTypes.ItemsSource = Resolve<LocalWMIQueryProvider>().QueryableClasses().Select(x => new ListViewFrontend { Key = x.FullName, Value = x.Name}).OrderBy(x => x.Value);
			return browseControl;
		}
	}
}