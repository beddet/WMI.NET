using Browser.Controls;
using Browser.Controls.Browse;
using Browser.Controls.CustomQuery;
using Browser.Controls.Demo;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Browser.Misc.CointainerInstallers
{
	public class UserControlInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(
				Component.For<CustomQueryControl>().ImplementedBy<CustomQueryControl>()
				,Component.For<ResultsControl>().ImplementedBy<ResultsControl>()
				,Component.For<OutputControl>().ImplementedBy<OutputControl>()
				, Component.For<BrowseControl>().ImplementedBy<BrowseControl>()
				, Component.For<DemoControl>().ImplementedBy<DemoControl>()
				);
		}
	}
}