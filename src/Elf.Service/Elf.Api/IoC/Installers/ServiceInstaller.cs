using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Elf.Core.Services.Interface;
using log4net;

namespace Elf.Api.IoC.Installers
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ILog>().Instance(LogManager.GetLogger(typeof(WebApiApplication))));


            container.Register(Classes.FromAssemblyInThisApplication()
                            .BasedOn<IService>().WithServiceAllInterfaces()
                            .LifestyleTransient()
                );


            

        }
    }
}