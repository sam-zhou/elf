using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Elf.Core.Uow;

namespace Elf.Api
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            AutoMapperConfig.Initialize();
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            UnitOfWork.Current.Dispose();
        }
    }
}
