using Arackiralama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Arackiralama.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        public AracKiralamaEntities1 db = new AracKiralamaEntities1();
       public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(string errorMessage)
        {
            if (errorMessage != null)
            {
                ViewBag.ErrorMessage = errorMessage;
            }
            Session["LoginControl"] = null;
            Session["Admin"] = null;
            Session["AdminID"] = null;
            return View();
        }
        [HttpPost]
        public ActionResult LoginControl(string username, string password)
        {
            if (username != null && password != null)
            {
                var model = db.Accounts.Where(m => m.Email == username && m.Password == password && m.RoleID == 1).SingleOrDefault();
                if (model != null)
                {
                    Session["LoginControl"] = true;
                    Session["Admin"] = model.FirstName +" "+ model.LastName;
                    Session["AdminID"] = model.ID;
                    return RedirectToAction("List", "User");
                }
               
                else
                {
                    Session["LoginControl"] = null;
                    return RedirectToAction("Login", "Admin",new { @errorMessage = "Böyle bir kullanıcı mevcut değil. Lütfen bilgileri kontrol ediniz." });
                }
                
            }

            else
            {
                Session["LoginControl"] = null;
                return RedirectToAction("Login", "Admin",new { @errorMessage = "Giriş Sağlanamadı. Kullanıcı Adı ve Şifrenizi tekrar kontrol ederek giriş yapınız" });
            }
          
            
        }
        public ActionResult AdminProfile(string message,string successMessage)
        {
            if (Session["LoginControl"]!=null)
            {
                if (message != null)
                {
                    ViewBag.Hata = message;
                }
                if (successMessage != null)
                {
                    ViewBag.SuccessMessage = successMessage;
                }
                var ID = (int)Session["AdminID"];
                var model = db.Accounts.Where(m => m.ID == ID).SingleOrDefault();
                model.Password = null;
                model.PasswordAgain = null;
                return View(model);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
           
        }
        [HttpPost]
        public ActionResult AdminProfile(Accounts model)
        {
            if (Session["LoginControl"] !=null)
            {
                var result = db.Accounts.Where(m => m.ID == model.ID).SingleOrDefault();
                if (model.Password == model.PasswordAgain)
                {
                    result.Password = model.Password;
                    result.PasswordAgain = model.PasswordAgain;
                    db.SaveChanges();
                    return RedirectToAction("AdminProfile", "Admin", new { @successMessage = "Şifre Başarıyla Güncellendi" });
                }
                else
                {
                    return RedirectToAction("AdminProfile", "Admin", new { @message = "Şifreler Uyuşmuyor. lütfen Tekrar Deneyiniz." });
                }
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
            
        }
    }
}