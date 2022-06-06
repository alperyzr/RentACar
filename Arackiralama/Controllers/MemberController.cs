using Arackiralama.Models;
using Arackiralama.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Arackiralama.Controllers
{
    public class MemberController : Controller
    {
        AracKiralamaEntities1 db = new AracKiralamaEntities1();
        public ActionResult Profile(string ID)
        {
            string Culture = Session["culture"].ToString();

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Culture); // de-DE
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Culture);
            int AccountID= Convert.ToInt32(Session["ID"].ToString());
            var userProfile = db.Accounts.FirstOrDefault(m => m.ID == AccountID);
            var DogumTarihi = userProfile.BirthDate.Value.ToString("yyyy-MM-dd");
            ViewBag.DogumTarihi = DogumTarihi;
            ViewBag.Cinsiyet = userProfile.Gender.ToString();
            return View(userProfile);
                
        }
        [HttpPost]
        public ActionResult Profile(Accounts model,int ID)
        {
            string Culture = Session["culture"].ToString();

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Culture); // de-DE
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Culture);
            var editProfile = db.Accounts.Where(u => u.ID == ID).SingleOrDefault();
            editProfile.FirstName = model.FirstName;
            editProfile.LastName = model.LastName;
            editProfile.Phone = model.Phone;
            editProfile.DateOfUpdate = DateTime.Now;
            editProfile.UpdatedPerson = model.FirstName + " " + model.LastName;
            editProfile.Address = model.Address;
            editProfile.BirthDate = model.BirthDate;
            editProfile.Gender = model.Gender;
            editProfile.Email = model.Email;
            db.SaveChanges();
            return RedirectToAction("Profile", "Member", editProfile);
        }
        public ActionResult SifreDegistir(UserViewModel user,string message)
        {
            string Culture = Session["culture"].ToString();

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Culture); // de-DE
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Culture);
            if (message!=null)
            {
                ViewBag.Message = message;
            }
            return View(user);
        }
        [HttpPost]
        public ActionResult SifreDegistir(string ID,UserViewModel user)
        {
            string Culture = Session["culture"].ToString();

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Culture); // de-DE
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Culture);
            var EditPassword = db.Accounts.Where(m => m.ID.ToString() == ID).SingleOrDefault();
            if (user.Sifre == EditPassword.Password)
            {
               
               
                if (user.YeniSifre == user.YeniSifreTekrar)
                {
                    EditPassword.Password = user.YeniSifre;
                    EditPassword.PasswordAgain = user.YeniSifreTekrar;
                    db.SaveChanges();
                    return RedirectToAction("SifreDegistir", "Member", new { @message ="Şifre başarıyla değiştirildi." /*Html.Raw(Arackiralama.Resources.LanguageFields.PasswordUpdated)*/ });
                }
                else
                {
                    return RedirectToAction("SifreDegistir", "Member", new { @message = "Şifreler Uyuşmuyor. Lütfen Kontrol Ediniz" });
                }
            }
            else
            {
                return RedirectToAction("SifreDegistir","Member",new { @message = "Beklenmeik bir hata oluştu." });
            }
           
           
        }
        public ActionResult SifreUnuttumEPosta()
        {
            string Culture = Session["culture"].ToString();

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Culture); // de-DE
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Culture);
            return View();
        }
        [HttpPost]
        public ActionResult SifreUnuttumEPosta(UserViewModel user,SendMail model)
        {
            string Culture = Session["culture"].ToString();

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Culture); // de-DE
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Culture);
            var forgotPassword = db.Accounts.Where(u => u.Email == user.EPosta).SingleOrDefault();
            if (forgotPassword!=null)
            {
                string baseUrl = System.Configuration.ConfigurationManager.AppSettings["baseSiteUrl"];
                var body = new StringBuilder();
                body.AppendLine("Merhabalar Sayın " + forgotPassword.FirstName + " " + forgotPassword.LastName + ";");
                body.AppendLine(forgotPassword.Email + " E-Mail adresi üzerinden Şifre mi Unuttum talebinde bulundunuz.");
                body.AppendLine(baseUrl+"Member/SifreUnuttumSifre/" + forgotPassword.ID);
                body.AppendLine("Linke tıklayarak yeni şifrenizi oluşturabilirsiniz.");
                
                string head = "Parola Değiştirme Talebi";
                try
                {
                    int sendMail = Mail.SendMail(forgotPassword.Email, head, body.ToString());
                    if(sendMail == 1)
                    {
                        ViewBag.Success = true;
                    }
                    else
                    {
                        ViewBag.Success = false;
                    }
                   
                }
                catch (Exception err)
                {

                    string url = System.Configuration.ConfigurationManager.AppSettings["ErrorURL"].ToString();
                    string errordetail = err.StackTrace + "-------" + err.Message + ";;" + err.InnerException;
                    Response.Redirect(url + errordetail);
                    ViewBag.Success = false;
                }
              
            }
            return View();
        }
        public ActionResult SifreUnuttumSifre(int ID)
        {
            string Culture = Session["culture"].ToString();

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Culture); // de-DE
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Culture);
            if (ViewBag.Hata!=null)
            {
                ViewBag.Hata.ToString();
            }
            var newPassword = db.Accounts.Where(u => u.ID == ID).SingleOrDefault();           
            return View();
            
        }
        [HttpPost]
        public ActionResult SifreUnuttumSifre(Accounts user)
        {
            string Culture = Session["culture"].ToString();

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Culture); // de-DE
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Culture);
            var newPassword = db.Accounts.Where(u => u.ID == user.ID).SingleOrDefault();
            if (newPassword.ID.ToString() != "00000000-0000-0000-0000-000000000000")
            {
                if (user.Password == user.PasswordAgain)
                {
                    newPassword.Password = user.Password;
                    newPassword.PasswordAgain = user.PasswordAgain;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Login", new { newpassword = "Şifre başarıyla değiştirildi" });
                }
                else
                {
                    ViewBag.Hata = "Şifreler uyuşmuyor. lütfen Kontol ediniz.";
                    return View();
                }
            }
            else
            {
                ViewBag.Hata = "Böyle bir kullanıcı mevcut değil";
                return View();
            }
        }
        public ActionResult OrderHistory(string ID)
        {
            string Culture = Session["culture"].ToString();

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Culture); // de-DE
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Culture);
            int AccountID =Convert.ToInt32(Session["ID"].ToString());

            int ContactID = db.Contacts.FirstOrDefault(t=>t.AccountID== AccountID).ID;
            var OrderHistoryList = db.VehicleOrders.Where(t => t.Orders.ContactID == ContactID).OrderByDescending(x => x.ID).ToList();


            //var OrderHistoryList = db.VehicleOrders.Where(t => t.Identifier == ID).ToList();
            return View(OrderHistoryList);
           
        }
        
        public ActionResult OrderHistoryDetail(int ID)
        {
            string Culture = Session["culture"].ToString();
           
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Culture); // de-DE
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Culture);
            var OrderHistoryDetail = db.VehicleOrders.Where(t => t.ID == ID).FirstOrDefault();
            return View(OrderHistoryDetail);
        }
    }
}