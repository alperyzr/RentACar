using Arackiralama.Models;
using Arackiralama.ViewModels.Content;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Arackiralama.Controllers
{
    public class ContentController : Controller
    {
        AracKiralamaEntities1 db = new AracKiralamaEntities1();
        public ActionResult FAQ()
        {
            int CultureID = 4;
            if (Session["culture"] == null)
            {
                Session["culture"] = "tr-TR";
                CultureID = 1;
            }
            else if (Session["culture"].ToString() == "en-GB")
            {
                CultureID = 2;
            }
            else if (Session["culture"].ToString() == "ru-RU")
            {
                CultureID = 3;

            }
            else
            {
                CultureID = 1;
            }
            string Culture = Session["culture"].ToString();


            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Culture); // de-DE
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Culture);
            var faqList = db.FAQTranslation.Where(faq => faq.IsActiive == "Aktif" && faq.CultureID == CultureID).ToList();
            return View(faqList);
        }
        
        public ActionResult Contact()
        {
            if (Session["culture"] == null)
            {
                Session["culture"] = "tr-TR";
            }
            int CultureID = 4;
            if (Session["culture"] == null)
            {
                Session["culture"] = "tr-TR";
                CultureID = 1;
            }
            else if (Session["culture"].ToString() == "en-GB")
            {
                CultureID = 2;
            }
            else if (Session["culture"].ToString() == "ru-RU")
            {
                CultureID = 3;

            }
            else
            {
                CultureID = 1;
            }
            string Culture = Session["culture"].ToString();

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Culture); // de-DE
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Culture);
            var contactList = db.ContactInfoTranslation.Where(contact => contact.IsActive == "Aktif" && contact.CultureID == CultureID).ToList();

            return View(contactList);
        }
        public ActionResult PrivacyPolicy()
        {
            if (Session["culture"] == null)
            {
                Session["culture"] = "tr-TR";
            }
            int CultureID = 4;
            if (Session["culture"] == null)
            {
                Session["culture"] = "tr-TR";
                CultureID = 1;
            }
            else if (Session["culture"].ToString() == "en-GB")
            {
                CultureID = 2;
            }
            else if (Session["culture"].ToString() == "ru-RU")
            {
                CultureID = 3;

            }
            else
            {
                CultureID = 1;
            }
            string Culture = Session["culture"].ToString();

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Culture); // de-DE
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Culture);
            var PrivacyPolicyList = db.PrivacyPolicyTranslation.Where(pp => pp.IsActive == "Aktif" && pp.CultureID == CultureID).ToList();
            return View(PrivacyPolicyList);
        }
        public PartialViewResult _KVKK()
        {
            return PartialView();
        }
        public ActionResult Blog()
        {
            if (Session["culture"] == null)
            {
                Session["culture"] = "tr-TR";
            }
            int CultureID = 4;
            if (Session["culture"] == null)
            {
                Session["culture"] = "tr-TR";
                CultureID = 1;
            }
            else if (Session["culture"].ToString() == "en-GB")
            {
                CultureID = 2;
            }
            else if (Session["culture"].ToString() == "ru-RU")
            {
                CultureID = 3;

            }
            else
            {
                CultureID = 1;
            }
            string Culture = Session["culture"].ToString();

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Culture); // de-DE
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Culture);
            var BlogList = db.Blog.Where(b => b.IsActive == "Aktif" && b.CultureID == CultureID).ToList();
            return View(BlogList);
        }

        public ActionResult BlogDetail(int? ID)
        {
            if (Session["culture"] == null)
            {
                Session["culture"] = "tr-TR";
            }
            int CultureID = 4;
            if (Session["culture"] == null)
            {
                Session["culture"] = "tr-TR";
                CultureID = 1;
            }
            else if (Session["culture"].ToString() == "en-GB")
            {
                CultureID = 2;
            }
            else if (Session["culture"].ToString() == "ru-RU")
            {
                CultureID = 3;

            }
            else
            {
                CultureID = 1;
            }
            string Culture = Session["culture"].ToString();

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Culture); // de-DE
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Culture);
            var BlogDetail = db.Blog.Where(o => o.ID == ID).SingleOrDefault();
            BlogViewModel blogviewmodel = new BlogViewModel()
            {
                ID = BlogDetail.ID,
                Title = BlogDetail.Title,
                ShowCaseDescription = BlogDetail.ShowCaseDescription,
                Date = BlogDetail.Date,
                ImageTitle = BlogDetail.ImageTitle,
                ImageURLPath = BlogDetail.ImageURL,
                CultureID = BlogDetail.CultureID,
                IsActive = BlogDetail.IsActive,
                Rank = BlogDetail.Rank,
                DescriptionCK = BlogDetail.DescriptionCK,
                blogList = db.Blog.OrderByDescending(b => b.ID == ID).Take(5).ToList(),
            };
            return View(blogviewmodel);
        }

        public ActionResult OrderManegment(string message, string SuccesMessage)
        {
            if (message != null)
            {
                ViewBag.Message = message;
            }
            if (SuccesMessage != null)
            {
                ViewBag.SuccessMessage = SuccesMessage;
            }
            return View();
        }
        [HttpPost]
        public ActionResult OrderManegment(string EPosta, string RezervasyonNo, Nullable<DateTime> TeslimAlmaTarihi)
        {

            var model = db.VehicleOrders.Where(m => m.Orders.Contacts.Email == EPosta && m.ConfirmedID == RezervasyonNo || m.Orders.Contacts.Email == EPosta && m.StartAt == TeslimAlmaTarihi).FirstOrDefault();

            if (model != null)
            {
                var result = db.Orders.Where(m => m.Identifier.ToString() == model.Identifier).FirstOrDefault();
                var vehicleInfo = db.VehicleInfo.Where(m => m.VehicleOrdersID == model.ID).FirstOrDefault();
                OrderManegmentSendMail(model, vehicleInfo);

                return RedirectToAction("OrderManegment", "Content", new { @SuccesMessage = "Siparişinizin bilgisi mail adresinize gönderilmiştir." });
            }
            else
            {
                return (RedirectToAction("OrderManegment", "Content", new { message = "Böyle bir sipariş bulunamadı. Lütfen alanları kontrol ederek tekrar deneyiniz." }));
            }

        }


        public static void OrderManegmentSendMail(VehicleOrders model, VehicleInfo vehicleInfo)
        {
            string path = System.Web.HttpContext.Current.Server.MapPath("~/Content/OrderTracking/OrderTrackingMailTemplate.html");
            string text = System.IO.File.ReadAllText(path);
            text = text.Replace("##VehicleName##", model.VehicleName);
            text = text.Replace("##CarImage##", model.ThumImage);
            if (vehicleInfo.CategoryID == 1)
            {
                text = text.Replace("##Category##", "Mini");
            }
            else if (vehicleInfo.CategoryID == 3)
            {
                text = text.Replace("##Category##", "Economy");
            }
            else if (vehicleInfo.CategoryID == 4)
            {
                text = text.Replace("##Category##", "Compact");
            }
            else if (vehicleInfo.CategoryID == 6)
            {
                text = text.Replace("##Category##", "Intermediate");
            }
            else if (vehicleInfo.CategoryID == 7)
            {
                text = text.Replace("##Category##", "Standart");
            }
            else if (vehicleInfo.CategoryID == 8)
            {
                text = text.Replace("##Category##", "FullSize");
            }
            else if (vehicleInfo.CategoryID == 9)
            {
                text = text.Replace("##Category##", "Luxary");
            }
            else if (vehicleInfo.CategoryID == 10)
            {
                text = text.Replace("##Category##", "Premium");
            }
            else if (vehicleInfo.CategoryID == 11)
            {
                text = text.Replace("##Category##", "Minivan");
            }
            else if (vehicleInfo.CategoryID == 12)
            {
                text = text.Replace("##Category##", "12 passanger van");
            }
            else if (vehicleInfo.CategoryID == 24)
            {
                text = text.Replace("##Category##", "Exotic");
            }
            else
            {
                text = text.Replace("##Category##", Arackiralama.Resources.LanguageFields.VehicleNonCategory);
            }
            text = text.Replace("##ExtraFee##", model.VehicleExtraFee);
            text = text.Replace("##StartOffice##", model.StartOfficeName + " " + model.StartAt.ToString("dd.MM.yyyy"));
            text = text.Replace("##TotalPrice##", model.TotalRate.ToString());
            text = text.Replace("##Currency##", model.Currencies.Name);
            text = text.Replace("##PassengerCount##", vehicleInfo.PassengerCount);
            text = text.Replace("##BaggageCount##", vehicleInfo.BaggageCount);
            text = text.Replace("##DoorCount##", vehicleInfo.DoorCount);
            text = text.Replace("##VehicleCharges##", vehicleInfo.VehicleCharges.ToString());
            text = text.Replace("##PricedCoverages##", vehicleInfo.PricedCoverages.ToString());
            if (vehicleInfo.AirConditionInd == true)
            {
                text = text.Replace("##AirConditionInd##", "Klima");
            }

            text = text.Replace("##FuelPolicy##", vehicleInfo.FuelType);

            MailMessage msg = new MailMessage();

            msg.From = new MailAddress("alper.yazir@demircode.com");
            msg.To.Add(model.Orders.Contacts.Email);
            msg.Subject = "aracvararac.com Sipariş Takip Maili";
            msg.Body = text;
            msg.IsBodyHtml = true;
            msg.Priority = MailPriority.High;


            using (SmtpClient client = new SmtpClient())
            {
                string mail = ConfigurationManager.AppSettings["mailMessageFrom"];
                string password = ConfigurationManager.AppSettings["mailMessagePassword"];
                string Host = ConfigurationManager.AppSettings["mailMessageHost"];
               
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(mail, password);
                client.Host = Host;
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                client.Send(msg);

            }

        }


    }
}