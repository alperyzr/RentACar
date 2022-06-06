using Arackiralama.Models;
using Arackiralama.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Arackiralama.Controllers
{
    public class LoginController : Controller
    {
        AracKiralamaEntities1 db = new AracKiralamaEntities1();

        public ActionResult Index(string message, string newpassword)
        {
            string Culture = "tr-TR";
            if (Session["culture"] != null)
            {
                Culture = Session["culture"].ToString();
            }
            else
            {
                Session["culture"] = Culture;

            }


            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Culture); // de-DE
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Culture);

            if (newpassword != null)
            {
                ViewBag.NewPassword = newpassword;
            }
            if (message != null)
            {
                ViewBag.Kayit = message;
            }
            if (ViewBag.Hata != null)
            {
                ViewBag.Hata.ToString();
            }
            if (ViewBag.Login != null)
            {
                ViewBag.Login.ToString();
            }
            Session["KullaniciAdi"] = null;
            Session["ID"] = null;
            return View();
        }
        [HttpPost]
        public ActionResult Index(UserViewModel model)
        {
            string Culture = Session["culture"].ToString();

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Culture); // de-DE
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Culture);
            var kullanici = db.Accounts.Where(u => u.Email == model.EPosta && u.Password == model.Sifre || u.Password == model.EPosta).SingleOrDefault();
            if (kullanici != null)
            {
                Session["KullaniciAdi"] = kullanici.FirstName + " " + kullanici.LastName;
                Session["ID"] = kullanici.ID.ToString();
                if (kullanici.Email == model.EPosta && kullanici.Password == model.Sifre)
                {
                    bool isFirstCheck = false;
                    if (kullanici.FirstLoggin == false)
                    {
                        kullanici.FirstLoggin = true;
                        isFirstCheck = true;
                        db.SaveChanges();
                    }


                    db.SaveChanges();
                    //return RedirectToAction("Index", "Car", kullanici);
                    return RedirectToAction("Index", "Car", new { isFirstCheck });
                }

                else
                {
                    ViewBag.Login = "Kullanıcı Adı ve ya Şifre yanlış. Lütfen tekrar deneyiniz.";
                    return View();
                }
            }
            else
            {
                ViewBag.Hata = "Böyle bir kayıt yok. Lütfen önce kayıt olunuz";
                return View();
            }


        }
        public ActionResult Register(UserViewModel user)
        {
            string Culture = Session["culture"].ToString();

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Culture); // de-DE
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Culture);
           
           
            return View(user);
        }
        [HttpPost]
        public ActionResult Register(UserViewModel model, FormCollection collection, bool CookiePolicyIsChecked = false)
        {
            string Culture = Session["culture"].ToString();

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Culture); // de-DE
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Culture);
            Accounts u = new Models.Accounts
            {
                UniqueKey = Guid.NewGuid().ToString(),
                FirstName = model.Ad,
                LastName = model.Soyad,
                Address = model.Adres,
                AvatarResim = model.ImageUrl,
                Gender = model.Cinsiyet,
                BirthDate = model.DogumTarihi,
                Email = model.EPosta,
                //ID = model.ID,
                IsActive = "Aktif",
                DateOfRegistration = DateTime.Now,
                RecordPerson = model.Ad + " " + model.Soyad,
                Password = model.Sifre,
                PasswordAgain = model.SifreTekrar,
                RoleID = 2,
                Phone = model.Telefon,
                LastLoginDate = DateTime.Now,
                CreatedAt = DateTime.Now,
                FirstLoggin = false,
                FirstLoginChecked = false,
                CookiePolicyIsChecked = CookiePolicyIsChecked
            };
            var EMailControl = db.Accounts.Where(m => m.Email == u.Email).FirstOrDefault();
            if (EMailControl == null)
            {


                if ((u.Password == u.PasswordAgain) && (u.Password != null && u.PasswordAgain != null))
                {
                   

                    if (CookiePolicyIsChecked && model.DogumTarihi != null)
                    {
                        db.Accounts.Add(u);

                        var cnt = db.Contacts.Create();

                        cnt.Email = u.Email;
                        cnt.FirstName = u.FirstName;
                        cnt.LastName = u.LastName;
                        cnt.Phone = u.Phone;
                        cnt.Accounts = u;

                        db.Contacts.Add(cnt);
                        db.SaveChanges();
                        return RedirectToAction("Index", "Login", new { @message = "Kayıt Başarıyla Eklendi" });

                    }
                    else if (model.DogumTarihi == null)
                    {
                        ViewBag.Hata = "Doğum Tarihi Boş Geçilemez.";
                        return View(model);
                    }

                    else if(CookiePolicyIsChecked != true)
                    {
                        ViewBag.Hata = "Çerez Politikasını Kabul etmeniz gerekmektedir.";
                        return View(model);
                    }
                    else
                    {
                        ViewBag.Hata = "Beklenmedik bir hata oluştu";
                        return View(model);
                    }

                }
                else if (u.Password != u.PasswordAgain)
                {
                    ViewBag.Hata = "Şifreler uyuşmuyor. lütfen Kontrol ediniz";
                    return View(model);

                }
                else
                {
                    ViewBag.Hata = "Beklenmedik bir hata oluştu";
                    return View(model);
                }
            }
            else
            {
                ViewBag.Hata = "Böyle Bir mail adresi mevcut.";
                return View(model);
            }



        }

        public int SaveImage(byte[] image, string ImageName, string UploadFile)
        {
            try
            {
                MemoryStream ms = new MemoryStream(image);
                Image _Image = Image.FromStream(ms);
                string path = HttpContext.Server.MapPath("~/Upload/" + UploadFile + "/");
                string ImagePath = path + ImageName;
                if (ImageName.Contains("JPG") || ImageName.Contains("jpg"))
                {
                    _Image.Save(ImagePath, ImageFormat.Jpeg);
                }
                else
                {
                    _Image.Save(ImagePath, ImageFormat.Png);
                }
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public string NameSeoReplace(string IncomingText)
        {
            IncomingText = IncomingText.Replace("ş", "s");
            IncomingText = IncomingText.Replace("Ş", "s");
            IncomingText = IncomingText.Replace("İ", "i");
            IncomingText = IncomingText.Replace("I", "i");
            IncomingText = IncomingText.Replace("ı", "i");
            IncomingText = IncomingText.Replace("ö", "o");
            IncomingText = IncomingText.Replace("Ö", "o");
            IncomingText = IncomingText.Replace("ü", "u");
            IncomingText = IncomingText.Replace("Ü", "u");
            IncomingText = IncomingText.Replace("Ç", "c");
            IncomingText = IncomingText.Replace("ç", "c");
            IncomingText = IncomingText.Replace("ğ", "g");
            IncomingText = IncomingText.Replace("Ğ", "g");
            IncomingText = IncomingText.Replace(" ", "-");
            IncomingText = IncomingText.Replace("---", "-");
            IncomingText = IncomingText.Replace("?", "");
            IncomingText = IncomingText.Replace("/", "");
            IncomingText = IncomingText.Replace("'", "");
            IncomingText = IncomingText.Replace("#", "");
            IncomingText = IncomingText.Replace("%", "");
            IncomingText = IncomingText.Replace("&", "");
            IncomingText = IncomingText.Replace("*", "");
            IncomingText = IncomingText.Replace("!", "");
            IncomingText = IncomingText.Replace("@", "");
            IncomingText = IncomingText.Replace("+", "");

            IncomingText = IncomingText.ToLower();
            IncomingText = IncomingText.Trim();

            string encodedUrl = (IncomingText ?? "").ToLower();
            encodedUrl = Regex.Replace(encodedUrl, @"\&+", "and");
            encodedUrl = encodedUrl.Replace("'", "");
            encodedUrl = Regex.Replace(encodedUrl, @"[^a-z0-9,.]", "-");
            encodedUrl = Regex.Replace(encodedUrl, @"-+", "-");
            encodedUrl = encodedUrl.Trim('-');

            return encodedUrl;
        }
    }
}
