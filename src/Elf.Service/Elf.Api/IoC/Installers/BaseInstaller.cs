using System.Data.Entity;
using System.Web;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Elf.Core.Models;
using Elf.Core.Providers;
using Elf.Core.Uow;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace Elf.Api.IoC.Installers
{
    public class BaseInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IUnitOfWork>()
                .ImplementedBy<RavenUnitOfWork>()
                .LifestylePerWebRequest());
            container.Register(Component.For<IClientInfoProvider>().ImplementedBy<ClientInfoProvider>().LifestylePerWebRequest());
        }
    }
}