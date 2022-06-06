using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Arackiralama
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
     "Default",
     "{controller}/{action}/{id}",
     new { controller = "Car", action = "Index", id = UrlParameter.Optional },
     new[] { "AracKiralama.Controllers" }
 );
        }
    }
}
