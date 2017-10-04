using Elf.Api;
using Elf.Api.IoC;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace Elf.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            IoCContainer.Setup();
            
        }
    }
}
