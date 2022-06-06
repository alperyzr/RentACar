using Arackiralama.Models;
using Arackiralama.ViewModels.Content;
using System;
using System.Collections.Generic;
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
    public class ContentController : Controller
    {
        AracKiralamaEntities1 db = new AracKiralamaEntities1();
        public ActionResult ContactList(string message)
        {
            if (Session["LoginControl"] != null)
            {
                if (message != null)
                {
                    ViewBag.Message = message;
                }
                var contentList = db.ContactInfoTranslation.OrderByDescending(x => x.ID).ToList();
                return View(contentList);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }

        }
        public ActionResult ContactCreate(ContactInfoTranslation model, string message)
        {
            if (Session["LoginControl"] != null)
            {
                if (message != null)
                {
                    ViewBag.Message = message;
                }
                if (model.ID > 0)
                {

                    model.cultureList = db.Cultures.Where(c => c.IsActive == "Aktif").ToList();
                    ContactInfoTranslation result = new Models.ContactInfoTranslation();
                    result.cultureList = model.cultureList;
                    result.CultureID = model.cultureList.FirstOrDefault().ID;
                    result.cultureList = model.cultureList;

                    result.cultureList = model.cultureList;
                    result.ContactInfoID = model.ContactInfoID;
                    result.Title = model.Title;
                    result.Explanation = model.Explanation;
                    result.IsActive = model.IsActive;

                    return View(result);
                }
                else
                {
                    model.cultureList = db.Cultures.ToList();
                    return View(model);
                }

            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        [HttpPost]
        public ActionResult ContactCreate(ContactInfoTranslation model)
        {
            if (model.ID == 0)
            {
                ContactInfo contactınfo = new ContactInfo()
                {

                    CreatedAt = DateTime.Now,
                    CreatedBy = "Admin"
                };

                db.ContactInfo.Add(contactınfo);
                model.ContactInfoID = contactınfo.ID;


                db.ContactInfoTranslation.Add(model);
                db.SaveChanges();
                return RedirectToAction("ContactCreate", "Content", new { message = "Kayıt Başarıyla Eklendi" });
            }
            else
            {
                var result = db.ContactInfoTranslation.Where(c => c.ContactInfoID == model.ContactInfoID).SingleOrDefault();
                result.ContactInfo.UpdatedAt = DateTime.Now;
                result.ContactInfo.UpdatedBy = "Admin";
                result.IsActive = model.IsActive;
                result.CultureID = model.CultureID;
                result.Title = model.Title;
                result.Explanation = model.Explanation;
                result.IsActive = model.IsActive;
                db.SaveChanges();
                return RedirectToAction("ContactList", "Content", new { message = "Kayıt başarıyla Güncellendi" });
            }
        }
        public ActionResult ContactEdit(ContactInfoTranslation result)
        {
            if (Session["LoginControl"] != null)
            {
                var model = db.ContactInfoTranslation.Where(c => c.ID == result.ID).SingleOrDefault();
                var returnmodel = db.ContactInfoTranslation.Where(m => m.ContactInfoID == model.ContactInfoID).SingleOrDefault();
                return RedirectToAction("ContactCreate", "Content", model);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        public ActionResult FAQList(string message)
        {
            if (Session["LoginControl"] != null)
            {
                if (message != null)
                {
                    ViewBag.Message = message;
                }
                var faqList = db.FAQTranslation.OrderByDescending(x => x.ID).ToList();
                return View(faqList);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        public ActionResult FAQCreate(FAQTranslation model, string message)
        {
            if (Session["LoginControl"] != null)
            {
                if (message != null)
                {
                    ViewBag.Message = message;
                }
                if (model.ID > 0)
                {
                    model.cultureList = db.Cultures.Where(c => c.IsActive == "Aktif").ToList();

                    FAQTranslation result = new Models.FAQTranslation();

                    result.cultureList = model.cultureList;
                    result.CultureID = model.cultureList.FirstOrDefault().ID;
                    result.cultureList = model.cultureList;
                    result.FAQID = model.FAQID;
                    result.Answer = model.Answer;
                    result.Question = model.Question;
                    result.IsActiive = model.IsActiive;

                    return View(result);
                }
                else
                {
                    model.cultureList = db.Cultures.ToList();
                    return View(model);
                }

            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        [HttpPost]
        public ActionResult FAQCreate(FAQTranslation model)
        {
            if (model.ID == 0)
            {
                FAQ faq = new FAQ()
                {

                    CreatedAt = DateTime.Now,
                    CreatedBy = "Admin"
                };

                db.FAQ.Add(faq);
                model.FAQID = faq.ID;


                db.FAQTranslation.Add(model);
                db.SaveChanges();
                return RedirectToAction("FAQCreate", "Content", new { message = "Kayıt Başarıyla Eklendi" });
            }
            else
            {
                var result = db.FAQTranslation.Where(c => c.FAQID == model.FAQID).SingleOrDefault();
                result.FAQ.UpdatedAt = DateTime.Now;
                result.FAQ.UpdatedBy = "Admin";
                result.CultureID = model.CultureID;
                result.IsActiive = model.IsActiive;
                result.Answer = model.Answer;
                result.Question = model.Question;

                db.SaveChanges();
                return RedirectToAction("FAQList", "Content", new { message = "Kayıt başarıyla Güncellendi" });
            }
        }
        public ActionResult FAQEdit(FAQTranslation result)
        {
            if (Session["LoginControl"] != null)
            {
                var model = db.FAQTranslation.Where(c => c.ID == result.ID).SingleOrDefault();
                var returnmodel = db.FAQTranslation.Where(m => m.FAQID == model.FAQID).SingleOrDefault();
                return RedirectToAction("FAQCreate", "Content", model);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        public ActionResult PrivacyPolicyList(string message)
        {
            if (Session["LoginControl"] != null)
            {
                if (message != null)
                {
                    ViewBag.Message = message;
                }
                var privacy = db.PrivacyPolicyTranslation.OrderByDescending(x => x.ID).ToList();
                return View(privacy);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        public ActionResult PrivacyPolicyCreate(PrivacyPolicyTranslation model, string message)
        {
            if (Session["LoginControl"] != null)
            {
                if (message != null)
                {
                    ViewBag.Message = message;
                }
                if (model.ID > 0)
                {
                    var model2 = db.PrivacyPolicyTranslation.Where(mdl2 => mdl2.ID == model.ID).SingleOrDefault();
                    model.cultureList = db.Cultures.Where(m => m.ID == model2.CultureID).ToList();
                    var result = db.PrivacyPolicyTranslation.Where(pp => pp.ID == model.ID).SingleOrDefault();

                    result.CultureID = result.CultureID;
                    result.cultureList = model.cultureList;
                    result.PrivacyPolicyID = result.PrivacyPolicyID;
                    result.Title = result.Title;
                    result.Explanation = result.Explanation;
                    result.IsActive = result.IsActive;

                    return View(result);
                }
                else
                {
                    model.cultureList = db.Cultures.Where(c => c.IsActive == "Aktif").ToList();
                    return View(model);
                }
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        [HttpPost]
        public ActionResult PrivacyPolicyCreate(PrivacyPolicyTranslation model)
        {
            if (model.ID == 0)
            {
                PrivacyPolicy pp = new PrivacyPolicy()
                {

                    CreatedAt = DateTime.Now,
                    CreatedBy = "Admin"
                };

                db.PrivacyPolicy.Add(pp);
                model.PrivacyPolicyID = pp.ID;


                db.PrivacyPolicyTranslation.Add(model);
                db.SaveChanges();
                return RedirectToAction("PrivacyPolicyCreate", "Content", new { message = "Kayıt Başarıyla Eklendi" });
            }
            else
            {
                var result = db.PrivacyPolicyTranslation.Where(c => c.PrivacyPolicyID == model.PrivacyPolicyID).SingleOrDefault();
                result.PrivacyPolicy.UpdatedAt = DateTime.Now;
                result.PrivacyPolicy.UpdatedBy = "Admin";
                result.IsActive = model.IsActive;
                result.Title = model.Title;
                result.Explanation = model.Explanation;

                db.SaveChanges();
                return RedirectToAction("PrivacyPolicyList", "Content", new { message = "Kayıt başarıyla Güncellendi" });
            }
        }
        public ActionResult PrivacyPolicyEdit(PrivacyPolicyTranslation result)
        {
            if (Session["LoginControl"] != null)
            {
                var model = db.PrivacyPolicyTranslation.Where(c => c.ID == result.ID).SingleOrDefault();

                //return RedirectToAction("PrivacyPolicyCreate", "Content", model.ID);
                return RedirectToAction("PrivacyPolicyCreate", new RouteValueDictionary(
    new { controller = "Content", action = "PrivacyPolicyCreate", Id = model.ID }));
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        public ActionResult LanguageList(string message)
        {
            if (Session["LoginControl"] != null)
            {
                if (message != null)
                {
                    ViewBag.Message = message;
                }
                var privacy = db.Cultures.OrderByDescending(x => x.ID).ToList();
                return View(privacy);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        public ActionResult LanguageCreate(Cultures cultures, string message)
        {
            if (Session["LoginControl"] != null)
            {
                if (message != null)
                {
                    ViewBag.Message = message;
                }
                if (cultures.ID > 0)
                {


                    Cultures result = new Models.Cultures();

                    result.Code = cultures.Code;
                    result.Name = cultures.Name;
                    result.IsDefault = cultures.IsDefault;
                    result.IsActive = cultures.IsActive;


                    return View(result);
                }
                else
                {

                    return View(cultures);
                }
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        [HttpPost]
        public ActionResult LanguageCreate(Cultures model)
        {
            if (model.ID == 0)
            {


                model.CurrencyID = 1;
                model.Currency_ID = 1;
                db.Cultures.Add(model);
                db.SaveChanges();
                return RedirectToAction("LanguageCreateCreate", "Content", new { message = "Kayıt Başarıyla Eklendi" });
            }
            else
            {
                var result = db.Cultures.Where(c => c.ID == model.ID).SingleOrDefault();

                result.Code = model.Code;
                result.Name = model.Name;
                result.IsDefault = model.IsDefault;
                result.IsActive = model.IsActive;

                result.IsDefault = model.IsDefault;

                db.SaveChanges();
                return RedirectToAction("LanguageList", "Content", new { message = "Kayıt başarıyla Güncellendi" });
            }
        }
        public ActionResult LanguageEdit(Cultures result)
        {
            if (Session["LoginControl"] != null)
            {
                var model = db.Cultures.Where(c => c.ID == result.ID).SingleOrDefault();

                return RedirectToAction("LanguageCreate", "Content", model);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        public ActionResult BlogList(string message)
        {
            if (Session["LoginControl"] != null)
            {
                if (message != null)
                {
                    ViewBag.Message = message;
                }
                var blogList = db.Blog.OrderByDescending(x => x.ID).ToList();
                return View(blogList);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        [ValidateInput(false)]
        public ActionResult BlogCreate(BlogViewModel model,Blog blog, string message)
        {
            if (Session["LoginControl"] != null)
            {
                if (message != null)
                {
                    ViewBag.Message = message;
                }
                if (model.ID > 0)
                {

                    model.cultureList = db.Cultures.Where(c => c.IsActive == "Aktif").ToList();
                    var result = db.Blog.Where(r => r.ID == model.ID).SingleOrDefault();
                    BlogViewModel blogviewmodel = new BlogViewModel();
                    blogviewmodel.cultureList = model.cultureList;
                    blogviewmodel.CultureID = model.cultureList.FirstOrDefault().ID;
                    blogviewmodel.cultureList = model.cultureList;
                    blogviewmodel.ImageTitle = result.ImageTitle;
                    blogviewmodel.Title = result.Title;
                    blogviewmodel.Date = result.Date;
                    blogviewmodel.DescriptionCK = result.DescriptionCK;
                    blogviewmodel.ImageURLPath = result.ImageURL;
                    blogviewmodel.ShowCaseDescription = result.ShowCaseDescription;
                    blogviewmodel.Rank = result.Rank;                    
                    blogviewmodel.IsActive = model.IsActive;

                    return View(blogviewmodel);
                }
                else
                {
                    model.cultureList = db.Cultures.Where(c => c.IsActive == "Aktif").ToList();
                    return View(model);
                }

            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult BlogCreate(BlogViewModel model, Blog result)
        {
            if (model.ID == 0)
            {
                if (Path.GetExtension(model.ImageURL.FileName) == ".jpg" || Path.GetExtension(model.ImageURL.FileName) == ".JPG" || Path.GetExtension(model.ImageURL.FileName) == ".png" || Path.GetExtension(model.ImageURL.FileName) == ".PNG")
                {

                    MemoryStream target = new MemoryStream();
                    model.ImageURL.InputStream.CopyTo(target);
                    model.IconByte = target.ToArray();
                    model.IconExtension = Path.GetExtension(model.ImageURL.FileName);
                    model.ImageURL = null;
                    string ImageName = NameSeoReplace(model.Title) + "-avatar-" + Guid.NewGuid().ToString().Substring(0, 8) + model.IconExtension;
                    int imageresult = SaveImage(model.IconByte, ImageName, "Blog");
                    Blog b = new Blog()
                    {
                        ImageTitle = result.ImageTitle,
                        Title = result.Title,
                        Rank = result.Rank,
                        ShowCaseDescription = result.ShowCaseDescription,
                        Date = result.Date,
                        ImageURL = "/Upload/Blog/" + ImageName,
                        CreatedAt = DateTime.Now,
                        CreatedBy = "Admin",
                        DescriptionCK = result.DescriptionCK,
                        CultureID = result.CultureID,

                        IsActive = result.IsActive,


                    };

                    db.Blog.Add(b);
                    db.SaveChanges();
                    return RedirectToAction("BlogCreate", "Content", new { message = "Kayıt Başarıyla Eklendi" });
                }
                else
                {
                    ViewBag.Message = "Beklenmedik Bir Hata Oluştu";
                    return View();
                }

            }

            else
            {
                MemoryStream target = new MemoryStream();
                string ImageName = "";
                if (model.ImageURL != null)
                {
                    model.ImageURL.InputStream.CopyTo(target);
                    model.IconByte = target.ToArray();
                    model.IconExtension = Path.GetExtension(model.ImageURL.FileName);
                    model.ImageURL = null;
                    ImageName = NameSeoReplace(model.Title) + "-avatar-" + Guid.NewGuid().ToString().Substring(0, 8) + model.IconExtension;
                    int imageresult = SaveImage(model.IconByte, ImageName, "Blog");
                }

                var EditUser = db.Blog.Where(x => x.ID == result.ID).SingleOrDefault();
                EditUser.Title = result.Title;
                EditUser.ImageTitle = result.ImageTitle;
                EditUser.DescriptionCK = result.DescriptionCK;
                EditUser.ShowCaseDescription = result.ShowCaseDescription;
                EditUser.UpdatedAt = DateTime.Now;
                EditUser.Date = result.Date;
                EditUser.Rank = result.Rank;
                if (ImageName != null && ImageName.ToString() != "")
                {
                    EditUser.ImageURL = "/Upload/Blog/" + ImageName;
                }
                if (model.ImageURL == null)
                {
                    EditUser.ImageURL = EditUser.ImageURL;
                }
                EditUser.CultureID = result.CultureID;

                EditUser.UpdatedBy = "Admin";

                EditUser.IsActive = result.IsActive;


                db.SaveChanges();
                return RedirectToAction("BlogList", "Content", new { message = "Kayıt Başarıyla Güncellendi" });


            }

        }
        public ActionResult BlogEdit(BlogViewModel result)
        {
            if (Session["LoginControl"] != null)
            {
                var model = db.Blog.Where(c => c.ID == result.ID).SingleOrDefault();
                
                return RedirectToAction("BlogCreate", "Content", new { ID = model.ID });
            }
            else
            {
                return RedirectToAction("Login", "Admin");
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