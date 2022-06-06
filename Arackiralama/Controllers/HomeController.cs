using Arackiralama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Arackiralama.Controllers
{
    public class HomeController : Controller
    {
        public AracKiralamaEntities1 db = new AracKiralamaEntities1();
       public PartialViewResult LayoutNavbar()
        {
            var LanguageList = db.Cultures.Where(c=>c.IsActive=="Aktif").ToList();
            return PartialView(LanguageList);
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}