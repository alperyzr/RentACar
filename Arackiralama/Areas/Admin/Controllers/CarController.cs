using Arackiralama.Models;
using Arackiralama.ViewModels.Car;
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
    public class CarController : Controller
    {
        AracKiralamaEntities1 db = new AracKiralamaEntities1();
        public ActionResult List(string message)
        {
            if (Session["LoginControl"] != null)
            {
                if (message != null)
                {
                    ViewBag.Message = message;
                }
                var CarList = db.Car.OrderByDescending(x => x.ID).ToList();
                return View(CarList);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        public ActionResult Create(Car editCar, string message)
        {
            if (Session["LoginControl"] != null)
            {
                CarViewModel result = new ViewModels.Car.CarViewModel();
                if (message != null)
                {
                    ViewBag.Message = message;
                }
                if (editCar.ID.ToString() != "00000000-0000-0000-0000-000000000000")
                {
                    result.ImageUrl = editCar.Resim;
                    result.Marka = editCar.Marka;
                    result.Segment = editCar.Segment;
                    result.Sinif = editCar.Sinif;
                    result.Sanzuman = editCar.Sanzuman;
                    result.YakitTuru = editCar.YakitTuru;
                    result.CarPoitScaleID = editCar.CarPoitScaleID;
                    result.CarExtraMaterialID = editCar.CarExtraMaterialID;
                    result.BagajKapasitesi = editCar.BagajKapasitesi;
                    result.KisiSayisi = editCar.KisiSayisi;
                    result.KapiSaysi = editCar.KapiSaysi;
                    result.IsActive = editCar.IsActive;
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
        public ActionResult Create(CarViewModel result)
        {
            if (Session["LoginControl"] != null)
            {
                if (result.ID.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    if (Path.GetExtension(result.Resim.FileName) == ".jpg" || Path.GetExtension(result.Resim.FileName) == ".JPG" || Path.GetExtension(result.Resim.FileName) == ".png" || Path.GetExtension(result.Resim.FileName) == ".PNG")
                    {

                        MemoryStream target = new MemoryStream();
                        result.Resim.InputStream.CopyTo(target);
                        result.IconByte = target.ToArray();
                        result.IconExtension = Path.GetExtension(result.Resim.FileName);
                        result.Resim = null;
                        string ImageName = NameSeoReplace(result.Marka) + "-marka-" + Guid.NewGuid().ToString().Substring(0, 8) + result.IconExtension;
                        int imageresult = SaveImage(result.IconByte, ImageName, "Car");

                        Car c = new Car
                        {
                            ID = Guid.NewGuid(),
                            BagajKapasitesi = result.BagajKapasitesi,
                            Marka = result.Marka,
                            Sanzuman = result.Sanzuman,
                            Segment = result.Segment,
                            Sinif = result.Sinif,
                            YakitTuru = result.YakitTuru,
                            Model = result.Model,
                            KisiSayisi = result.KisiSayisi,
                            KapiSaysi = result.KapiSaysi,
                            KiralamaTutari = result.KiralamaTutari,
                            EklendigiTarih = DateTime.Now,
                            EkleyenKisi = "Admin",
                            IsActive = result.IsActive,
                            CompanyID = result.CompanyID,
                            CarPoitScaleID = result.CarPoitScaleID,
                            Resim = "/Upload/Car/" + ImageName

                        };
                        db.Car.Add(c);
                        db.SaveChanges();
                        return RedirectToAction("Create", "Car", new { message = "Kayıt başarıyla Eklendi." });
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
                    if (result.Resim != null)
                    {
                        result.Resim.InputStream.CopyTo(target);
                        result.IconByte = target.ToArray();
                        result.IconExtension = Path.GetExtension(result.Resim.FileName);
                        result.Resim = null;
                        ImageName = NameSeoReplace(result.Marka) + "-marka-" + Guid.NewGuid().ToString().Substring(0, 8) + result.IconExtension;
                        int imageresult = SaveImage(result.IconByte, ImageName, "Car");
                    }

                    var EditCar = db.Car.Where(car => car.ID == result.ID).SingleOrDefault();
                    result.CompanyID = EditCar.CompanyID;
                    if (ImageName != null)
                    {

                    }
                    EditCar.Resim = "/Upload/Car/" + ImageName;
                    EditCar.Marka = result.Marka;
                    EditCar.Model = result.Model;
                    EditCar.Segment = result.Segment;
                    EditCar.Sinif = result.Sinif;
                    EditCar.Sanzuman = result.Sanzuman;
                    EditCar.YakitTuru = result.YakitTuru;
                    EditCar.CarExtraMaterialID = result.CarExtraMaterialID;
                    EditCar.KapiSaysi = result.KapiSaysi;
                    EditCar.KiralamaTutari = result.KiralamaTutari;
                    EditCar.IsActive = result.IsActive;
                    EditCar.GuncellendigiTarih = DateTime.Now;
                    db.SaveChanges();
                    return RedirectToAction("List", "Car", new { message = "Kayıt Başarıyla Güncellendi" });



                }
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        public ActionResult Edit(CarViewModel result)
        {
            if (Session["LoginControl"] != null)
            {
                var editCar = db.Car.Where(c => c.ID == result.ID).SingleOrDefault();
                return RedirectToAction("Create", "Car", editCar);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        public ActionResult Detail(Car model)
        {
            if (Session["LoginControl"] != null)
            {
                var carDetail = db.Car.Where(c => c.ID == model.ID).SingleOrDefault();
                return View(carDetail);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        public ActionResult CarPointList(string message)
        {
            if (Session["LoginControl"] != null)
            {
                if (message != null)
                {
                    ViewBag.Message = message;
                }
                var PointList = db.CarPointScale.OrderByDescending(x => x.ID).ToList();
                return View(PointList);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        public ActionResult CarPointCreate(CarPointScale model, string message)
        {
            if (Session["LoginControl"] != null)
            {
                if (message != null)
                {
                    ViewBag.Message = message;
                }
                if (model.ID > 0)
                {
                    CarPointScale result = new Models.CarPointScale();
                    result.PuanAraligi = model.PuanAraligi;
                    result.PuanIfadesi = model.PuanIfadesi;
                    return View(result);
                }
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        [HttpPost]
        public ActionResult CarPointCreate(CarPointScale model)
        {
            if (model.ID == 0)
            {
                db.CarPointScale.Add(model);
                db.SaveChanges();
                return RedirectToAction("CarPointCreate", "Car", new { message = "İşlem Başarıyla Eklendi" });
            }
            else
            {


                var carPointScaleCreate = db.CarPointScale.Where(c => c.ID == model.ID).SingleOrDefault();
                carPointScaleCreate.PuanAraligi = model.PuanAraligi;
                carPointScaleCreate.PuanIfadesi = model.PuanIfadesi;
                db.SaveChanges();
                return RedirectToAction("CarPointList", "Car", new { message = "İşlem Bşarıyla Güncellendi" });
            }
        }
        public ActionResult CarPointEdit(CarPointScale model)
        {
            if (Session["LoginControl"] != null)
            {
                var result = db.CarPointScale.Where(m => m.ID == model.ID).SingleOrDefault();
                return RedirectToAction("CarPointCreate", "Car", result);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        public ActionResult ExtraMaterialList(string message)
        {
            if (Session["LoginControl"] != null)
            {
                if (message != null)
                {
                    ViewBag.Message = message;
                }
                var ExtraMaterialList = db.ExtraMaterial.OrderByDescending(x => x.ID).ToList();
                return View(ExtraMaterialList);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        public ActionResult ExtraMaterialCreate(ExtraMaterial model, string message)
        {
            if (Session["LoginControl"] != null)
            {
                ExtraMaterialViewModel result = new ViewModels.Car.ExtraMaterialViewModel();
                if (message != null)
                {
                    ViewBag.Message = message;
                }
                if (model.ID > 0)
                {

                    result.ImageUrl = model.Icon;
                    result.Materyal = model.Materyal;
                    result.Aciklama = model.Aciklama;
                    result.MinDeger = model.MinDeger;
                    result.MaxDeger = model.MaxDeger;
                    result.IsActive = model.IsActive;
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
        public ActionResult ExtraMaterialCreate(ExtraMaterialViewModel model)
        {
            if (model.ID == 0)
            {
                if (Path.GetExtension(model.Icon.FileName) == ".jpg" || Path.GetExtension(model.Icon.FileName) == ".JPG" || Path.GetExtension(model.Icon.FileName) == ".png" || Path.GetExtension(model.Icon.FileName) == ".PNG")
                {

                    MemoryStream target = new MemoryStream();
                    model.Icon.InputStream.CopyTo(target);
                    model.IconByte = target.ToArray();
                    model.IconExtension = Path.GetExtension(model.Icon.FileName);
                    model.Icon = null;
                    string ImageName = NameSeoReplace(model.Materyal) + "-materyal-" + Guid.NewGuid().ToString().Substring(0, 8) + model.IconExtension;
                    int imageresult = SaveImage(model.IconByte, ImageName, "Materyal");

                    ExtraMaterial materytal = new ExtraMaterial
                    {
                        Icon = "/Upload/ExtraMaterial/" + ImageName,
                        Materyal = model.Materyal,
                        Aciklama = model.Aciklama,
                        EklendigiTarih = DateTime.Now,
                        EkleyenKisi = "Admin",
                        IsActive = model.IsActive,
                        MaxDeger = model.MaxDeger,
                        MinDeger = model.MinDeger

                    };
                    db.ExtraMaterial.Add(materytal);
                    db.SaveChanges();
                    return RedirectToAction("ExtraMaterialCreate", "Car", new { message = "Kayıt Başarıyla Eklendi" });

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
                if (model.Icon != null)
                {
                    model.Icon.InputStream.CopyTo(target);
                    model.IconByte = target.ToArray();
                    model.IconExtension = Path.GetExtension(model.Icon.FileName);
                    model.Icon = null;
                    ImageName = NameSeoReplace(model.Materyal) + "-materyal-" + Guid.NewGuid().ToString().Substring(0, 8) + model.IconExtension;
                    int imageresult = SaveImage(model.IconByte, ImageName, "ExtraMaterial");
                }
                var ExtraMaterialEdit = db.ExtraMaterial.Where(ex => ex.ID == model.ID).SingleOrDefault();
                if (ImageName != null)
                {
                    ExtraMaterialEdit.Icon = "/Upload/ExtraMaterial/" + ImageName;
                }

                ExtraMaterialEdit.Materyal = model.Materyal;
                ExtraMaterialEdit.Aciklama = model.Aciklama;
                ExtraMaterialEdit.IsActive = model.IsActive;
                ExtraMaterialEdit.MinDeger = model.MinDeger;
                ExtraMaterialEdit.MaxDeger = model.MaxDeger;
                ExtraMaterialEdit.GuncellemeTarihi = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("ExtraMaterialList", "Car", new { message = "Kayıt başarıyla Güncellendi" });

            }
        }
        public ActionResult ExtraMaterialEdit(ExtraMaterial model)
        {
            if (Session["LoginControl"] != null)
            {
                var ExtraMaterialEdit = db.ExtraMaterial.Where(ex => ex.ID == model.ID).SingleOrDefault();
                return RedirectToAction("ExtraMaterialCreate", "Car", ExtraMaterialEdit);
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