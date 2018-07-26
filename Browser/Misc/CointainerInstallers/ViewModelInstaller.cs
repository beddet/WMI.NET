
using Browser.Controls.Demo;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Browser.Misc.CointainerInstallers
{
	public class ViewModelInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(Component.For<ViewModel>().ImplementedBy<ViewModel>());
		}
	}
}