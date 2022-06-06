using Arackiralama.Models;
using Arackiralama.ViewModels.Company;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Arackiralama.Areas.Admin.Controllers
{
    public class CompanyController : Controller
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
                var CompanyList = db.Company.OrderByDescending(x => x.ID).ToList();
                return View(CompanyList);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        public ActionResult Create(Company CompanyEdit, string message)
        {
            if (Session["LoginControl"] != null)
            {
                CreateCompanyModel result = new CreateCompanyModel();
                if (message != null)
                {
                    ViewBag.Message = message;
                }
                if (CompanyEdit.ID > 0)
                {

                    result.ImageUrl = CompanyEdit.Logo;
                    result.SirketAdi = CompanyEdit.SirketAdi;
                    result.TicariUnvani = CompanyEdit.TicariUnvani;
                    result.VergiDairesi = CompanyEdit.VergiDairesi;
                    result.VergiNo = CompanyEdit.VergiNo;
                    result.SirketTuru = CompanyEdit.SirketTuru;
                    return View(result);
                }
                return View(result);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        [HttpPost]
        public ActionResult Create(CreateCompanyModel model)
        {
            if (model.ID == 0)
            {
                if (Path.GetExtension(model.Logo.FileName) == ".jpg" || Path.GetExtension(model.Logo.FileName) == ".JPG" || Path.GetExtension(model.Logo.FileName) == ".png" || Path.GetExtension(model.Logo.FileName) == ".PNG")
                {

                    MemoryStream target = new MemoryStream();
                    model.Logo.InputStream.CopyTo(target);
                    model.IconByte = target.ToArray();
                    model.IconExtension = Path.GetExtension(model.Logo.FileName);
                    model.Logo = null;
                    string ImageName = NameSeoReplace(model.SirketAdi) + "-logo-" + Guid.NewGuid().ToString().Substring(0, 8) + model.IconExtension;
                    int imageresult = SaveImage(model.IconByte, ImageName, "Logo");

                    Company c = new Company
                    {

                        Logo = "/Upload/Logo/" + ImageName,
                        EklendigiTarih = DateTime.Now,
                        SirketAdi = model.SirketAdi,
                        IsActive = model.IsActive,
                        SirketSahibi = model.SirketSahibi,
                        SirketTuru = model.SirketTuru,
                        TicariUnvani = model.TicariUnvani,
                        VergiDairesi = model.VergiDairesi,
                        VergiNo = model.VergiNo
                    };
                    db.Company.Add(c);
                    db.SaveChanges();
                    return RedirectToAction("Create", "Company", new { message = "Kayıt Başarıyla Eklendi" });

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
                if (model.Logo!=null)
                {
                    model.Logo.InputStream.CopyTo(target);
                    model.IconByte = target.ToArray();
                    model.IconExtension = Path.GetExtension(model.Logo.FileName);
                    model.Logo = null;
                    ImageName = NameSeoReplace(model.SirketAdi) + "-logo-" + Guid.NewGuid().ToString().Substring(0, 8) + model.IconExtension;
                    int imageresult = SaveImage(model.IconByte, ImageName, "Logo");
                }

                var EditCompany = db.Company.Where(company => company.ID == model.ID).SingleOrDefault();
                EditCompany.GuncellendigiTarih = DateTime.Now;
                EditCompany.GuncelleyenKisi = "Admin";
                EditCompany.IsActive = model.IsActive;
                if (ImageName!=null)
                {
                    EditCompany.Logo = "/Upload/Logo/"+ImageName;
                }
                EditCompany.SirketAdi = model.SirketAdi;
                EditCompany.SirketSahibi = model.SirketSahibi;
                EditCompany.SirketTuru = model.SirketTuru;
                EditCompany.TicariUnvani = model.TicariUnvani;
                EditCompany.VergiDairesi = model.VergiDairesi;
                EditCompany.VergiNo = model.VergiNo;
               
                db.SaveChanges();
                return RedirectToAction("List", "Company", new { message = "Kayıt Başarıyla Güncellendi" });
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
        public ActionResult Detail(int ID)
        {
            if (Session["LoginControl"] != null)
            {
                var CompanyDetail = db.Company.Where(c => c.ID == ID).SingleOrDefault();
                return View(CompanyDetail);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        public ActionResult Edit(CreateCompanyModel model)
        {
            if (Session["LoginControl"] != null)
            {
                var CompanyEdit = db.Company.Where(c => c.ID == model.ID).SingleOrDefault();
                return RedirectToAction("Create", "Company", CompanyEdit);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
    }
}