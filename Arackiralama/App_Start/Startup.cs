using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(Arackiralama.App_Start.Startup))]

namespace Arackiralama.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Member/Index")
            });
            //app.UseFacebookAuthentication(
            //    consumerKey: "278718150139634",
            //    consumerSecret: "9ad0bd481b485d8aae4409b9649c56d5"
            //);
        }
    }
}
