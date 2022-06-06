using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Arackiralama
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
           
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        protected void Application_Error(object sender, EventArgs e)
        {
            string url = "https://aracvararac.com/Car/VehicleError?errorNum=";// System.Configuration.ConfigurationManager.AppSettings["ErrorURL"].ToString();
           

       
            Exception err = Server.GetLastError();
            Uri MyUrl = Request.Url;
            string errordetail = err.StackTrace + "-------" + err.Message + ";;" + err.InnerException + ":::::::::::::::" + MyUrl.AbsoluteUri;



            Response.Redirect(url + errordetail);
            
            //catch (Exception)
            //{
            //    string errordetail = "bilinmeyen hata";
            //    Response.Redirect(url + errordetail);
             
            //}
        }
        //          protected void Application_AcquireRequestState(object sender, EventArgs e)
        //    {
        //         //It's important to check whether session object is ready
        //         if (HttpContext.Current.Session != null)
        //         {
        //                System.Globalization.CultureInfo ci = (System.Globalization.CultureInfo)this.Session["culture"];
        //             //Checking first if there is no value in session 
        //             //and set default language 
        //             //this can happen for first user's request
        //             if (ci == null)
        //             {
        //                 //Sets default culture to english invariant
        //                 string langName = "en";

        //                 //Try to get values from Accept lang HTTP header
        //                 if (HttpContext.Current.Request.UserLanguages != null && 
        //HttpContext.Current.Request.UserLanguages.Length != 0)
        //                 {
        //                     //Gets accepted list 
        //                     langName = HttpContext.Current.Request.UserLanguages[0].Substring(0, 2);
        //                 }
        //                 ci = new CultureInfo(langName);
        //                 this.Session["culture"] = ci;
        //             }
        //                //Finally setting culture for each request
        //                System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
        //                System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(ci.Name);
        //         }
        //    }
    }
}
