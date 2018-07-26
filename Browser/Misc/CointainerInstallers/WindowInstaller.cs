using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Browser.Misc.CointainerInstallers
{
	public class WindowInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(Component.For<MainWindow>().ImplementedBy<MainWindow>());
		}
	}
}