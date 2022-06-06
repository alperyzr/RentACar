using Arackiralama.Models;
using Arackiralama.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Arackiralama.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        public AracKiralamaEntities1 db = new AracKiralamaEntities1();
        public ActionResult List(string message)
        {
            if (Session["LoginControl"] != null)
            {
                if (message != null)
                {
                    ViewBag.Message = message;
                }
                var UserList = db.Accounts.OrderByDescending(x => x.ID).ToList();
                return View(UserList);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        public ActionResult Create(Accounts user, string message)
        {

            if (Session["LoginControl"] != null)
            {
                Accounts result = new Accounts();
                if (message != null)
                {
                    ViewBag.Message = message;
                }

                if (user.Password != user.Password)
                {
                    ViewBag.Password = "Şifreler Uyuşmuyor. lütfen Kontrol ediniz";
                }
                var model = new Accounts();
                model.Rol = db.Rol.ToList();
                if (user.ID != 0)
                {
                    user.Rol = model.Rol;
                    result.Rol = user.Rol;
                    result.RoleID = user.RoleID;
                    result.FirstName = user.FirstName;
                    result.LastName = user.LastName;
                    result.BirthDate = user.BirthDate;
                    //result.DTarihi = user.DogumTarihi.Value.ToString("yyyy-MM-dd");
                    result.Address = user.Address;
                    result.Email = user.Email;
                    result.Password = user.Password;
                    result.PasswordAgain = user.PasswordAgain;
                    result.Gender = user.Gender;
                    result.Phone = user.Phone;
                    result.AvatarResim = user.AvatarResim;
                    result.IsActive = user.IsActive;

                    return View(result);

                }
                else
                {
                    result.Rol = model.Rol;
                    result.BirthDate = new DateTime();
                    return View(result);
                }

            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }

        }
        [HttpPost]
        public ActionResult Create(Accounts result)
        {
            var model = new Accounts();
            model.Rol = db.Rol.ToList();
            if (result.ID == 0)
            {
                //if (Path.GetExtension(model.AvatarResim.FileName) == ".jpg" || Path.GetExtension(model.AvatarResim.FileName) == ".JPG" || Path.GetExtension(model.AvatarResim.FileName) == ".png" || Path.GetExtension(model.AvatarResim.FileName) == ".PNG")
                //{

                //    MemoryStream target = new MemoryStream();
                //    model.AvatarResim.InputStream.CopyTo(target);
                //    model.IconByte = target.ToArray();
                //    model.IconExtension = Path.GetExtension(model.AvatarResim.FileName);
                //    model.AvatarResim = null;
                //    string ImageName = NameSeoReplace(model.Ad + " " + model.Soyad) + "-avatar-" + Guid.NewGuid().ToString().Substring(0, 8) + model.IconExtension;
                //    int imageresult = SaveImage(model.IconByte, ImageName, "ProfileAvatar");

                Accounts u = new Models.Accounts
                {
                    RoleID = result.RoleID,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    BirthDate = result.BirthDate,
                    Address = result.Address,
                    //AvatarResim = "/Upload/ProfileAvatar/" + ImageName,
                    Gender = result.Gender,
                    Email = result.Email,
                    DateOfRegistration = DateTime.Now,
                    RecordPerson = "Admin",
                    Phone = result.Phone,
                    IsActive = result.IsActive,
                    Password = result.Password,
                    PasswordAgain = result.PasswordAgain,
                    CreatedAt = DateTime.Now

                };
                var EMailControl = db.Accounts.Where(m => m.Email == u.Email).FirstOrDefault();
                if (EMailControl == null)
                {
                    if ((u.Password == u.PasswordAgain) && (u.Password != null && u.PasswordAgain != null))
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
                        return RedirectToAction("Create", "User", new { @message = "Kayıt Başarıyla Eklendi" });


                    }
                    else if (u.Password != u.PasswordAgain)
                    {
                        ViewBag.Hata = "Şifreler uyuşmuyor. lütfen Kontrol ediniz";
                        result.Rol = model.Rol;
                        return View(result);

                    }
                    else
                    {
                        ViewBag.Hata = "Beklenmedik bir hata oluştu";
                        result.Rol = model.Rol;
                        return View(result);
                    }
                }
                else
                {
                    ViewBag.Hata = "Böyle Bir mail adresi mevcut.";
                    result.Rol = model.Rol;
                    return View(result);
                }

            }
            else
            {
                //MemoryStream target = new MemoryStream();
                //string ImageName = "";
                //if (model.AvatarResim != null)
                //{
                //    model.AvatarResim.InputStream.CopyTo(target);
                //    model.IconByte = target.ToArray();
                //    model.IconExtension = Path.GetExtension(model.AvatarResim.FileName);
                //    model.AvatarResim = null;
                //    ImageName = NameSeoReplace(model.Ad + " " + model.Soyad) + "-avatar-" + Guid.NewGuid().ToString().Substring(0, 8) + model.IconExtension;
                //    int imageresult = SaveImage(model.IconByte, ImageName, "ProfileAvatar");
                //}

                var EditUser = db.Accounts.Where(x => x.ID == result.ID).SingleOrDefault();
                EditUser.RoleID = result.RoleID;
                EditUser.FirstName = result.FirstName;
                EditUser.LastName = result.LastName;
                EditUser.LastLoginDate = result.LastLoginDate;
                EditUser.UpdatedPerson = result.UpdatedPerson;

                EditUser.BirthDate = result.BirthDate;
                EditUser.DateOfUpdate = DateTime.Now;
                //if (ImageName != null)
                //{
                //    EditUser.AvatarResim = "/Upload/ProfileAvatar/" + ImageName;
                //}
                EditUser.Address = result.Address;

                EditUser.Gender = result.Gender;
                EditUser.Email = result.Email;
                EditUser.Password = result.Password;
                EditUser.PasswordAgain = result.PasswordAgain;
                EditUser.Phone = result.Phone;
                EditUser.IsActive = result.IsActive;
                if (EditUser.Password == EditUser.PasswordAgain)
                {

                    db.SaveChanges();
                    return RedirectToAction("List", "User", new { message = "Kayıt Başarıyla Güncellendi" });
                }
                else
                {

                    ViewBag.Password = "Şifreler Uyuşmuyor. lütfen kontrol ediniz.";
                    return RedirectToAction("Create", "User", EditUser);

                }

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

        public ActionResult Edit(int ID)

        {
            if (Session["LoginControl"] != null)
            {
                var model = db.Accounts.FirstOrDefault(edt => edt.ID == ID);
                string birthDate =(model.BirthDate!=null ? model.BirthDate.Value.ToString("yyyy-MM-dd"):"1111-01-01");
                model.Rol = db.Rol.ToList();
                Accounts m = new Models.Accounts
                {
                    Rol = model.Rol,
                    RoleID = model.RoleID,
                    FirstName = model.FirstName,
                    Address = model.Address,
                    AvatarResim = model.AvatarResim,
                    BirthDate = Convert.ToDateTime(birthDate),
                    Gender = model.Gender,
                    Email = model.Email,
                    IsActive = model.IsActive,
                    LastName = model.LastName,
                    ID = model.ID,
                    Phone = model.Phone,
                    Password = model.Password,
                    PasswordAgain = model.PasswordAgain
                };
                return RedirectToAction("Create", "User", m);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }


        }

        public ActionResult Detail(int ID)
        {
            if (Session["LoginControl"] != null)
            {
                var KullaniciDetayi = db.Accounts.FirstOrDefault(u => u.ID == ID);
                return View(KullaniciDetayi);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        public ActionResult OrderHistory(int ID)//account ID
        {
            if (Session["LoginControl"] != null)
            {
               var contactID = db.Contacts.Where(t => t.AccountID == ID).SingleOrDefault().ID;
                //var OrderHistoryList = db.OrderHistory.Where(o => o.UserID == model.ID).ToList();
                var OrderHistoryList = db.Orders.Where(t => t.VehicleOrders.Count > 0 && t.ContactID == contactID).OrderByDescending(x => x.ID).ToList();
                return View(OrderHistoryList);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        public ActionResult OrderHistoryDetail(int ID)
        {
            if (Session["LoginControl"] != null)
            {

                var OrderHistoryList = db.Orders.Where(t => t.ID == ID).FirstOrDefault();

                return View(OrderHistoryList);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        public ActionResult OrderList(Nullable<int> ID)
        {
            if (Session["LoginControl"] != null)
            {
                var orderList = db.Orders.Where(t => t.VehicleOrders.Count > 0).OrderByDescending(x => x.ID).ToList();
                return View(orderList);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
    }

}