﻿using System.Web.Mvc;
using System.Web.Routing;

namespace Arackiralama.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
     "Admin_default",
     "Admin/{controller}/{action}/{id}",
     new {controller="Admin", action = "Index", id = UrlParameter.Optional },
     new[] { "AracKiralama.Areas.Admin.Controllers" }
 );

        }
       
    }
}