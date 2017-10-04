using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Elf.Api.Api;

namespace Elf.Api.IoC.Installers
{
    public class ApiControllerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                            .BasedOn<BaseApiController>()
                            .LifestyleTransient());
        }
    }
}