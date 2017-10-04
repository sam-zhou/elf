using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Elf.Core.Repositories.Interfaces;
using Elf.Core.Uow;

namespace Elf.ServiceApp.IoC.Installers
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            

            container.Register(Classes.FromAssemblyInThisApplication()
                            .BasedOn<IRepository>().WithServiceAllInterfaces()
                            .LifestyleTransient()
                );
        }
    }
}