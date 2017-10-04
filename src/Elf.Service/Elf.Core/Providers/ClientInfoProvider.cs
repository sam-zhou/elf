using System.Web;

namespace Elf.Core.Providers
{
    public class ClientInfoProvider: IClientInfoProvider
    {
        public string BrowserInfo => GetBrowserInfo();

        public string ClientIpAddress => GetClientIpAddress();


        /// <summary>
        /// Creates a new <see cref="ClientInfoProvider"/>.
        /// </summary>
        public ClientInfoProvider()
        {
            
        }

        protected virtual string GetBrowserInfo()
        {
            var httpContext = HttpContext.Current;
            if (httpContext?.Request.Browser == null)
            {
                return null;
            }

            return httpContext.Request.Browser.Browser + " / " +
                   httpContext.Request.Browser.Version + " / " +
                   httpContext.Request.Browser.Platform;
        }

        protected virtual string GetClientIpAddress()
        {
            var httpContext = HttpContext.Current;
            if (httpContext?.Request.ServerVariables == null)
            {
                return null;
            }

            var clientIp = httpContext.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ??
                           httpContext.Request.ServerVariables["REMOTE_ADDR"];

            return clientIp;
        }
    }
}
