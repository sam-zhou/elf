using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Elf.Core.Repositories.Interfaces;
using Elf.Core.Uow;

namespace Elf.Api.IoC.Installers
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IUnitOfWorkFactory>().ImplementedBy<RavenUnitOfWorkFactory>().LifestylePerWebRequest());

            RavenUnitOfWorkFactory.SetObjectContext(
                () =>
                {
                    var documentStore = new Raven.Client.Document.DocumentStore { Url = "http://localhost:8080" };
                    documentStore.Conventions.IdentityPartsSeparator = "-";
                    documentStore.Initialize();
                    return documentStore;
                }
            );

            container.Register(Classes.FromAssemblyInThisApplication()
                            .BasedOn<IRepository>().WithServiceAllInterfaces()
                            .LifestyleTransient()
                );
        }
    }
}