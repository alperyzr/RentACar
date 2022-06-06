using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Arackiralama.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
    
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (Session["culture"] == null)
            {
                Session["culture"] = "tr-TR";
            }
            if (Session["currency"]==null)
            {
                Session["currency"] = "TRY";
            }
        }
        //protected override System.Net.WebRequest Create(Uri uri)
        //{
        //    System.Net.HttpWebRequest webRequest = (HttpWebRequest)base.Create(uri);
        //    //Setting KeepAlive to false
        //    webRequest.KeepAlive = false;
        //    return webRequest;
        //}
    }
}