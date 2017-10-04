using System.Web;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Elf.Core.Models;
using Elf.Core.Providers;
using Elf.Core.Uow;
using Raven.Client;

namespace Elf.ServiceApp.IoC.Installers
{
    public class BaseInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IUnitOfWorkFactory>()
                .ImplementedBy<RavenUnitOfWorkFactory>()
                .LifestylePerWebRequest());

            RavenUnitOfWorkFactory.SetObjectContext(
                () => InitialDocumentStore()
            );

            container.Register(Component.For<IDocumentStore>()
                .Instance(InitialDocumentStore()).LifestylePerWebRequest());

            container.Register(Component.For<IUnitOfWork>()
                .ImplementedBy<RavenUnitOfWork>()
                .LifestylePerWebRequest());

            container.Register(Component.For<IClientInfoProvider>()
                .ImplementedBy<ClientInfoProvider>()
                .LifestylePerWebRequest());
        }


        private IDocumentStore InitialDocumentStore() {
            var documentStore = new Raven.Client.Document.DocumentStore { Url = "http://localhost:8080" };
            documentStore.Conventions.IdentityPartsSeparator = "-";
            documentStore.Initialize();
            return documentStore;
        }
    }
}