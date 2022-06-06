using Arackiralama.Models;
using Arackiralama.Cartrawler;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Xml;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Configuration;
using Arackiralama.Models.Vehicle;

namespace Arackiralama.Controllers
{
    //public class MyHttpProtocol : System.Web.Services.Protocols.SoapHttpClientProtocol
    //   {
    //	public override System.Net.WebRequest base.GetWebRequest(Uri uri)
    //	{
    //           // Base request:
    //           System.Net.WebRequest request = base.GetWebRequest(uri);

    //		// You code goes here...

    //		// Return...
    //		return request;
    //	}
    //}
    public class CarController : MainController
    {

        //Session["culture"]
        private AracKiralamaEntities1 _dbContext = null;
        public VehicleInfo vehicleInfo = new VehicleInfo();
        public AracKiralamaEntities1 dbContext
        {
            get
            {
                return _dbContext;
            }
        }
        public AracKiralamaEntities1 db = new AracKiralamaEntities1();
        public ActionResult CultureChange(string Culture)
        {

            //         if (Culture=="TR")
            //         {
            //	Culture = "tr-TR";

            //}
            //         else
            //         {
            //	Culture = "en-EN";
            //}
            Session["culture"] = Culture;

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Culture); // de-DE
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Culture);

            return RedirectToAction("Index", "Car");
        }
        public ActionResult CurrencyChange(string Currency)
        {
            Session["currency"] = Currency;
            ViewBag.Currency = Currency;// "TRY";
            return RedirectToAction("Index", "Car");
        }
        // GET: Car1
        public ActionResult Index(bool? isFirstCheck,string message)
        {
            if (message!=null)
            {
                ViewBag.Message = message;
            }
            if (isFirstCheck == true)
            {
                ViewBag.IsOpenModal = true;
            }
            //Mail.MailSender();


            //const string mailMessageFrom = "info@plazaplus.com.tr";
            //const string mailMessagePassword = "kopyalandıvbdufomzzexmxfjm";
            //const string mailMessageHost = "smtp.yandex.com";
            //const int mailMessagePort = 25;
            //string mailMessageTo = "blgsyrmhnds@gmail.com";
            //string messageBody = "tesmessageBodyt";
            //var messageSubject = "messageSubject";

            //var messageSender = new MessageSender();
            //messageSender.SendMail(mailMessageFrom, mailMessagePassword, mailMessageHost, mailMessagePort, mailMessageTo, messageBody, messageSubject);


            ViewBag.Culture = "tr";


            string Culture = "tr-TR";
            if (Session["culture"] != null)
            {
                Culture = Session["culture"].ToString();
            }
            else
            {
                Session["culture"] = Culture;

            }

            if (string.IsNullOrEmpty(ViewBag.Currency))
            {
                ViewBag.Currency = "TRY";
            }
            if (Session["currency"] == null)
            {
                Session["currency"] = "TRY";
            }


            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Culture); // de-DE
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Culture);
            return View();
        }
        public ActionResult Index1()
        {
            return View();
        }

        #region açıklama
        //     public ActionResult CarList(VehicleSearchModel vehicleSearchModel)
        //     {
        //try
        //{
        //	//using (var db = new TourismContext())
        //	//{
        //	//	var logRec = db.UserSearchLogs.Create();
        //	//	logRec.InsertedDate = DateTime.Now;

        //	//	string address1 = db.Regions.FirstOrDefault(r => r.RefID == vehicleSearchModel.StartRegionID).Translations.First().Name;
        //	//	string address2 = db.Regions.FirstOrDefault(r => r.RefID == vehicleSearchModel.EndRegionID).Translations.First().Name;

        //	//	logRec.LogType = 4;
        //	//	logRec.ReturnCity = address2;
        //	//	logRec.LeaveCity = address1;
        //	//	logRec.StartAt = (DateTime)vehicleSearchModel.StartAt;
        //	//	logRec.EndAt = vehicleSearchModel.EndAt;
        //	//	db.UserSearchLogs.Add(logRec);
        //	//	db.SaveChanges();
        //	//}

        //	Session["ErrorMessage-Vehicle"] = null;
        //	vehicleSearchModel.Currency = ViewBag.Currency;

        //	string startDate = vehicleSearchModel.StartAt.ToString("yyyy-MM-dd");
        //	string endDate = vehicleSearchModel.EndAt.ToString("yyyy-MM-dd");

        //	vehicleSearchModel.StartRegion = dbContext.RegionTranslations.FirstOrDefault(t => t.CultureID == currentCulture.ID && t.Region.RefID == vehicleSearchModel.StartRegionID);
        //	vehicleSearchModel.EndRegion = dbContext.RegionTranslations.FirstOrDefault(t => t.CultureID == currentCulture.ID && t.Region.RefID == vehicleSearchModel.EndRegionID);
        //	vehicleSearchModel.VehicleList = new List<VehicleModel>();
        //	vehicleSearchModel.Currency = ViewBag.Currency;

        //	string path = System.Configuration.ConfigurationManager.AppSettings["CarPath"] + "detailService.xsd";
        //	string readText = System.IO.File.ReadAllText(path);


        //	string Deger = readText.Replace("\\", string.Empty);

        //	Deger = Deger.Replace("<?StartDate?>", startDate + "T" + vehicleSearchModel.StartTimeHour + ":00");
        //	Deger = Deger.Replace("<?EndDate?>", endDate + "T" + vehicleSearchModel.EndTimeHour + ":00");

        //	Deger = Deger.Replace("<?StartLocation?>", vehicleSearchModel.StartRegionID.ToString());
        //	Deger = Deger.Replace("<?ReturnLocation?>", vehicleSearchModel.EndRegionID.ToString());

        //	Deger = Deger.Replace("<?Culture?>", currentCulture.Code);

        //	Deger = Deger.Replace("<?Currency?>", vehicleSearchModel.Currency);

        //	Deger = Deger.Replace("<?Country?>", vehicleSearchModel.Country == null ? "TR" : vehicleSearchModel.Country);

        //	if (Request.ServerVariables != null)
        //	{
        //		if (Request.ServerVariables["REMOTE_ADDR"] != null)
        //		{
        //			Deger = Deger.Replace("<?ClientIP?>", "85.105.17.177");//Request.ServerVariables["REMOTE_ADDR"]);
        //		}
        //		else
        //		{
        //			Deger = Deger.Replace("<?ClientIP?>", "85.105.17.177");
        //		}
        //	}
        //	else
        //	{
        //		Deger = Deger.Replace("<?ClientIP?>", "85.105.17.177");
        //	}


        //	WebRequest request = WebRequest.Create("http://otageo.cartrawler.com/cartrawlerota/");
        //	//WebRequest request = WebRequest.Create("http://external-dev-avail.cartrawler.com/cartrawlerota/");
        //	//WebRequest request = WebRequest.Create("http://ota.cartrawler.com/cartrawlerota/");//eski
        //	request.Method = "POST";
        //	string postData = Deger;
        //	byte[] byteArray = Encoding.UTF8.GetBytes(postData);
        //	request.ContentType = "application/x-www-form-urlencoded";
        //	request.ContentLength = byteArray.Length;
        //	Stream dataStream = request.GetRequestStream();
        //	dataStream.Write(byteArray, 0, byteArray.Length);
        //	dataStream.Close();
        //	WebResponse response = request.GetResponse();
        //	Console.WriteLine(((HttpWebResponse)response).StatusDescription);
        //	dataStream = response.GetResponseStream();
        //	StreamReader reader = new StreamReader(dataStream, System.Text.Encoding.UTF8, true);
        //	string responseFromServer = reader.ReadToEnd();

        //	reader.Close();
        //	dataStream.Close();
        //	response.Close();


        //	if (responseFromServer.ToLower().Contains("error"))
        //	{
        //		string logName = Guid.NewGuid().ToString();

        //		ErrorLog(Deger, "AracAramaRequest-" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm") + "-" + logName);
        //		ErrorLog(responseFromServer, "AracAramaResponse-" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm") + "-" + logName);

        //		if (responseFromServer.IndexOf("<Errors>") != -1)
        //		{
        //			string normals = responseFromServer.Substring(responseFromServer.IndexOf("<Errors>"), (responseFromServer.IndexOf("</Errors>") - responseFromServer.IndexOf("<Errors>"))) + "</Errors>";

        //			XmlDocument xmls = new XmlDocument();
        //			xmls.LoadXml(normals);

        //			XmlNodeList xnLists = xmls.SelectNodes("/Errors");
        //			string ErrorNum = "";
        //			foreach (XmlNode item in xnLists)
        //			{
        //				ErrorNum = item.ChildNodes[0].Attributes["Type"].Value;
        //			}


        //			var error = dbContext.FlightErrorLogs.Create();
        //			error.Email = "-";
        //			error.Exception = "Araç Arama Hatası; Error No : " + ErrorNum + "  - Aranan Yer : " + vehicleSearchModel.StartRegion.Name + " - " + vehicleSearchModel.EndRegion.Name; ;
        //			error.InsertedDate = DateTime.Now;
        //			error.NameSurname = "-";
        //			error.Phone = "-";
        //			error.SessionID = "3";
        //			error.Where = "Araç Araması";
        //			error.LogType = 3;
        //			dbContext.FlightErrorLogs.Add(error);
        //			dbContext.SaveChanges();

        //			return RedirectToAction("VehicleError", "Vehicle", new { errorNum = ErrorNum });
        //		}

        //		var errors = dbContext.FlightErrorLogs.Create();
        //		errors.Email = "-";
        //		errors.Exception = "Araç Arama Hatası; Bilinmeyen hata - Aranan Yer : " + vehicleSearchModel.StartRegion.Name + " - " + vehicleSearchModel.EndRegion.Name;
        //		errors.InsertedDate = DateTime.Now;
        //		errors.NameSurname = "-";
        //		errors.Phone = "-";
        //		errors.SessionID = "3";
        //		errors.Where = "Araç Araması";
        //		errors.LogType = 3;
        //		dbContext.FlightErrorLogs.Add(errors);
        //		dbContext.SaveChanges();

        //		return RedirectToAction("VehicleError", "Vehicle", new { errorNum = "0" });
        //	}


        //	List<VehicleModel> Liste = new List<VehicleModel>();
        //	string normal = responseFromServer.Substring(responseFromServer.IndexOf("<VehVendorAvails>"), (responseFromServer.IndexOf("</VehVendorAvails>") - responseFromServer.IndexOf("<VehVendorAvails>"))) + "</VehVendorAvails>";

        //	XmlDocument xml = new XmlDocument();
        //	xml.LoadXml(normal);

        //	XmlNodeList xnList = xml.SelectNodes("/VehVendorAvails/VehVendorAvail/VehAvails/VehAvail");
        //	int Counter = 1;
        //	foreach (XmlNode xn in xnList)
        //	{
        //		var model = new VehicleModel();
        //		model.ID = Counter++;
        //		model.CategoryID = Convert.ToInt32(xn["VehAvailCore"].ChildNodes[0].ChildNodes[1].Attributes[0].Value);
        //		try
        //		{
        //			model.DoorCount = xn["VehAvailCore"].ChildNodes[0].ChildNodes[0].Attributes["DoorCount"].Value;
        //		}
        //		catch
        //		{
        //			model.DoorCount = "0";
        //		}
        //		model.CompanyName = (xn.ParentNode["VehAvail"].ParentNode).ParentNode.ChildNodes[0].Attributes[2].Value;//xn.ParentNode["VehAvail"].ParentNode["VehAvails"].ParentNode["VehVendorAvail"].ChildNodes[0].Attributes[2].Value;
        //		model.TotalRate = currentCulture.Code == "tr" ? Convert.ToDecimal(xn["VehAvailCore"].ChildNodes[2].Attributes[0].Value.Replace(".", ",")) : Convert.ToDecimal(xn["VehAvailCore"].ChildNodes[2].Attributes[0].Value.Replace(",", "."));
        //		model.ThumImage = xn["VehAvailCore"].ChildNodes[0].ChildNodes[3].InnerText;
        //		model.Name = xn["VehAvailCore"].ChildNodes[0].ChildNodes[2].Attributes[0].Value;
        //		model.avarageRate = model.TotalRate / (vehicleSearchModel.EndAt - vehicleSearchModel.StartAt).Days;
        //		try
        //		{
        //			model.BaggageCount = xn["VehAvailCore"].ChildNodes[0].Attributes["BaggageQuantity"].Value;
        //		}
        //		catch
        //		{
        //			model.BaggageCount = "0";
        //		}
        //		try
        //		{
        //			model.PassengerCount = xn["VehAvailCore"].ChildNodes[0].Attributes["PassengerQuantity"].Value;
        //		}
        //		catch
        //		{
        //			model.PassengerCount = "0";
        //		}

        //		try
        //		{
        //			model.GearType = xn["VehAvailCore"].ChildNodes[0].Attributes["TransmissionType"].Value;
        //		}
        //		catch
        //		{
        //			model.GearType = "";
        //		}

        //		try
        //		{

        //			model.FuelType = xn["VehAvailCore"].ChildNodes[0].Attributes["FuelType"].Value;
        //		}
        //		catch
        //		{
        //			model.FuelType = "";
        //		}

        //		try
        //		{
        //			model.Url = xn["VehAvailCore"].ChildNodes[4].Attributes["URL"].Value;
        //		}
        //		catch (Exception e)
        //		{
        //			model.Url = xn["VehAvailCore"].ChildNodes[5].Attributes["URL"].Value;
        //		}

        //		try
        //		{
        //			model.ReferanceID = xn["VehAvailCore"].ChildNodes[4].Attributes["ID"].Value;
        //		}
        //		catch (Exception e)
        //		{
        //			model.ReferanceID = xn["VehAvailCore"].ChildNodes[5].Attributes["ID"].Value;
        //		}

        //		try
        //		{
        //			model.FuelPolicy = xn["VehAvailCore"].ChildNodes[6].ChildNodes[0].Attributes["Description"].Value;
        //		}
        //		catch (Exception e)
        //		{

        //		}

        //		try
        //		{
        //			model.CC_Info = xn["VehAvailCore"].ChildNodes[5].ChildNodes[3].Attributes["Required"].Value;
        //		}
        //		catch (Exception e)
        //		{
        //			try
        //			{
        //				model.CC_Info = xn["VehAvailCore"].ChildNodes[6].ChildNodes[3].Attributes["Required"].Value;
        //			}
        //			catch (Exception)
        //			{

        //				model.CC_Info = "true";
        //			}

        //		}


        //		try
        //		{
        //			model.OriginalAmount = currentCulture.Code == "tr" ? Convert.ToDecimal(xn["VehAvailCore"].ChildNodes[6].ChildNodes[7].ChildNodes[0].Attributes["Amount"].Value.ToString().Replace(".", ",")) : Convert.ToDecimal(xn["VehAvailCore"].ChildNodes[6].ChildNodes[7].ChildNodes[0].Attributes["Amount"].Value.ToString().Replace(".", "."));
        //			model.OriginalCurrency = xn["VehAvailCore"].ChildNodes[6].ChildNodes[7].ChildNodes[0].Attributes["CurrencyCode"].Value;
        //			if (model.OriginalAmount == 0)
        //			{
        //				model.OriginalAmount = currentCulture.Code == "tr" ? Convert.ToDecimal(xn["VehAvailCore"].ChildNodes[6].ChildNodes[7].ChildNodes[1].Attributes["Amount"].Value.ToString().Replace(".", ",")) : Convert.ToDecimal(xn["VehAvailCore"].ChildNodes[6].ChildNodes[7].ChildNodes[1].Attributes["Amount"].Value.ToString().Replace(".", "."));
        //				model.OriginalCurrency = xn["VehAvailCore"].ChildNodes[6].ChildNodes[7].ChildNodes[1].Attributes["CurrencyCode"].Value;
        //			}

        //		}
        //		catch (Exception e)
        //		{
        //			try
        //			{
        //				model.OriginalAmount = currentCulture.Code == "tr" ? Convert.ToDecimal(xn["VehAvailCore"].ChildNodes[6].ChildNodes[6].ChildNodes[0].Attributes["Amount"].Value.ToString().Replace(".", ",")) : Convert.ToDecimal(xn["VehAvailCore"].ChildNodes[6].ChildNodes[6].ChildNodes[0].Attributes["Amount"].Value.ToString().Replace(".", "."));
        //				model.OriginalCurrency = xn["VehAvailCore"].ChildNodes[6].ChildNodes[6].ChildNodes[0].Attributes["CurrencyCode"].Value;

        //				if (model.OriginalAmount == 0)
        //				{
        //					model.OriginalAmount = currentCulture.Code == "tr" ? Convert.ToDecimal(xn["VehAvailCore"].ChildNodes[6].ChildNodes[6].ChildNodes[1].Attributes["Amount"].Value.ToString().Replace(".", ",")) : Convert.ToDecimal(xn["VehAvailCore"].ChildNodes[6].ChildNodes[6].ChildNodes[1].Attributes["Amount"].Value.ToString().Replace(".", "."));
        //					model.OriginalCurrency = xn["VehAvailCore"].ChildNodes[6].ChildNodes[6].ChildNodes[1].Attributes["CurrencyCode"].Value;
        //				}
        //			}
        //			catch
        //			{
        //				try
        //				{
        //					model.OriginalAmount = currentCulture.Code == "tr" ? Convert.ToDecimal(xn["VehAvailCore"].ChildNodes[5].ChildNodes[7].ChildNodes[0].Attributes["Amount"].Value.ToString().Replace(".", ",")) : Convert.ToDecimal(xn["VehAvailCore"].ChildNodes[6].ChildNodes[6].ChildNodes[0].Attributes["Amount"].Value.ToString().Replace(".", "."));
        //					model.OriginalCurrency = xn["VehAvailCore"].ChildNodes[5].ChildNodes[7].ChildNodes[0].Attributes["CurrencyCode"].Value;

        //					if (model.OriginalAmount == 0)
        //					{
        //						model.OriginalAmount = currentCulture.Code == "tr" ? Convert.ToDecimal(xn["VehAvailCore"].ChildNodes[5].ChildNodes[7].ChildNodes[1].Attributes["Amount"].Value.ToString().Replace(".", ",")) : Convert.ToDecimal(xn["VehAvailCore"].ChildNodes[6].ChildNodes[6].ChildNodes[1].Attributes["Amount"].Value.ToString().Replace(".", "."));
        //						model.OriginalCurrency = xn["VehAvailCore"].ChildNodes[5].ChildNodes[7].ChildNodes[1].Attributes["CurrencyCode"].Value;
        //					}
        //				}
        //				catch
        //				{
        //					model.OriginalAmount = 0;
        //					model.OriginalCurrency = " ";
        //				}
        //			}
        //		}

        //		if (model.OriginalAmount == 0)
        //			model.OriginalCurrency = "";

        //		model.OfficeName = xn.ParentNode.ParentNode.ChildNodes[2].ChildNodes[0].Attributes[1].Value;
        //		model.OfficeAddress = xn.ParentNode.ParentNode.ChildNodes[2].ChildNodes[0].ChildNodes[0].ChildNodes[0].InnerText;
        //		try
        //		{
        //			model.OfficeTel = xn.ParentNode.ParentNode.ChildNodes[2].ChildNodes[0].ChildNodes[1].Attributes[0].Value;
        //		}
        //		catch
        //		{
        //			model.OfficeTel = "-";
        //		}

        //		string StartLat = xn.ParentNode.ParentNode.ChildNodes[2].ChildNodes[0].ChildNodes[0].Attributes[0].Value;

        //		if (vehicleSearchModel.StartRegionID == vehicleSearchModel.EndRegionID)
        //		{

        //			model.CompanyImage = xn.ParentNode.ParentNode.ChildNodes[2].ChildNodes[1].ChildNodes[0].InnerText;

        //			if (string.IsNullOrEmpty(model.CompanyImage))
        //			{
        //				model.CompanyImage = xn.ParentNode.ParentNode.ChildNodes[2].ChildNodes[1].ChildNodes[1].InnerText;

        //			}

        //		}
        //		else
        //		{
        //			model.CompanyImage = xn.ParentNode.ParentNode.ChildNodes[2].ChildNodes[2].ChildNodes[0].InnerText;
        //			if (string.IsNullOrEmpty(model.CompanyImage))
        //			{
        //				model.CompanyImage = xn.ParentNode.ParentNode.ChildNodes[2].ChildNodes[2].ChildNodes[1].InnerText;

        //			}
        //		}

        //		if (StartLat != null)
        //		{
        //			string[] dizi = StartLat.Split(',');
        //			model.StartOfficeLatitude = Convert.ToDecimal(dizi[0].Replace('.', ','));
        //			model.StartOfficeLongitude = Convert.ToDecimal(dizi[1].Replace('.', ','));
        //		}

        //		if (vehicleSearchModel.StartRegionID == vehicleSearchModel.EndRegionID)
        //		{
        //			model.EndOfficeName = xn.ParentNode.ParentNode.ChildNodes[2].ChildNodes[0].Attributes[1].Value;
        //			model.EndOfficeAddress = xn.ParentNode.ParentNode.ChildNodes[2].ChildNodes[0].ChildNodes[0].ChildNodes[0].InnerText;
        //			try
        //			{
        //				model.EndOfficeTel = xn.ParentNode.ParentNode.ChildNodes[2].ChildNodes[0].ChildNodes[1].Attributes[0].Value;
        //			}
        //			catch
        //			{
        //				model.EndOfficeTel = "-";
        //			}
        //			model.EndOfficeLatitude = model.StartOfficeLatitude;
        //			model.EndOfficeLongitude = model.StartOfficeLongitude;
        //		}
        //		else
        //		{
        //			model.EndOfficeName = xn.ParentNode.ParentNode.ChildNodes[2].ChildNodes[1].Attributes[1].Value;
        //			model.EndOfficeAddress = xn.ParentNode.ParentNode.ChildNodes[2].ChildNodes[1].ChildNodes[0].ChildNodes[0].InnerText;
        //			try
        //			{
        //				model.EndOfficeTel = xn.ParentNode.ParentNode.ChildNodes[2].ChildNodes[1].ChildNodes[1].Attributes[0].Value;
        //			}
        //			catch
        //			{
        //				model.EndOfficeTel = "-";
        //			}

        //			string EndLat = xn.ParentNode.ParentNode.ChildNodes[2].ChildNodes[0].ChildNodes[0].Attributes[0].Value;

        //			if (EndLat != null)
        //			{
        //				string[] dizie = EndLat.Split(',');
        //				model.EndOfficeLatitude = Convert.ToDecimal(dizie[0].Replace('.', ','));
        //				model.EndOfficeLongitude = Convert.ToDecimal(dizie[1].Replace('.', ','));
        //			}
        //		}

        //		model.VehicleCharges = new List<string>();

        //		model.PricedCoverages = new List<string>();

        //		model.IncludePrice = new List<Tuple<string, decimal, int, int>>();

        //		try
        //		{
        //			if (xn["VehAvailCore"].ChildNodes[6].ChildNodes[4].ChildNodes[0] != null)
        //			{
        //				model.VehicleCharges.Add(xn["VehAvailCore"].ChildNodes[6].ChildNodes[4].ChildNodes[0].Attributes[1].Value);
        //			}
        //			else if (xn["VehAvailCore"].ChildNodes[5].ChildNodes[4].ChildNodes[0] != null)
        //			{
        //				model.VehicleCharges.Add(xn["VehAvailCore"].ChildNodes[6].ChildNodes[4].ChildNodes[0].Attributes[1].Value);
        //			}

        //		}
        //		catch (Exception e)
        //		{

        //		}

        //		model.VehicleCharges.Add(model.FuelPolicy);

        //		try
        //		{

        //			foreach (XmlNode item in xn["VehAvailCore"].ChildNodes[1].ChildNodes[0].ChildNodes)
        //			{
        //				model.VehicleCharges.Add(item.Attributes[0].Value);
        //			}

        //			try
        //			{
        //				foreach (XmlNode item in xn["VehAvailCore"].ChildNodes[1].ChildNodes[1].ChildNodes)
        //				{
        //					model.VehicleCharges.Add(item.Attributes[0].Value);
        //				}
        //			}
        //			catch
        //			{

        //			}
        //		}
        //		catch (Exception e)
        //		{
        //			try
        //			{
        //				foreach (XmlNode item in xn["VehAvailCore"].ChildNodes[1].ChildNodes[1].ChildNodes)
        //				{
        //					model.VehicleCharges.Add(item.Attributes[0].Value);
        //				}
        //			}
        //			catch
        //			{

        //			}
        //		}

        //		try
        //		{
        //			foreach (XmlNode item in xn["VehAvailInfo"].ChildNodes[0].ChildNodes)
        //			{
        //				model.PricedCoverages.Add(item.ChildNodes[1].Attributes[0].Value);
        //			}
        //		}
        //		catch (Exception e)
        //		{

        //		}

        //		int feeID = 1;

        //		try
        //		{
        //			foreach (XmlNode item in xn["VehAvailCore"].ChildNodes[3].ChildNodes)
        //			{
        //				model.IncludePrice.Add(new Tuple<string, decimal, int, int>(item.ChildNodes[0].ChildNodes[0].InnerText, currentCulture.Code == "tr" ? Convert.ToDecimal(item.ChildNodes[1].Attributes[0].Value.Replace('.', ',')) : Convert.ToDecimal(item.ChildNodes[1].Attributes[0].Value.Replace(',', '.')), feeID, Convert.ToInt32(item.ChildNodes[0].Attributes["EquipType"].Value)));
        //				feeID++;
        //			}
        //		}
        //		catch (Exception e)
        //		{

        //		}

        //		vehicleSearchModel.VehicleList.Add(model);
        //	}
        //}
        //catch (Exception e)
        //{
        //	System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");


        //	return RedirectToAction("VehicleError", "Vehicle", new { errorNum = e.ToString() });
        //	throw e;
        //	//using (WebResponse response = e.Response)
        //	//{
        //	//	HttpWebResponse httpResponse = (HttpWebResponse)response;
        //	//	string ss= httpResponse.StatusCode.ToString();
        //	//	using (Stream data = response.GetResponseStream())
        //	//	using (var reader = new StreamReader(data))
        //	//	{
        //	//		string text = reader.ReadToEnd();
        //	//		//Console.WriteLine(text);
        //	//	}
        //	//}
        //}

        //Session.Add("Vehicle-Search-" + vehicleSearchModel.UniqueKey, vehicleSearchModel);

        ////return RedirectToAction("List", new { UniqueKey = vehicleSearchModel.UniqueKey });
        //return View(vehicleSearchModel);
        //     }
        #endregion
        public ActionResult Filters(string UniqueKey, string Automatic, string Manual, string AirConditionInd,
            string Dizel, string hybrid, string Petrol,
            string[] CompanyName, int[] Categories, string[] PassengerCount)
        {
            string Culture = "tr-TR";
            if (Session["culture"] != null)
            {
                Culture = Session["culture"].ToString();
            }
            string culture = "tr";
            culture = Culture.Split('-')[0];

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Culture); // de-DE
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Culture);

            Guid uniqueKey = new Guid(UniqueKey);
            var SortedvehicleSearchModel = Session["Vehicle-Search-" + uniqueKey] as VehicleSearchModel;
            SortedvehicleSearchModel.VehicleList = SortedvehicleSearchModel.OrigionalVehicleList;

            if (!string.IsNullOrEmpty(Automatic))
            {
                SortedvehicleSearchModel.VehicleList = SortedvehicleSearchModel.VehicleList.Where(t => t.TransmissionType == "Automatic").ToList();
            }
            if (!string.IsNullOrEmpty(Manual))
            {
                SortedvehicleSearchModel.VehicleList = SortedvehicleSearchModel.VehicleList.Where(t => t.TransmissionType == "Manual").ToList();
            }
            if (!string.IsNullOrEmpty(AirConditionInd))
            {
                SortedvehicleSearchModel.VehicleList = SortedvehicleSearchModel.VehicleList.Where(t => t.AirConditionInd == true).ToList();
            }
            if (!string.IsNullOrEmpty(Dizel))
            {
                SortedvehicleSearchModel.VehicleList = SortedvehicleSearchModel.VehicleList.Where(t => t.FuelType == "Dizel").ToList();
            }
            if (!string.IsNullOrEmpty(hybrid))
            {
                SortedvehicleSearchModel.VehicleList = SortedvehicleSearchModel.VehicleList.Where(t => t.FuelType == "hybrid").ToList();
            }
            if (!string.IsNullOrEmpty(Petrol))
            {
                SortedvehicleSearchModel.VehicleList = SortedvehicleSearchModel.VehicleList.Where(t => t.FuelType == "Petrol").ToList();
            }
            if (CompanyName != null)
            {
                if (CompanyName.Count() > 0)
                {
                    SortedvehicleSearchModel.VehicleList = SortedvehicleSearchModel.VehicleList.Where(t => CompanyName.Contains(t.CompanyName)).ToList();
                    //	return Users.Values.Where(u => ids.Contains(u.UserID)).ToList()
                    //SortedvehicleSearchModel.VehicleList = SortedvehicleSearchModel.VehicleList.Where(t => t.CompanyName == CompanyName[i]).ToList();
                }
            }


            if (Categories != null)
            {
                if (Categories.Count() > 0)
                {
                    if (!Categories.Contains(999))
                    {
                        SortedvehicleSearchModel.VehicleList = SortedvehicleSearchModel.VehicleList.Where(t => Categories.Contains(t.CategoryID)).ToList();
                    }
                }
            }
            if (PassengerCount != null)
            {
                if (PassengerCount.Count() > 0)
                {

                    SortedvehicleSearchModel.VehicleList = SortedvehicleSearchModel.VehicleList.Where(t => PassengerCount.Contains(t.PassengerCount)).ToList();
                }
            }

            return View("~/Views/Car/ListAvailableItems.cshtml", SortedvehicleSearchModel);



            //return RedirectToAction("ListAvailableItems", "Car", new { errorNum = ErrorNum });
        }
        //,string[] Gears,string Automatic,string Manual, string AirConditionInd,string Dizel,string hybrid,string Petrol, string[] CompanyName
        public ActionResult ListAvailableItems(VehicleSearchModel vehicleSearchModel, string StartAt, string EndAt, int? sort, string UniqueKey)
        {

            string Culture = "tr-TR";
            if (Session["culture"] != null)
            {
                Culture = Session["culture"].ToString();
            }
            string culture = "tr";
            culture = Culture.Split('-')[0];

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Culture); // de-GB
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Culture);



            if (sort == 1)//fiyat
            {
                Guid uniqueKey = new Guid(UniqueKey);
                var SortedvehicleSearchModel = Session["Vehicle-Search-" + uniqueKey] as VehicleSearchModel;
                SortedvehicleSearchModel.VehicleList = SortedvehicleSearchModel.VehicleList.OrderBy(t => t.TotalRate).ToList();
                return View(SortedvehicleSearchModel);
            }
            else if (sort == 2)//mesafe değil fiyat artan
            {
                Guid uniqueKey = new Guid(UniqueKey);
                var SortedvehicleSearchModel = Session["Vehicle-Search-" + uniqueKey] as VehicleSearchModel;
                SortedvehicleSearchModel.VehicleList = SortedvehicleSearchModel.VehicleList.OrderByDescending(t => t.TotalRate).ToList();
                return View(SortedvehicleSearchModel);
            }
            else if (sort == 3)//puan
            {
                Guid uniqueKey = new Guid(UniqueKey);
                var SortedvehicleSearchModel = Session["Vehicle-Search-" + uniqueKey] as VehicleSearchModel;
                SortedvehicleSearchModel.VehicleList = SortedvehicleSearchModel.VehicleList.OrderBy(t => t.TotalRate).ToList();
                return View(SortedvehicleSearchModel);
            }
            else
            {

            }

            try
            {
                //using (var db = new TourismContext())
                //{
                //	var logRec = db.UserSearchLogs.Create();
                //	logRec.InsertedDate = DateTime.Now;

                //	string address1 = db.Regions.FirstOrDefault(r => r.RefID == vehicleSearchModel.StartRegionID).Translations.First().Name;
                //	string address2 = db.Regions.FirstOrDefault(r => r.RefID == vehicleSearchModel.EndRegionID).Translations.First().Name;

                //	logRec.LogType = 4;
                //	logRec.ReturnCity = address2;
                //	logRec.LeaveCity = address1;
                //	logRec.StartAt = (DateTime)vehicleSearchModel.StartAt;
                //	logRec.EndAt = vehicleSearchModel.EndAt;
                //	db.UserSearchLogs.Add(logRec);
                //	db.SaveChanges();
                //}

                Session["ErrorMessage-Vehicle"] = null;
                //culture = culture ? culture : "tr";


                vehicleSearchModel.Currency = ViewBag.Currency;
                if (string.IsNullOrEmpty(vehicleSearchModel.Currency))
                {
                    vehicleSearchModel.Currency = Session["currency"].ToString();

                }



                string startDate = string.Empty;

                string endDate = string.Empty;
                //turkce: 25-06-2020 
                //ing 06-24-2020
                //istenen 2020-06-25
                // turkce 24 - 06 - 2020 - 27 - 06 - 2020 - tr 
                //en 06-26-2020-06-29-2020-en


                if (culture == "tr")
                {


                    string StartAtDay = StartAt.Split('-')[0];
                    if (StartAtDay.Length != 2)
                    {
                        StartAtDay = string.Concat("0", StartAtDay);

                    }

                    string StartAtMonth = StartAt.Split('-')[1];
                    if (StartAtMonth.Length != 2)
                    {
                        StartAtMonth = string.Concat("0", StartAtMonth);

                    }
                    string StartAtYear = StartAt.Split('-')[2];

                    startDate = string.Concat(StartAtYear, "-", StartAtMonth, "-", StartAtDay);
                    vehicleSearchModel.StartAt = new DateTime(Convert.ToInt32(StartAtYear), Convert.ToInt32(StartAtMonth), Convert.ToInt32(StartAtDay));





                    string EndAtDay = EndAt.Split('-')[0];
                    if (EndAtDay.Length != 2)
                    {
                        EndAtDay = string.Concat("0", EndAtDay);

                    }

                    string EndAtMonth = EndAt.Split('-')[1];
                    if (EndAtMonth.Length != 2)
                    {
                        EndAtMonth = string.Concat("0", EndAtMonth);

                    }
                    string EndAtYear = EndAt.Split('-')[2];

                    endDate = string.Concat(EndAtYear, "-", EndAtMonth, "-", EndAtDay);
                    vehicleSearchModel.EndAt = new DateTime(Convert.ToInt32(EndAtYear), Convert.ToInt32(EndAtMonth), Convert.ToInt32(EndAtDay));

                }
                else//"06-26-2020"
                {
                    string StartAtDay = StartAt.Split('-')[1];
                    if (StartAtDay.Length != 2)
                    {
                        StartAtDay = string.Concat("0", StartAtDay);

                    }

                    string StartAtMonth = StartAt.Split('-')[0];
                    if (StartAtMonth.Length != 2)
                    {
                        StartAtMonth = string.Concat("0", StartAtMonth);

                    }
                    string StartAtYear = StartAt.Split('-')[2];

                    startDate = string.Concat(StartAtYear, "-", StartAtMonth, "-", StartAtDay);
                    vehicleSearchModel.StartAt = new DateTime(Convert.ToInt32(StartAtYear), Convert.ToInt32(StartAtMonth), Convert.ToInt32(StartAtDay));




                    string EndAtDay = EndAt.Split('-')[1];
                    if (EndAtDay.Length != 2)
                    {
                        EndAtDay = string.Concat("0", EndAtDay);

                    }

                    string EndAtMonth = EndAt.Split('-')[0];
                    if (EndAtMonth.Length != 2)
                    {
                        EndAtMonth = string.Concat("0", EndAtMonth);

                    }
                    string EndAtYear = EndAt.Split('-')[2];

                    endDate = string.Concat(EndAtYear, "-", EndAtMonth, "-", EndAtDay);
                    vehicleSearchModel.EndAt = new DateTime(Convert.ToInt32(EndAtYear), Convert.ToInt32(EndAtMonth), Convert.ToInt32(EndAtDay));
                }
                //return RedirectToAction("VehicleError", "Car", new { errorNum = startDate + ":" + endDate + ":" + culture+":"+StartAt+":"+EndAt });
                //vehicleSearchModel.EndAt = DateTime.ParseExact(EndAt, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                //vehicleSearchModel.StartAt = DateTime.ParseExact(StartAt, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                //DateTime result = DateTime.ParseExact("2012-04-05", "yyyy-MM-dd", CultureInfo.InvariantCulture);

                //vehicleSearchModel.StartAt = DateTime.Now.AddDays(22);
                //vehicleSearchModel.EndAt = DateTime.Now.AddDays(25);

                //string StartAtDay = vehicleSearchModel.StartAt.Day.ToString();
                //            if (StartAtDay.Length!=2)
                //            {
                //	StartAtDay = string.Concat("0",StartAtDay);

                //}

                //string StartAtMonth = vehicleSearchModel.StartAt.Month.ToString();
                //if (StartAtMonth.Length != 2)
                //{
                //	StartAtMonth = string.Concat("0", StartAtMonth);

                //}
                //string StartAtYear= vehicleSearchModel.StartAt.Year.ToString();

                //string startDate = string.Concat(StartAtYear,"-",StartAtMonth,"-", StartAtDay);





                //string EndAtDay = vehicleSearchModel.EndAt.Day.ToString();
                //if (EndAtDay.Length != 2)
                //{
                //	EndAtDay = string.Concat("0", EndAtDay);

                //}

                //string EndAtMonth = vehicleSearchModel.EndAt.Month.ToString();
                //if (EndAtMonth.Length != 2)
                //{
                //	EndAtMonth = string.Concat("0", EndAtMonth);

                //}
                //string EndAtYear = vehicleSearchModel.EndAt.Year.ToString();

                //string endDate = string.Concat(EndAtYear, "-", EndAtMonth, "-", EndAtDay);

                //"2020-06-24"
                //string startDate = vehicleSearchModel.StartAt.ToString("yyyy-MM-dd");
                //string endDate = vehicleSearchModel.EndAt.ToString("yyyy-MM-dd");
                int cultureID = 1;
                if (Culture != "tr-TR")
                {
                    cultureID = 2;

                }


                var StartRegion = db.RegionTranslations.FirstOrDefault(t => t.CultureID == cultureID && t.Regions.RefID == vehicleSearchModel.StartRegionID);
                var EndRegion = db.RegionTranslations.FirstOrDefault(t => t.CultureID == cultureID && t.Regions.RefID == vehicleSearchModel.EndRegionID);

                vehicleSearchModel.StartRegion = new Models.Region.RegionTranslation() { Name = StartRegion.Name };// dbContext.RegionTranslations.FirstOrDefault(t => t.CultureID == cultureID && t.Regions.RefID == vehicleSearchModel.StartRegionID);
                vehicleSearchModel.EndRegion = new Models.Region.RegionTranslation() { Name = EndRegion.Name };// dbContext.RegionTranslations.FirstOrDefault(t => t.CultureID == cultureID && t.Region.RefID == vehicleSearchModel.EndRegionID);
                vehicleSearchModel.VehicleList = new List<VehicleModel>();

                string path = Server.MapPath("~/Content/CarTrawler/") + "detailService.xsd";
                //string path = System.Configuration.ConfigurationManager.AppSettings["CarPath"] + "detailService.xsd";
                string readText = System.IO.File.ReadAllText(path);


                string Deger = readText.Replace("\\", string.Empty);

                Deger = Deger.Replace("<?StartDate?>", startDate + "T" + vehicleSearchModel.StartTimeHour + ":00");
                Deger = Deger.Replace("<?EndDate?>", endDate + "T" + vehicleSearchModel.EndTimeHour + ":00");

                Deger = Deger.Replace("<?StartLocation?>", vehicleSearchModel.StartRegionID.ToString());
                Deger = Deger.Replace("<?ReturnLocation?>", vehicleSearchModel.EndRegionID.ToString());

                Deger = Deger.Replace("<?Culture?>", culture);

                Deger = Deger.Replace("<?Currency?>", vehicleSearchModel.Currency);

                Deger = Deger.Replace("<?Country?>", vehicleSearchModel.Country == null ? "TR" : vehicleSearchModel.Country);

                if (Request.ServerVariables != null)
                {
                    if (Request.ServerVariables["REMOTE_ADDR"] != null)
                    {
                        Deger = Deger.Replace("<?ClientIP?>", "93.89.225.193");//Request.ServerVariables["REMOTE_ADDR"]);
                    }
                    else
                    {
                        Deger = Deger.Replace("<?ClientIP?>", "93.89.225.193");
                    }
                }
                else
                {
                    Deger = Deger.Replace("<?ClientIP?>", "93.89.225.193");
                }
                string responseFromServer = string.Empty;
                string logName = System.Guid.NewGuid().ToString();
                ErrorLog(Deger, "AracAramaRequest-" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm") + "-" + logName);
                try
                {
                    //System.Net.WebRequest request = System.Net.WebRequest.Create("https://otageo.cartrawler.com/cartrawlerota/");
                    //System.Net.WebRequest request = System.Net.WebRequest.Create("http://external-dev-avail.cartrawler.com/cartrawlerota/");				
                    System.Net.WebRequest request = System.Net.WebRequest.Create(System.Configuration.ConfigurationManager.AppSettings["CartrawlerSearchURL"]);

                    System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Ssl3 | System.Net.SecurityProtocolType.Tls12 | System.Net.SecurityProtocolType.Tls11;

                    request.Method = "POST";
                    string postData = Deger;
                    byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(postData);
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = byteArray.Length;
                    Stream dataStream = request.GetRequestStream();
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    dataStream.Close();
                    System.Net.WebResponse response = request.GetResponse();
                    dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream, System.Text.Encoding.UTF8, true);
                    responseFromServer = reader.ReadToEnd();
                    reader.Close();
                    dataStream.Close();
                    response.Close();
                }
                catch
                {
                    try
                    {



                        System.Net.WebRequest request = System.Net.WebRequest.Create(System.Configuration.ConfigurationManager.AppSettings["CartrawlerSearchURL"]);

                        System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Ssl3 | System.Net.SecurityProtocolType.Tls12 | System.Net.SecurityProtocolType.Tls11;

                        request.Method = "POST";
                        string postData = Deger;
                        byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(postData);
                        request.ContentType = "application/x-www-form-urlencoded";
                        request.ContentLength = byteArray.Length;
                        Stream dataStream = request.GetRequestStream();
                        dataStream.Write(byteArray, 0, byteArray.Length);
                        dataStream.Close();
                        System.Net.WebResponse response = request.GetResponse();
                        dataStream = response.GetResponseStream();
                        StreamReader reader = new StreamReader(dataStream, System.Text.Encoding.UTF8, true);
                        responseFromServer = reader.ReadToEnd();
                        reader.Close();
                        dataStream.Close();
                        response.Close();
                    }
                    catch (Exception err)
                    {


                        string errordetail = err.StackTrace + "-------" + err.Message + ";;" + err.InnerException;
                        responseFromServer = responseFromServer + ".hata=" + errordetail;
                        ErrorLog(responseFromServer, "AracAramaResponse-" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm") + "-" + logName);

                        throw;
                    }
                }




                // Print dataset information  










                //            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(RootObject));
                //MemoryStream memStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(responseFromServer));
                //var response111= (RootObject)serializer.Deserialize(memStream);


                //var responseLogPath = XmlHelper<OTA_AirAvailAndFaresRSType>.Serialize(response, Directory, operationFlowId, subFolder, CommonHelper.GetLogFileName(responseFileName, logList.Count));
                //XMLtoCshpar.RootObject response =JsonConvert.DeserializeObject<XMLtoCshpar.RootObject>(responseFromServer);



                ErrorLog(responseFromServer, "AracAramaResponse-" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm") + "-" + logName);

                if (responseFromServer.ToLower().Contains("error"))
                {
                    //string logName = System.Guid.NewGuid().ToString();

                    //ErrorLog(Deger, "AracAramaRequest-" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm") + "-" + logName);
                    //ErrorLog(responseFromServer, "AracAramaResponse-" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm") + "-" + logName);

                    if (responseFromServer.IndexOf("<Errors>") != -1)
                    {
                        string normals = responseFromServer.Substring(responseFromServer.IndexOf("<Errors>"), (responseFromServer.IndexOf("</Errors>") - responseFromServer.IndexOf("<Errors>"))) + "</Errors>";

                        XmlDocument xmls = new XmlDocument();
                        xmls.LoadXml(normals);

                        XmlNodeList xnLists = xmls.SelectNodes("/Errors");
                        string ErrorNum = "";
                        foreach (XmlNode item in xnLists)
                        {
                            ErrorNum = item.ChildNodes[0].Attributes["Type"].Value;
                        }


                        //var error = dbContext.FlightErrorLogs.Create();
                        //error.Email = "-";
                        //error.Exception = "Araç Arama Hatası; Error No : " + ErrorNum + "  - Aranan Yer : " + vehicleSearchModel.StartRegion.Name + " - " + vehicleSearchModel.EndRegion.Name; ;
                        //error.InsertedDate = DateTime.Now;
                        //error.NameSurname = "-";
                        //error.Phone = "-";
                        //error.SessionID = "3";
                        //error.Where = "Araç Araması";
                        //error.LogType = 3;
                        //dbContext.FlightErrorLogs.Add(error);
                        //dbContext.SaveChanges();

                        return RedirectToAction("VehicleError", "Car", new { errorNum = ErrorNum });
                    }

                    //var errors = dbContext.FlightErrorLogs.Create();
                    //errors.Email = "-";
                    //errors.Exception = "Araç Arama Hatası; Bilinmeyen hata - Aranan Yer : " + vehicleSearchModel.StartRegion.Name + " - " + vehicleSearchModel.EndRegion.Name;
                    //errors.InsertedDate = DateTime.Now;
                    //errors.NameSurname = "-";
                    //errors.Phone = "-";
                    //errors.SessionID = "3";
                    //errors.Where = "Araç Araması";
                    //errors.LogType = 3;
                    //dbContext.FlightErrorLogs.Add(errors);
                    //dbContext.SaveChanges();

                    return RedirectToAction("VehicleError", "Car", new { errorNum = "0" });
                }


                List<VehicleModel> Liste = new List<VehicleModel>();
                string normal = responseFromServer.Substring(responseFromServer.IndexOf("<VehVendorAvails>"), (responseFromServer.IndexOf("</VehVendorAvails>") - responseFromServer.IndexOf("<VehVendorAvails>"))) + "</VehVendorAvails>";

                XmlDocument xml = new XmlDocument();
                xml.LoadXml(normal);

                XmlNodeList xnList = xml.SelectNodes("/VehVendorAvails/VehVendorAvail/VehAvails/VehAvail");
                int Counter = 1;

                foreach (XmlNode xn in xnList)
                {

                    var model = new VehicleModel();
                    model.ID = Counter++;
                    model.CategoryID = Convert.ToInt32(xn["VehAvailCore"].ChildNodes[0].ChildNodes[1].Attributes[0].Value);
                    model.AirConditionInd = Convert.ToBoolean(xn["VehAvailCore"].ChildNodes[0].Attributes["AirConditionInd"].Value);

                    model.TransmissionType = xn["VehAvailCore"].ChildNodes[0].Attributes["TransmissionType"].Value;
                    //model.FuelType = xn["VehAvailCore"].ChildNodes[0].Attributes["FuelType"].Value;
                    try
                    {
                        model.DoorCount = xn["VehAvailCore"].ChildNodes[0].ChildNodes[0].Attributes["DoorCount"].Value;
                    }
                    catch
                    {
                        model.DoorCount = "0";
                    }
                    model.CompanyName = (xn.ParentNode["VehAvail"].ParentNode).ParentNode.ChildNodes[0].Attributes[2].Value;//xn.ParentNode["VehAvail"].ParentNode["VehAvails"].ParentNode["VehVendorAvail"].ChildNodes[0].Attributes[2].Value;
                    model.TotalRate = culture == "tr" ? Convert.ToDecimal(xn["VehAvailCore"].ChildNodes[2].Attributes[0].Value.Replace(".", ",")) : Convert.ToDecimal(xn["VehAvailCore"].ChildNodes[2].Attributes[0].Value.Replace(",", "."));
                    model.ThumImage = xn["VehAvailCore"].ChildNodes[0].ChildNodes[3].InnerText;
                    model.Name = xn["VehAvailCore"].ChildNodes[0].ChildNodes[2].Attributes[0].Value;

                    model.avarageRate = model.TotalRate; // (vehicleSearchModel.EndAt - vehicleSearchModel.StartAt).Days;
                    try
                    {
                        model.BaggageCount = xn["VehAvailCore"].ChildNodes[0].Attributes["BaggageQuantity"].Value;
                    }
                    catch
                    {
                        model.BaggageCount = "0";
                    }
                    try
                    {
                        model.PassengerCount = xn["VehAvailCore"].ChildNodes[0].Attributes["PassengerQuantity"].Value;
                    }
                    catch
                    {
                        model.PassengerCount = "0";
                    }

                    try
                    {
                        model.GearType = xn["VehAvailCore"].ChildNodes[0].Attributes["TransmissionType"].Value;
                    }
                    catch
                    {
                        model.GearType = "";
                    }

                    try
                    {

                        model.FuelType = xn["VehAvailCore"].ChildNodes[0].Attributes["FuelType"].Value;
                    }
                    catch
                    {
                        model.FuelType = "";
                    }

                    try
                    {
                        model.Url = xn["VehAvailCore"].ChildNodes[4].Attributes["URL"].Value;
                    }
                    catch (Exception e)
                    {
                        model.Url = xn["VehAvailCore"].ChildNodes[5].Attributes["URL"].Value;
                    }

                    try
                    {
                        model.ReferanceID = xn["VehAvailCore"].ChildNodes[4].Attributes["ID"].Value;
                    }
                    catch (Exception e)
                    {
                        model.ReferanceID = xn["VehAvailCore"].ChildNodes[5].Attributes["ID"].Value;
                    }

                    try
                    {
                        model.FuelPolicy = xn["VehAvailCore"].ChildNodes[6].ChildNodes[0].Attributes["Description"].Value;
                    }
                    catch (Exception e)
                    {

                    }

                    try
                    {
                        model.CC_Info = xn["VehAvailCore"].ChildNodes[5].ChildNodes[3].Attributes["Required"].Value;
                    }
                    catch (Exception e)
                    {
                        try
                        {
                            model.CC_Info = xn["VehAvailCore"].ChildNodes[6].ChildNodes[3].Attributes["Required"].Value;
                        }
                        catch (Exception)
                        {

                            model.CC_Info = "true";
                        }

                    }


                    try
                    {
                        model.OriginalAmount = culture == "tr" ? Convert.ToDecimal(xn["VehAvailCore"].ChildNodes[6].ChildNodes[7].ChildNodes[0].Attributes["Amount"].Value.ToString().Replace(".", ",")) : Convert.ToDecimal(xn["VehAvailCore"].ChildNodes[6].ChildNodes[7].ChildNodes[0].Attributes["Amount"].Value.ToString().Replace(".", "."));
                        model.OriginalCurrency = xn["VehAvailCore"].ChildNodes[6].ChildNodes[7].ChildNodes[0].Attributes["CurrencyCode"].Value;
                        if (model.OriginalAmount == 0)
                        {
                            model.OriginalAmount = culture == "tr" ? Convert.ToDecimal(xn["VehAvailCore"].ChildNodes[6].ChildNodes[7].ChildNodes[1].Attributes["Amount"].Value.ToString().Replace(".", ",")) : Convert.ToDecimal(xn["VehAvailCore"].ChildNodes[6].ChildNodes[7].ChildNodes[1].Attributes["Amount"].Value.ToString().Replace(".", "."));
                            model.OriginalCurrency = xn["VehAvailCore"].ChildNodes[6].ChildNodes[7].ChildNodes[1].Attributes["CurrencyCode"].Value;
                        }

                    }
                    catch (Exception e)
                    {
                        try
                        {
                            model.OriginalAmount = culture == "tr" ? Convert.ToDecimal(xn["VehAvailCore"].ChildNodes[6].ChildNodes[6].ChildNodes[0].Attributes["Amount"].Value.ToString().Replace(".", ",")) : Convert.ToDecimal(xn["VehAvailCore"].ChildNodes[6].ChildNodes[6].ChildNodes[0].Attributes["Amount"].Value.ToString().Replace(".", "."));
                            model.OriginalCurrency = xn["VehAvailCore"].ChildNodes[6].ChildNodes[6].ChildNodes[0].Attributes["CurrencyCode"].Value;

                            if (model.OriginalAmount == 0)
                            {
                                model.OriginalAmount = culture == "tr" ? Convert.ToDecimal(xn["VehAvailCore"].ChildNodes[6].ChildNodes[6].ChildNodes[1].Attributes["Amount"].Value.ToString().Replace(".", ",")) : Convert.ToDecimal(xn["VehAvailCore"].ChildNodes[6].ChildNodes[6].ChildNodes[1].Attributes["Amount"].Value.ToString().Replace(".", "."));
                                model.OriginalCurrency = xn["VehAvailCore"].ChildNodes[6].ChildNodes[6].ChildNodes[1].Attributes["CurrencyCode"].Value;
                            }
                        }
                        catch
                        {
                            try
                            {
                                model.OriginalAmount = culture == "tr" ? Convert.ToDecimal(xn["VehAvailCore"].ChildNodes[5].ChildNodes[7].ChildNodes[0].Attributes["Amount"].Value.ToString().Replace(".", ",")) : Convert.ToDecimal(xn["VehAvailCore"].ChildNodes[6].ChildNodes[6].ChildNodes[0].Attributes["Amount"].Value.ToString().Replace(".", "."));
                                model.OriginalCurrency = xn["VehAvailCore"].ChildNodes[5].ChildNodes[7].ChildNodes[0].Attributes["CurrencyCode"].Value;

                                if (model.OriginalAmount == 0)
                                {
                                    model.OriginalAmount = culture == "tr" ? Convert.ToDecimal(xn["VehAvailCore"].ChildNodes[5].ChildNodes[7].ChildNodes[1].Attributes["Amount"].Value.ToString().Replace(".", ",")) : Convert.ToDecimal(xn["VehAvailCore"].ChildNodes[6].ChildNodes[6].ChildNodes[1].Attributes["Amount"].Value.ToString().Replace(".", "."));
                                    model.OriginalCurrency = xn["VehAvailCore"].ChildNodes[5].ChildNodes[7].ChildNodes[1].Attributes["CurrencyCode"].Value;
                                }
                            }
                            catch
                            {
                                model.OriginalAmount = 0;
                                model.OriginalCurrency = " ";
                            }
                        }
                    }

                    if (model.OriginalAmount == 0)
                        model.OriginalCurrency = "";

                    model.OfficeName = xn.ParentNode.ParentNode.ChildNodes[2].ChildNodes[0].Attributes[1].Value;
                    model.OfficeAddress = xn.ParentNode.ParentNode.ChildNodes[2].ChildNodes[0].ChildNodes[0].ChildNodes[0].InnerText;
                    try
                    {
                        model.OfficeTel = xn.ParentNode.ParentNode.ChildNodes[2].ChildNodes[0].ChildNodes[1].Attributes[0].Value;
                    }
                    catch
                    {
                        model.OfficeTel = "-";
                    }

                    string StartLat = xn.ParentNode.ParentNode.ChildNodes[2].ChildNodes[0].ChildNodes[0].Attributes[0].Value;

                    if (vehicleSearchModel.StartRegionID == vehicleSearchModel.EndRegionID)
                    {

                        model.CompanyImage = xn.ParentNode.ParentNode.ChildNodes[2].ChildNodes[1].ChildNodes[0].InnerText;

                        if (string.IsNullOrEmpty(model.CompanyImage))
                        {
                            model.CompanyImage = xn.ParentNode.ParentNode.ChildNodes[2].ChildNodes[1].ChildNodes[1].InnerText;

                        }

                    }
                    else
                    {
                        model.CompanyImage = xn.ParentNode.ParentNode.ChildNodes[2].ChildNodes[2].ChildNodes[0].InnerText;
                        if (string.IsNullOrEmpty(model.CompanyImage))
                        {
                            model.CompanyImage = xn.ParentNode.ParentNode.ChildNodes[2].ChildNodes[2].ChildNodes[1].InnerText;

                        }
                    }
                    if (string.IsNullOrEmpty(model.CompanyImage))
                    {
                        model.CompanyImage = xn.ParentNode.ParentNode.ChildNodes[2].ChildNodes[1].ChildNodes[2].InnerText;
                        //model.CompanyImage=xn.ParentNode["VehAvail"].ParentNode["VehAvails"].ParentNode["VehVendorAvail"].ChildNodes[2].ChildNodes[1].ChildNodes[2].InnerText;
                        //model.CompanyImage = string.Concat("~/Contents/img/",model.CompanyName, ".png");
                    }
                    else
                    {


                    }

                    if (StartLat != null)
                    {
                        string[] dizi = StartLat.Split(',');
                        model.StartOfficeLatitude = dizi[0];
                        model.StartOfficeLongitude = dizi[1];
                        //model.StartOfficeLatitude = Convert.ToDecimal(dizi[0].Replace('.', ','));
                        //model.StartOfficeLongitude = Convert.ToDecimal(dizi[1].Replace('.', ','));
                    }

                    if (vehicleSearchModel.StartRegionID == vehicleSearchModel.EndRegionID)
                    {
                        model.EndOfficeName = xn.ParentNode.ParentNode.ChildNodes[2].ChildNodes[0].Attributes[1].Value;
                        model.EndOfficeAddress = xn.ParentNode.ParentNode.ChildNodes[2].ChildNodes[0].ChildNodes[0].ChildNodes[0].InnerText;
                        try
                        {
                            model.EndOfficeTel = xn.ParentNode.ParentNode.ChildNodes[2].ChildNodes[0].ChildNodes[1].Attributes[0].Value;
                        }
                        catch
                        {
                            model.EndOfficeTel = "-";
                        }
                        model.EndOfficeLatitude = model.StartOfficeLatitude;
                        model.EndOfficeLongitude = model.StartOfficeLongitude;
                    }
                    else
                    {
                        model.EndOfficeName = xn.ParentNode.ParentNode.ChildNodes[2].ChildNodes[1].Attributes[1].Value;
                        model.EndOfficeAddress = xn.ParentNode.ParentNode.ChildNodes[2].ChildNodes[1].ChildNodes[0].ChildNodes[0].InnerText;
                        try
                        {
                            model.EndOfficeTel = xn.ParentNode.ParentNode.ChildNodes[2].ChildNodes[1].ChildNodes[1].Attributes[0].Value;
                        }
                        catch
                        {
                            model.EndOfficeTel = "-";
                        }

                        string EndLat = xn.ParentNode.ParentNode.ChildNodes[2].ChildNodes[0].ChildNodes[0].Attributes[0].Value;

                        if (EndLat != null)
                        {
                            string[] dizie = EndLat.Split(',');
                            model.EndOfficeLatitude = dizie[0];
                            model.EndOfficeLongitude = dizie[1];
                        }
                    }

                    model.VehicleCharges = new List<string>();

                    model.PricedCoverages = new List<string>();

                    model.IncludePrice = new List<Tuple<string, decimal, int, string>>();

                    try
                    {
                        if (xn["VehAvailCore"].ChildNodes[6].ChildNodes[4].ChildNodes[0] != null)
                        {
                            model.VehicleCharges.Add(xn["VehAvailCore"].ChildNodes[6].ChildNodes[4].ChildNodes[0].Attributes[1].Value);
                        }
                        else if (xn["VehAvailCore"].ChildNodes[5].ChildNodes[4].ChildNodes[0] != null)
                        {
                            model.VehicleCharges.Add(xn["VehAvailCore"].ChildNodes[6].ChildNodes[4].ChildNodes[0].Attributes[1].Value);
                        }

                    }
                    catch (Exception e)
                    {

                    }

                    #region ucretli özelikler
                    try
                    {
                        foreach (XmlNode item in xn["VehAvailCore"].ChildNodes[3].ChildNodes)
                        {
                            PricedEquip ricedEquip = new PricedEquip();
                            try
                            {

                                //ricedEquip.ID =Convert.ToInt32(item.Attributes[0].Value);
                                //ricedEquip.Name = item.Attributes[0].Value;
                                //ricedEquip.Price =Convert.ToDecimal(item.Attributes[0].Value);
                                //   model.PricedEquips.Add(ricedEquip);
                            }
                            catch (Exception e)
                            {


                            }

                            //
                        }



                    }
                    catch (Exception e)
                    {

                    }


                    #endregion



                    model.VehicleCharges.Add(model.FuelPolicy);

                    try
                    {

                        foreach (XmlNode item in xn["VehAvailCore"].ChildNodes[1].ChildNodes[0].ChildNodes)
                        {
                            model.VehicleCharges.Add(item.Attributes[0].Value);
                        }

                        try
                        {
                            foreach (XmlNode item in xn["VehAvailCore"].ChildNodes[1].ChildNodes[1].ChildNodes)
                            {
                                model.VehicleCharges.Add(item.Attributes[0].Value);
                            }
                        }
                        catch
                        {

                        }
                    }
                    catch (Exception e)
                    {
                        try
                        {
                            foreach (XmlNode item in xn["VehAvailCore"].ChildNodes[1].ChildNodes[1].ChildNodes)
                            {
                                model.VehicleCharges.Add(item.Attributes[0].Value);
                            }
                        }
                        catch
                        {

                        }
                    }

                    try
                    {
                        foreach (XmlNode item in xn["VehAvailInfo"].ChildNodes[0].ChildNodes)
                        {
                            model.PricedCoverages.Add(item.ChildNodes[1].Attributes[0].Value);
                        }
                    }
                    catch (Exception e)
                    {

                    }

                    int feeID = 1;

                    try
                    {
                        foreach (XmlNode item in xn["VehAvailCore"].ChildNodes[3].ChildNodes)
                        {
                            model.IncludePrice.Add(new Tuple<string, decimal, int, string>(item.ChildNodes[0].ChildNodes[0].InnerText, culture == "tr" ? Convert.ToDecimal(item.ChildNodes[1].Attributes[0].Value.Replace('.', ',')) : Convert.ToDecimal(item.ChildNodes[1].Attributes[0].Value.Replace(',', '.')), feeID, item.ChildNodes[0].Attributes["EquipType"].Value));
                            feeID++;
                        }
                    }
                    catch (Exception e)
                    {

                    }
                    Random rnd = new Random();
                    int point = rnd.Next(6, 9);
                    model.point = point;
                    vehicleSearchModel.VehicleList.Add(model);
                    //               vehicleInfo.CategoryID = model.CategoryID;
                    //               vehicleInfo.CompanyImage = model.CompanyImage;
                    //               vehicleInfo.CompanyName = model.CompanyName;
                    //               vehicleInfo.Name = model.Name;
                    //               vehicleInfo.OfficeAddress = model.OfficeAddress;
                    //               vehicleInfo.OfficeName = model.OfficeName;
                    //               vehicleInfo.OfficeTel = model.OfficeTel;
                    //               vehicleInfo.AirConditionInd = model.AirConditionInd;
                    //               vehicleInfo.BaggageCount = model.BaggageCount;
                    //               vehicleInfo.DoorCount = model.DoorCount;
                    //               vehicleInfo.FuelType = model.FuelType;
                    //               vehicleInfo.GearType = model.GearType;
                    //               vehicleInfo.PassengerCount = model.PassengerCount;
                    //               vehicleInfo.TransmissionType = model.TransmissionType;
                    //               db.VehicleInfo.Add(vehicleInfo);
                    //               db.SaveChanges();

                }
            }
            catch (Exception e)
            {
                //System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");


                return RedirectToAction("VehicleError", new { errorNum = e.Message });
                //throw e;
                //using (WebResponse response = e.Response)
                //{
                //	HttpWebResponse httpResponse = (HttpWebResponse)response;
                //	string ss= httpResponse.StatusCode.ToString();
                //	using (Stream data = response.GetResponseStream())
                //	using (var reader = new StreamReader(data))
                //	{
                //		string text = reader.ReadToEnd();
                //		//Console.WriteLine(text);
                //	}
                //}
            }

            Session.Add("Vehicle-Search-" + vehicleSearchModel.UniqueKey, vehicleSearchModel);
            vehicleSearchModel.OrigionalVehicleList = vehicleSearchModel.VehicleList;
            return View(vehicleSearchModel);

            //return RedirectToAction("List", new { UniqueKey = vehicleSearchModel.UniqueKey });
        }
        public ActionResult SonucYok()
        {
            return View();
        }


        [ChildActionOnly]
        public ActionResult AccordionMenu()
        {
            string Culture = Session["culture"].ToString();

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Culture); // de-DE
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Culture);
            return PartialView("_AccordionMenu");
        }
        [ChildActionOnly]
        public ActionResult Filtre()
        {
            string Culture = Session["culture"].ToString();

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Culture); // de-DE
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Culture);
            return PartialView("_Filtre");
        }
        [ChildActionOnly]
        public ActionResult CarListItem1()
        {
            string Culture = Session["culture"].ToString();

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Culture); // de-DE
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Culture);
            return PartialView("_CarListItem");
        }
        [ChildActionOnly]
        public ActionResult AccordionPages()
        {
            string Culture = Session["culture"].ToString();

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Culture); // de-DE
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Culture);
            return PartialView("_AccordionPages");
        }



        public PartialViewResult _PointScale()
        {
            string Culture = Session["culture"].ToString();

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Culture); // de-DE
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Culture);
            return PartialView();
        }

        public PartialViewResult _ImportantInformations()
        {
            string Culture = Session["culture"].ToString();

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Culture); // de-DE
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Culture);
            return PartialView();
        }
        public PartialViewResult _ReservationTermsAndConditionsModal()
        {
            string Culture = Session["culture"].ToString();

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Culture); // de-DE
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Culture);
            return PartialView();
        }
        public PartialViewResult _PrivacyPolicyModal()
        {
            string Culture = Session["culture"].ToString();

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Culture); // de-DE
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Culture);
            return PartialView();
        }
        public PartialViewResult _SteepThreeCreateModal()
        {
            string Culture = Session["culture"].ToString();

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Culture); // de-DE
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Culture);
            return PartialView();
        }
        public PartialViewResult _SteepThreeEditModal()
        {
            string Culture = Session["culture"].ToString();

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Culture); // de-DE
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Culture);
            return PartialView();
        }


        public ActionResult SteepOneEmailModal(EMailOfferSenMailModel model) { 
            AracKiralamaEntities1 db = new AracKiralamaEntities1();
            var UserMail = db.Accounts.Where(u => u.Email == model.Email).SingleOrDefault();
            EMailOfferTemplateSendMail(model);
            
          
            return RedirectToAction("Index","Car",new { @message = "İlgili aracın bilgisi mail adresinize gönderilmiştir." });
           
        }


        public ActionResult VehicleError(string errorNum)
        {

            string Culture = "tr-TR";
            if (Session["culture"] != null)
            {
                Culture = Session["culture"].ToString();
            }
            string culture = "tr";
            culture = Culture.Split('-')[0];

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Culture); // de-DE
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Culture);
            if (errorNum == "10004")
            {
                return RedirectToAction("SonucYok", "Car");
            }
            Dictionary<string, string> ErrorArr = new Dictionary<string, string>();
            ErrorArr.Add("3", "No service on requested date Supplier does not support");
            ErrorArr.Add("15", "Invalid date Invalid pickup/return date");
            ErrorArr.Add("83", "Leg/journey/itinerary reference invalid Validation check failed. Pickup date/time/location or Return date/time/location do not match details in Reservation.");
            ErrorArr.Add("95", "Booking already cancelled Self-Explanatory.");
            ErrorArr.Add("97", "Booking reference not found The booking reference has expired. You will need to obtain a fresh Booking reference by doing a fresh availability.");
            ErrorArr.Add("99", "Booking not owned by requester Reservation was not created by your POS Id.");
            ErrorArr.Add("161", "Search Criteria Invalid The search returned to many records and cannot be returned. The OTA Specifies that 100 is the maximum number of records returned from a Search. You must narrow the search criteria.");
            ErrorArr.Add("189", "Payment not authorised Credit card authorisation refused");
            ErrorArr.Add("193", "Cancellation process failed Basic validation failed. Verify that CancelType=Book Verify that Reservation ID is present in ID attribute of UniqueID.");
            ErrorArr.Add("194", "No matching bookings found Could not find Reservation.");
            ErrorArr.Add("214", "Dropoff date time not within operating hours Self explanatory");
            ErrorArr.Add("219", "Need advance notice for this pickup time Self explanatory");
            ErrorArr.Add("226", "Pickup date has passed Pickup date for Reservation has already passed.");
            ErrorArr.Add("227", "Pickup date time not within operating hours Self explanatory");
            ErrorArr.Add("229", "Pickup location not recognized Invalid pickup location supplied");
            ErrorArr.Add("233", "Return location not Invalid return location supplied");
            ErrorArr.Add("240", "Credit card has expired Credit card expiry date has expired");
            ErrorArr.Add("264", "Reservation cannot be cancelled Reservation is in a state that prevents it from being cancelled. e.g. It is not in a confirmed state");
            ErrorArr.Add("281", "Reservation requires credit card data Reservation requires a credit card, and none is present.");
            ErrorArr.Add("292", "Country in address is invalid Self explanatory");
            ErrorArr.Add("309", "Requested rate may have changed - note rate The car supplier is not able to process this car reservation at this time. This could be an intermittent problem with the supplier. We recommend the customer chooses a different car.");
            ErrorArr.Add("319", "Required data missing: address Self explanatory");
            ErrorArr.Add("352", "Invalid credit card type Credit card type (i.e. Visa / MasterCard ) is not supported.");
            ErrorArr.Add("365", "Error credit card Generic error occurred processing the credit card");
            ErrorArr.Add("10001", "No service on requested pickup date Self explanatory");
            ErrorArr.Add("10002", "No service on requested dropoff date Self explanatory Unsupported XML Request The ‘Version’ attribute in the root element of the request is not supported.");
            ErrorArr.Add("10004", "Search returned no records The search returned no records.");
            ErrorArr.Add("10005", "Error with Credit Card Processor A problem has occurred with our Credit Card Processor.");
            ErrorArr.Add("10006", "Location Mismatch The locations passed in the Reservation message do not match the locations used in the original availability message.");
            ErrorArr.Add("10009", "Invalid Credit Card Verification number Self Explanatory");
            ErrorArr.Add("10011", "The Credit Card Number does not correspond to the Credit Card Type Self Explanatory");
            ErrorArr.Add("10012", "Invalid Credit Card Issue number Self Explanatory");
            ErrorArr.Add("10014", "Commercial terms vary between availability and booking request - significant variation in consumer residence or driver age This means that key information like drivers age/consumer residence/currency has changed between the availability and the reservation message. If this is detected then it is not possible to proceed with the reservation.");
            ErrorArr.Add("10015", "Required data missing: drivers age Self Explanatory");
            ErrorArr.Add("10016", "Location must be an Airport Location Only Airport locations are allowed for this Client.");
            ErrorArr.Add("10017", "Car is not available Car requested to be booked is no longer available.");
            ErrorArr.Add("10019", "Required data missing: Consumer IP address Self Explanatory");
            ErrorArr.Add("10020", "Invalid VehRentalCore Low level error if no ‘VehRentalCore’ element is found in a OTA_VehResRQ message.");
            ErrorArr.Add("10021", "Unfortunately we are unable to process your booking at this time The car supplier is not able to process this car reservation at this time. This could be an intermittent problem with the supplier. We recommend the customer chooses a different car.");
            ErrorArr.Add("10022", "Expiry date invalid Self Explanatory");
            ErrorArr.Add("10023", "Card number fails Luhn Check.Please try again Self Explanatory");
            ErrorArr.Add("10024", "NonNumeric in Credit card number Self Explanatory");
            ErrorArr.Add("10026", "Expiry month invalid Self Explanatory");

            Dictionary<string, string> ErrorArrTR = new Dictionary<string, string>();
            ErrorArrTR.Add("3", "İstenilen tarihte hizmet bulunamadı. Sağlayıcı desteği yok.");
            ErrorArrTR.Add("15", "Geçersiz tarih Geçersiz teslimat/iade tarihi.");
            ErrorArrTR.Add("83", " Geçersiz seyahat ayağı/yolculuk referansı.Geçerlilik kontrolü başarısız. Teslimat tarihi/zamanı/lokasyonu ya da İade tarihi/zamanı/lokasyonu rezervasyon detayları ile uyumsuz.");
            ErrorArrTR.Add("95", "Rezervasyon zaten iptal edilmiş.");
            ErrorArrTR.Add("97", "Rezervasyon referansı bulunamadı. Rezervasyon referansının süresi dolmuş.Yeni bir uygunluk araması yaparak yeni bir rezervasyon referansı almanız gerekiyor.");
            ErrorArrTR.Add("99", "İstem sahibi Rezervasyon sahibi değil. Rezervasyon sizin POS'unuz tarafından oluşturulmamış.");
            ErrorArrTR.Add("161", "Arama kriterleri geçersiz.Arama çok fazla sonuç getirdi ve gösterilemiyor. OTA'ya göre bir aramadan en fazla 100 adet sonuç getirilebilir. Arama kriterlerinizi daraltın.");
            ErrorArrTR.Add("189", "Ödeme için yetki alınamadı. Kredi Kartı ödemesi reddedildi.");
            ErrorArrTR.Add("193", "İptal işlemi başarısız. Temel doğrulama başarısız. CancelType=Book olduğundan emin olun. UniqueID'nin ID sekmesinde Reservasyon ID'si olduğundan emin olun.");
            ErrorArrTR.Add("194", "Eşleşen bir rezervasyon bulunamadı. Rezervasyon bulunamadı.");
            ErrorArrTR.Add("214", "Bu teslimat için önceden bildirim olması gerekli.");
            ErrorArrTR.Add("219", "Araç teslim tarihi geçmiş. Bu rezervasyon için araç teslim saati geçmiş durumda.");
            ErrorArrTR.Add("226", "Araç teslim tarihi geçmiş. Bu rezervasyon için araç teslim saati geçmiş durumda.");
            ErrorArrTR.Add("227", "Araç teslim tarihi ve saati çalışma saatleri dışında.");
            ErrorArrTR.Add("229", "Araç teslim lokasyonu bulunamadı. Geçersiz teslimat adresi.");
            ErrorArrTR.Add("233", "Araç iade lokasyonu bulunamadı. Geçersiz iade adresi.");
            ErrorArrTR.Add("240", "Kredi Kartı'nın süresi geçmiş. Kredi KArtı'nın son kullanma tarihi geçmiş.");
            ErrorArrTR.Add("264", "Rezervasyon iptal edilemez. Rezervasyon iptal etmeye elverişli değil. Yani henüz konfirme edilmemiş.");
            ErrorArrTR.Add("281", "Rezervasyon için kredi kartı bilgileri gerekli. Rezervasyonun gerçekleşmesi için kredi kartı bilgileri girilmelidir.");
            ErrorArrTR.Add("292", "Adresteki ülke adı geçersiz.");
            ErrorArrTR.Add("309", "İstenen fiyat değişmiş olabilir. Araç kiralama şirketi şu an bu rezervasyona izin vermiyor. Bu geçici bir sorun olabilir. Müşterinin bir başka araç seçmesini öneririz.");
            ErrorArrTR.Add("319", "Gerekli olan bir bilgi eksik: Adres.");
            ErrorArrTR.Add("352", "Geçersiz kredi kartı cinsi. Bu Kredi KArtı (Visa/MAstercard, vb) desteklenmiyor.");
            ErrorArrTR.Add("365", "Kredi Kartı hatası. Kredi KArtı işleminde genel bir sorun var.");
            ErrorArrTR.Add("10001", "İstenen teslim tarihinde hizmet verilemiyor.");
            ErrorArrTR.Add("10002", "İstenen tarihte araç iadesi yapılamıyor. . Desteklenmeyen XML istemi. İstemin kök öğesindeki Versiyon niteliği desteklenmiyor.");
            ErrorArrTR.Add("10004", "Arama sonuç bulamadı. Aramaya uygun kayıt bulunamadı.");
            ErrorArrTR.Add("10005", "Kredi Kartı işlemcisinde hata oluştu. Kredi Kartı işlemcimizde bir sorun yaşandı.");
            ErrorArrTR.Add("10006", "Lokasyon uyumsuzluğu. Rezervasyon mesajındaki lokasyon bilgisi orijinal uygunluk mesajındaki lokasyon bilgisi ile uyuşmuyor.");
            ErrorArrTR.Add("10009", "Geçersiz kredi kartı doğrulama numarası.");
            ErrorArrTR.Add("10011", "Girilen Kredi kartı numarası Kredi kartı türü ile uyuşmuyor.");
            ErrorArrTR.Add("10012", "Geçersiz Kredi KArtı numarası.");
            ErrorArrTR.Add("10014", "Uygunluk ile rezervasyon isteği arasındaki ticari şartlar farklı -Müşterinin ikametgah adresi ya da yaşı ile ilgili bilgiler farklı. Yani müşterinin yaşı/ikametgahı/para cinsi bilgileri uygunluk zamanı  ile rezervasyon zamanı arasında değişiklik gösteriyor. Bu yüzden rezervasyon işlemine devam edilemiyor.");
            ErrorArrTR.Add("10015", "Gerekli olan bir bilgi eksik: Kullanıcının yaşı.");
            ErrorArrTR.Add("10016", "Lokasyon bir havalimanı olmak zorunda. Bu müşteri için sadece havalanı lokasyonları kullanılabilir.");
            ErrorArrTR.Add("10017", "Araç müsait değil. rezervasyon için istenen araç müsait değil.");
            ErrorArrTR.Add("10019", "Gerekli olan bir bilgi eksik: Müşteri IP adresi.");
            ErrorArrTR.Add("10020", "Geçersiz VehRentalCore. OTA_VehResRQ mesajında VahRentalCore öğesi bulunmadığında oluşan düşük seviyeli hata.");
            ErrorArrTR.Add("10021", "Maalesef şu anda rezervasyonunuzu gerçekleştiremiyoruz.  Şu anda araç kiralama şirketi bu araç kiralama rezervasyonunu gerçekleştiremiyor. Bu sorun geçici bir süre için geçerli olabilir. Başka araç seçmenizi tavsiye ederiz.");
            ErrorArrTR.Add("10022", "Son kullanım tarihi geçersiz.");
            ErrorArrTR.Add("10023", "Kart numarası Luhn Kontrolünde başarısız. Lütfen yeniden deneyiniz.");
            ErrorArrTR.Add("10024", "Kredi Kartında numara olmayan bilgi.");
            ErrorArrTR.Add("10026", "Son kullanım tarihi ay bilgisi geçersiz.");


            if (!string.IsNullOrEmpty(errorNum))
            {


                if (ErrorArr.Keys.Contains(errorNum))
                {
                    Session["ErrorMessage"] = ViewBag.Culture == "tr" ? ErrorArrTR[errorNum] : ErrorArr[errorNum];
                }
                else
                {
                    Session["ErrorMessage"] = "Bilinmeyen bir hata oluştu." + errorNum;
                }
            }
            else
            {
                Session["ErrorMessage"] = "Bilinmeyen bir hata oluştu.";
            }
            return View();
        }



        private void ErrorLog(string p, string name)
        {
            string path = Server.MapPath("~/Content/CarTrawler/") + "booking_NoInsurce.xsd";
            StreamWriter file = new StreamWriter(Server.MapPath("~/Content/CarTrawler/VehicleErrorLog/") + name + ".xml");
            file.WriteLine(p);
            file.Close();
        }

        public ActionResult Choose(string uniqueKey, int vehicleID)
        {

            string Culture = "tr-TR";
            if (Session["culture"] != null)
            {
                Culture = Session["culture"].ToString();
            }

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Culture); // de-DE
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Culture);
            Guid uniqueKey1 = new Guid(uniqueKey);
            if (Session["Vehicle-Search-" + uniqueKey1] == null)
            {
                //Response.Redirect("/" + currentCulture.Code);
                Response.Redirect("/" + "tr");
            }

            var vehicleSearchModel = Session["Vehicle-Search-" + uniqueKey1] as VehicleSearchModel;
            var vehiclemodel = new VehicleModel();

            vehicleSearchModel.Vehicle = vehicleSearchModel.VehicleList.FirstOrDefault(v => v.ID == vehicleID);

            Session["Vehicle-Search-" + uniqueKey1] = vehicleSearchModel;

            //return RedirectToAction("Reservation", new { uniqueKey = vehicleSearchModel.UniqueKey });
            return View(vehicleSearchModel);
        }
        public PartialViewResult InsuranceModal()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult PaymentPage(string uniqueKey, int vehicleID, string extraFeeHdn, string TotalAll)
        {
            string Culture = Session["culture"].ToString();

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Culture); // de-DE
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Culture);
            Guid uniqueKey1 = new Guid(uniqueKey);
            if (Session["Vehicle-Search-" + uniqueKey1] == null)
            {
                //Response.Redirect("/" + currentCulture.Code);
                Response.Redirect("/" + "tr");
            }

            var vehicleSearchModel = Session["Vehicle-Search-" + uniqueKey1] as VehicleSearchModel;
            var vehiclemodel = new VehicleModel();

            vehicleSearchModel.Vehicle = vehicleSearchModel.VehicleList.FirstOrDefault(v => v.ID == vehicleID);
            TotalAll = TotalAll.Replace('.', ',');



            vehicleSearchModel.extraFeeHdn = extraFeeHdn;
            string feess = "";
            decimal feePrices = 0;
            if (vehicleSearchModel.extraFeeHdn != null)
            {
                string[] dizi = vehicleSearchModel.extraFeeHdn.Split(',');

                foreach (var item in vehicleSearchModel.Vehicle.IncludePrice)
                {
                    if (dizi.Contains(item.Item4.ToString()))
                    {
                        feess += item.Item1.Replace('-', ' ') + "-" + item.Item2.ToString("#,##") + "-" + vehicleSearchModel.Currency + "~";
                        feePrices += item.Item2;
                    }
                }
            }


            vehicleSearchModel.Vehicle.TotalAll = vehicleSearchModel.Vehicle.TotalRate + feePrices;

            Session["Vehicle-Search-" + uniqueKey1] = vehicleSearchModel;

            //return RedirectToAction("Reservation", new { uniqueKey = vehicleSearchModel.UniqueKey });
            vehicleSearchModel.extraFeeHdn = extraFeeHdn;
            return View(vehicleSearchModel);

        }

        public ActionResult ConfirmAction(Guid uniqueKey, [Bind(Prefix = "Contact")] ContactModel contactModel, [Bind(Prefix = "CreditCard")] CreditCard creditCardModel, LoginAccount accountModel, VehicleReservationModel rsrvModel)
        {
            string Culture = "tr-TR";
            if (Session["culture"] != null)
            {
                Culture = Session["culture"].ToString();
            }

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Culture); // de-DE
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Culture);
            string currentCulture = Culture.Split('-')[0];

            Session["hata"] = "";

            Session["UcusURL"] = null;
            Session["OtelURL"] = null;
            Session["AracURL"] = Url.Action("Reservation", "Vehicle", new { uniqueKey = uniqueKey });
            Session["FSBURL"] = null;
            Session["HFSBUrl"] = null;
            Session["PackageUrl"] = null;


            if (Session["Vehicle-Search-" + uniqueKey] == null)
            {
                Response.Redirect("/" + "tr");
            }

            var vehicleSearchModel = Session["Vehicle-Search-" + uniqueKey] as VehicleSearchModel;

            if (vehicleSearchModel == null)
                return RedirectToAction("Index");

            if (Request.HttpMethod == "POST")
            {
                string startDate = vehicleSearchModel.StartAt.ToString("yyyy-MM-dd");
                string endDate = vehicleSearchModel.EndAt.ToString("yyyy-MM-dd");

                string path = Server.MapPath("~/Content/CarTrawler/") + "booking_NoInsurce.xsd";
                //string path = System.Configuration.ConfigurationManager.AppSettings["CarPath"] + "booking_NoInsurce.xsd";

                if (vehicleSearchModel.Vehicle.CC_Info == "false")
                {
                    path = Server.MapPath("~/Content/CarTrawler/") + "booking_NoICreditCard.xsd";
                    //path = System.Configuration.ConfigurationManager.AppSettings["CarPath"] + "booking_NoICreditCard.xsd";
                }

                if (string.IsNullOrEmpty(vehicleSearchModel.Country))
                {
                    vehicleSearchModel.Country = "TR";

                }
                string readText = System.IO.File.ReadAllText(path);

                string Deger = readText.Replace("\\", string.Empty);

                Deger = Deger.Replace("<?Url?>", vehicleSearchModel.Vehicle.Url).Replace("<?ReferanceID?>", vehicleSearchModel.Vehicle.ReferanceID).Replace("<?Amount?>", vehicleSearchModel.Vehicle.TotalRate.ToString().Replace(',', '.'));

                if (vehicleSearchModel.Vehicle.CC_Info == "true")
                {
                    Deger = Deger.Replace("<?CardHolderName?>", creditCardModel.NameSurname.Trim());
                    Deger = Deger.Replace("<?CardNumber?>", creditCardModel.Number.Trim());
                    Deger = Deger.Replace("<?ExpireDate?>", creditCardModel.Month.ToString("00") + creditCardModel.Year.ToString());
                    Deger = Deger.Replace("<?CVC?>", creditCardModel.Code);
                    Deger = Deger.Replace("<?CardType?>", creditCardModel.Type.Trim());
                }

                Deger = Deger.Replace("<?Culture?>", currentCulture);

                Deger = Deger.Replace("<?StartDate?>", startDate + "T" + vehicleSearchModel.StartTimeHour + ":00");
                Deger = Deger.Replace("<?EndDate?>", endDate + "T" + vehicleSearchModel.EndTimeHour + ":00");
                Deger = Deger.Replace("<?Country?>", vehicleSearchModel.Country);
                Deger = Deger.Replace("<?Language?>", currentCulture);
                Deger = Deger.Replace("<?StartLocation?>", vehicleSearchModel.StartRegionID.ToString());
                Deger = Deger.Replace("<?ReturnLocation?>", vehicleSearchModel.EndRegionID.ToString());
                Deger = Deger.Replace("<?FirstName?>", contactModel.FirstName);
                Deger = Deger.Replace("<?LastName?>", contactModel.LastName);
                Deger = Deger.Replace("<?email?>", contactModel.Email);
                Deger = Deger.Replace("<?Currency?>", vehicleSearchModel.Currency);
                Deger = Deger.Replace("<?Address?>", "taksim istanbul");

                string equips = "";

                if (!string.IsNullOrEmpty(vehicleSearchModel.extraFeeHdn))
                {
                    equips = "<SpecialEquipPrefs>";

                    string[] dizif = vehicleSearchModel.extraFeeHdn.Split(',');

                    foreach (var item in vehicleSearchModel.Vehicle.IncludePrice)
                    {
                        if (dizif.Contains(item.Item4.ToString()))
                        {
                            equips += "<SpecialEquipPref EquipType=\"" + item.Item4 + "\" Quantity=\"1\"/>";
                        }
                    }

                    equips += "</SpecialEquipPrefs>";
                    Deger = Deger.Replace("<?Equips?>", equips);
                }
                else
                {
                    Deger = Deger.Replace("<?Equips?>", string.Empty);
                }




                //System.Net.WebRequest request = System.Net.WebRequest.Create("https://otasecure.cartrawler.com/cartrawlerpay/");//production
                System.Net.WebRequest request = System.Net.WebRequest.Create(System.Configuration.ConfigurationManager.AppSettings["CartrawlerBookURL"]);//test

                request.Method = "POST";
                string postData = Deger;
                byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(postData);
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteArray.Length;
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
                System.Net.WebResponse response = request.GetResponse();
                Console.WriteLine(((System.Net.HttpWebResponse)response).StatusDescription);
                dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();

                reader.Close();
                dataStream.Close();
                response.Close();







                if (responseFromServer.ToLower().Contains("error"))
                {
                    string logName = Guid.NewGuid().ToString();
                    ErrorLog(Deger, "AracSAtinAlmaRequest-" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm") + "-" + logName);
                    ErrorLog(responseFromServer, "AracSAtinAlmaResponse-" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm") + "-" + logName);

                    //List<VehicleModel> Liste = new List<VehicleModel>();
                    string normal = responseFromServer.Substring(responseFromServer.IndexOf("<Errors>"), (responseFromServer.IndexOf("</Errors>") - responseFromServer.IndexOf("<Errors>"))) + "</Errors>";

                    XmlDocument xml = new XmlDocument();
                    xml.LoadXml(normal);

                    XmlNodeList xnList = xml.SelectNodes("/Errors");
                    string ErrorNum = "";
                    foreach (XmlNode item in xnList)
                    {
                        ErrorNum = item.ChildNodes[0].Attributes["Type"].Value;
                    }

                    //var error = db.FlightErrorLogs.Create();
                    //error.Email = contactModel.Email;
                    //error.Exception = "Araç satın alma hatası; Error No : " + ErrorNum + " - Aranan Yer : " + vehicleSearchModel.EndRegion.Name + " - " + vehicleSearchModel.StartRegion.Name;
                    //error.InsertedDate = DateTime.Now;
                    //error.NameSurname = contactModel.FirstName + " " + contactModel.LastName;
                    //error.Phone = contactModel.Phone;
                    //error.SessionID = "3";
                    //error.Where = "Araç Satın alması";
                    //error.LogType = 3;
                    //dbContext.FlightErrorLogs.Add(error);
                    //dbContext.SaveChanges();


                    return RedirectToAction("VehicleError", "Car", new { errorNum = ErrorNum });
                }

                string Code = "TR123";
                var eslesen = System.Text.RegularExpressions.Regex.Matches(responseFromServer, "(\\<ConfID Type\\=\\\"([0-9]+)\\\" ID\\=\\\"([A-Za-z0-9\\-]+)\\\"\\/\\>)");

                if (eslesen != null)
                {
                    Code = "";

                    foreach (System.Text.RegularExpressions.Match m in eslesen)
                    {
                        Code += m.Groups[3].Value + " - ";

                    }

                    Code = Code.Substring(0, Code.Length - 3);
                }

                //#region Eski rezervasyon kodları


                using (var db = new AracKiralamaEntities1())
                {

                    var user = db.Accounts.FirstOrDefault(u => u.Email == contactModel.Email.Trim());
                    var ac = db.Accounts.Create();
                    var cnt = db.Contacts.Create();

                    if (user == null && !User.Identity.IsAuthenticated)
                    {
                        ac.RoleID = 2;
                        ac.Email = contactModel.Email;
                        ac.Address = contactModel.Address;
                        ac.Password = "test";// Utility.Utils.GenerateRandom(6);
                        ac.FirstName = contactModel.FirstName;//ri.firstName;
                        ac.LastName = contactModel.LastName; //ri.lastName;
                        ac.Phone = contactModel.Phone; //ri.homePhone;
                        ac.CellPhone = contactModel.Phone;// ri.homePhone;
                        ac.CreatedAt = DateTime.Now;
                        ac.HitAt = DateTime.Now;
                        ac.Status = 3;
                        ac.UniqueKey = Guid.NewGuid().ToString();
                        db.Accounts.Add(ac);

                        cnt.Email = contactModel.Email;
                        cnt.FirstName = contactModel.FirstName;
                        cnt.LastName = contactModel.LastName;
                        cnt.Phone = contactModel.Phone;
                        cnt.Accounts = ac;
                        db.Contacts.Add(cnt);

                        db.SaveChanges();

                    }
                    string feess = "";
                    decimal feePrices = 0;
                    if (vehicleSearchModel.extraFeeHdn != null)
                    {
                        string[] dizi = vehicleSearchModel.extraFeeHdn.Split(',');

                        foreach (var item in vehicleSearchModel.Vehicle.IncludePrice)
                        {
                            if (dizi.Contains(item.Item4.ToString()))
                            {
                                feess += item.Item1.Replace('-', ' ') + "-" + item.Item2.ToString("#,##") + "-" + vehicleSearchModel.Currency + "~";
                                feePrices += item.Item2;
                            }
                        }
                    }

                    var order = db.Orders.Create();
                    order.Identifier = vehicleSearchModel.UniqueKey;
                    order.Total = vehicleSearchModel.Vehicle.TotalRate + feePrices;
                    order.OrderedAt = DateTime.Now;
                    order.OrderType = "Web Site";
                    var VehicleOrder = db.VehicleOrders.Create();

                    VehicleOrder.StartOfficeID = 7;
                    VehicleOrder.EndOfficeID = 7;
                    VehicleOrder.StartAt = vehicleSearchModel.StartAt;
                    VehicleOrder.EndAt = vehicleSearchModel.EndAt;
                    VehicleOrder.VehicleID = 40;
                    VehicleOrder.VehicleRefID = vehicleSearchModel.Vehicle.ID;
                    VehicleOrder.PaymentTypeID = 1;
                    VehicleOrder.ConfirmedID = Code;

                    if (Session["currency"] == null)
                    {
                        Session["currency"] = "TRY";
                    }

                    if (Session["currency"].ToString() == "TRY")
                        VehicleOrder.CurrencyID = 1;
                    else if (Session["currency"].ToString() == "USD")
                        VehicleOrder.CurrencyID = 2;
                    else
                        VehicleOrder.CurrencyID = 3;

                    VehicleOrder.StartTime = vehicleSearchModel.StartTimeHour;//TimeSpan.FromHours(vehicleSearchModel.StartTimeHour).ToString(@"hh") + ":" + TimeSpan.FromMinutes(vehicleSearchModel.StartTimeMinute).ToString(@"mm");
                    VehicleOrder.EndTime = vehicleSearchModel.EndTimeHour;//TimeSpan.FromHours(vehicleSearchModel.EndTimeHour).ToString(@"hh") + ":" + TimeSpan.FromMinutes(vehicleSearchModel.EndTimeMinute).ToString(@"mm");

                    VehicleOrder.VehicleExtraFee = feess;

                    if (vehicleSearchModel.Vehicle.CC_Info == "true")
                    {
                        VehicleOrder.CreditCardExpirationMonth = creditCardModel.Month.ToString();
                        VehicleOrder.CreditCardExpirationYear = creditCardModel.Year.ToString();
                        VehicleOrder.CreditCardNameandSurname = creditCardModel.NameSurname;
                        VehicleOrder.CreditCardNumber = creditCardModel.Number;
                        VehicleOrder.CreditCardSecurityCode = creditCardModel.Code;
                        VehicleOrder.CreditCardType = creditCardModel.Type;
                    }
                    else
                    {
                        VehicleOrder.CreditCardExpirationMonth = "-";
                        VehicleOrder.CreditCardExpirationYear = "-";
                        VehicleOrder.CreditCardNameandSurname = "-";
                        VehicleOrder.CreditCardNumber = "-";
                        VehicleOrder.CreditCardSecurityCode = "-";
                        VehicleOrder.CreditCardType = "-";
                    }

                    VehicleOrder.FlightNumber = string.Empty;// contactModel.FlightNumber;
                    VehicleOrder.VehicleName = vehicleSearchModel.Vehicle.Name;
                    VehicleOrder.StartOfficeName = vehicleSearchModel.Vehicle.OfficeName;
                    VehicleOrder.EndOfficeName = vehicleSearchModel.Vehicle.EndOfficeName;
                    VehicleOrder.OfficeAddress = vehicleSearchModel.Vehicle.OfficeAddress;
                    VehicleOrder.OfficePhone = vehicleSearchModel.Vehicle.OfficeTel;
                    VehicleOrder.Identifier = vehicleSearchModel.UniqueKey.ToString();
                    VehicleOrder.TotalRate = vehicleSearchModel.Vehicle.TotalRate;
                    VehicleOrder.EndOfficeAddress = vehicleSearchModel.Vehicle.EndOfficeAddress;
                    VehicleOrder.EndOfficePhone = vehicleSearchModel.Vehicle.EndOfficeTel;
                    VehicleOrder.ThumImage = vehicleSearchModel.Vehicle.ThumImage;
                    VehicleOrder.PaymentStatusID = 4;
                    VehicleOrder = VehicleOrder;
                    db.VehicleOrders.Add(VehicleOrder);


                    //db.SaveChanges();

                    if (Session["ID"] != null)
                    {
                        var userCont = db.Contacts.FirstOrDefault(q => q.Email == contactModel.Email).ID;
                        order.ContactID = userCont;
                    }


                    else
                    {
                        if (user != null)
                        {
                            order.ContactID = user.Contacts.FirstOrDefault(q => q.AccountID == user.ID).ID;
                        }
                        else
                        {
                            order.ContactID = ac.Contacts.FirstOrDefault(q => q.AccountID == ac.ID).ID;
                        }
                    }


                    db.Orders.Add(order);

                    db.SaveChanges();



                    var VehicleOrderPassenger = db.VehicleOtherPassengers.Create();
                    VehicleOrderPassenger.Address = contactModel.Address;
                    VehicleOrderPassenger.Email = contactModel.Email;
                    VehicleOrderPassenger.FirstName = contactModel.FirstName;
                    VehicleOrderPassenger.FlightNumber = string.Empty;// contactModel.FlightNumber;
                    VehicleOrderPassenger.LastName = contactModel.LastName;
                    VehicleOrderPassenger.Orders = order;
                    VehicleOrderPassenger.Phone = contactModel.Phone;

                    db.VehicleOtherPassengers.Add(VehicleOrderPassenger);
                    db.SaveChanges();

                    vehicleInfo.VehicleOrdersID = VehicleOrder.ID;
                    vehicleInfo.GearType = vehicleSearchModel.Vehicle.GearType;
                    vehicleInfo.AirConditionInd = vehicleSearchModel.Vehicle.AirConditionInd;
                    vehicleInfo.BaggageCount = vehicleSearchModel.Vehicle.BaggageCount;
                    vehicleInfo.CategoryID = vehicleSearchModel.Vehicle.CategoryID;
                    vehicleInfo.CompanyImage = vehicleSearchModel.Vehicle.CompanyImage;
                    vehicleInfo.CompanyName = vehicleSearchModel.Vehicle.CompanyName;
                    vehicleInfo.DoorCount = vehicleSearchModel.Vehicle.DoorCount;
                    vehicleInfo.FuelPolicy = vehicleSearchModel.Vehicle.FuelPolicy;
                    vehicleInfo.FuelType = vehicleSearchModel.Vehicle.FuelType;
                    vehicleInfo.PassengerCount = vehicleSearchModel.Vehicle.PassengerCount;
                    vehicleInfo.TransmissionType = vehicleSearchModel.Vehicle.TransmissionType;

                    StringBuilder strBuild = new StringBuilder();
                    foreach (var item in vehicleSearchModel.Vehicle.VehicleCharges)
                    {

                        strBuild.Append(item + ",");
                    }
                    string VehicleChargesList = strBuild.ToString();
                    vehicleInfo.VehicleCharges = VehicleChargesList.Substring(0, VehicleChargesList.Length - 1);

                    foreach (var item2 in vehicleSearchModel.Vehicle.PricedCoverages)
                    {
                        strBuild.Append(item2 + ",");
                    }
                    string PricedCoveragesList = strBuild.ToString();
                    vehicleInfo.PricedCoverages = PricedCoveragesList.Substring(0, PricedCoveragesList.Length - 1);
                    db.VehicleInfo.Add(vehicleInfo);
                    db.SaveChanges();

                    Session["vehicleName"] = vehicleSearchModel.Vehicle.Name;

                    vehicleSearchModel.Orders = order;
                    Session["Vehicle-Search-" + uniqueKey] = vehicleSearchModel;
                    var DailyPrice = (VehicleOrder.TotalRate) / ((vehicleSearchModel.EndAt) - (vehicleSearchModel.StartAt)).Days;

                    var priceInfo = DailyPrice.ToString("#.##") + " " + ViewBag.Currency + " X " + ((vehicleSearchModel.EndAt.AddDays(1)) - (vehicleSearchModel.StartAt)).Days.ToString() + " " + Resources.LanguageFields.Daily + " = " + VehicleOrder.TotalRate.ToString("#.##") + " " + ViewBag.Currency + " " + Resources.LanguageFields.Daily1;









                    //buradan


                    try
                    {

                        Culture = "tr-TR";
                        if (Session["culture"] != null)
                        {
                            Culture = Session["culture"].ToString();
                        }
                        //culture = Culture.Split('-')[0];

                        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Culture); // de-DE
                        System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Culture);

                        //Müşteritye Giden Mail
                        System.Collections.Generic.Dictionary<string, string> reservationMail = new System.Collections.Generic.Dictionary<string, string>();
                        //Resourcelar
                        reservationMail.Add("<%Dear%>", Arackiralama.Resources.LanguageFields.Dear);
                        reservationMail.Add("<%DropOff%>", Arackiralama.Resources.LanguageFields.DropOff);
                        reservationMail.Add("<%PickUp%>", Arackiralama.Resources.LanguageFields.PickUp);
                        reservationMail.Add("<%Date%>", Arackiralama.Resources.LanguageFields.Date);
                        reservationMail.Add("<%Time%>", Arackiralama.Resources.LanguageFields.Time);
                        reservationMail.Add("<%Company%>", Arackiralama.Resources.LanguageFields.Company);
                        reservationMail.Add("<%OfficeAuth%>", Arackiralama.Resources.LanguageFields.OfficeAuth);
                        reservationMail.Add("<%Telephone%>", Arackiralama.Resources.LanguageFields.TelephoneTitle);
                        reservationMail.Add("<%VehicleCategory%>", Arackiralama.Resources.LanguageFields.VehicleCategory);
                        reservationMail.Add("<%VehicleModel2%>", Arackiralama.Resources.LanguageFields.VehicleModel);
                        reservationMail.Add("<%ResNo%>", Arackiralama.Resources.LanguageFields.ReservationNumber);
                        reservationMail.Add("<%ExtraFee2%>", Arackiralama.Resources.LanguageFields.ExtraFee);
                        reservationMail.Add("<%SubTotal%>", Arackiralama.Resources.LanguageFields.SubTotal);
                        reservationMail.Add("<%GeneralTotal%>", Arackiralama.Resources.LanguageFields.VehicleGeneralTotal);
                        reservationMail.Add("<%VehicleTerm%>", Arackiralama.Resources.LanguageFields.VehicleTerm);
                        reservationMail.Add("<%PriceIndex%>", Arackiralama.Resources.LanguageFields.PriceIndex);
                        reservationMail.Add("<%Inclusive%>", Arackiralama.Resources.LanguageFields.Inclusive);
                        string dahil = string.Empty;
                        if (vehicleSearchModel.Vehicle != null)
                        {


                            dahil = vehicleSearchModel.Vehicle.VehicleCharges.First();
                            foreach (var item in vehicleSearchModel.Vehicle.VehicleCharges.Skip(1))
                            {
                                dahil = dahil + "," + item;
                            }
                            reservationMail.Add("<%VehicleMailTerm%>", dahil);
                            //reservationMail.Add("<%VehicleMailTerm%>", Arackiralama.Resources.LanguageFields.VehicleMailTerm);
                        }
                        else
                        {
                            reservationMail.Add("<%VehicleMailTerm%>", "");
                        }
                        //reservationMail.Add("<%Excluded%>", Arackiralama.Resources.LanguageFields.Excluded);
                        //reservationMail.Add("<%VehicleMailTerm1%>", Arackiralama.Resources.LanguageFields.VehicleMailTerm1);
                        reservationMail.Add("<%NiceTrip%>", Arackiralama.Resources.LanguageFields.NiceTrip);
                        reservationMail.Add("<%aracvararacTeam%>", Arackiralama.Resources.LanguageFields.aracvararacTeam);
                        reservationMail.Add("<%DistanceTitle%>", Arackiralama.Resources.LanguageFields.DistanceTitle);
                        reservationMail.Add("<%PartiesTitle%>", Arackiralama.Resources.LanguageFields.PartiesTitle);
                        reservationMail.Add("<%SellerTitle%>", Arackiralama.Resources.LanguageFields.SellerTitle.ToUpper());
                        reservationMail.Add("<%ContactName%>", Arackiralama.Resources.LanguageFields.ContactName);
                        reservationMail.Add("<%ContactHeader%>", Arackiralama.Resources.LanguageFields.ContractHeader);
                        reservationMail.Add("<%ContractTitle%>", Arackiralama.Resources.LanguageFields.ContractTitle);
                        reservationMail.Add("<%ProductHeader%>", Arackiralama.Resources.LanguageFields.ProductHeader);
                        reservationMail.Add("<%ProductTitle%>", Arackiralama.Resources.LanguageFields.ProductTitle);
                        reservationMail.Add("<%Hirer%>", Arackiralama.Resources.LanguageFields.Hirer);
                        reservationMail.Add("<%TimeDatePickUp%>", Arackiralama.Resources.LanguageFields.TimeDatePickUp);
                        reservationMail.Add("<%TimeReturnPickUp%>", Arackiralama.Resources.LanguageFields.TimeReturnPickUp);
                        reservationMail.Add("<%VehicleClass%>", Arackiralama.Resources.LanguageFields.VehicleClass);
                        reservationMail.Add("<%IncludingRent%>", Arackiralama.Resources.LanguageFields.IncludingRent);
                        reservationMail.Add("<%IncludingTotal%>", Arackiralama.Resources.LanguageFields.IncludingTotal);
                        reservationMail.Add("<%VehicleMailTerm2%>", Arackiralama.Resources.LanguageFields.VehicleTerm1);
                        reservationMail.Add("<%VehicleMailTerm3%>", Arackiralama.Resources.LanguageFields.VehicleTerm2);
                        reservationMail.Add("<%GeneralProvision%>", Arackiralama.Resources.LanguageFields.GeneralProvision);
                        reservationMail.Add("<%GeneralTitle1%>", Arackiralama.Resources.LanguageFields.GeneralTitle1);
                        reservationMail.Add("<%GeneralTitle2%>", Arackiralama.Resources.LanguageFields.GeneralTitle2);
                        reservationMail.Add("<%GeneralTitle3%>", Arackiralama.Resources.LanguageFields.GeneralTitle3);
                        reservationMail.Add("<%GeneralTitle4%>", Arackiralama.Resources.LanguageFields.GeneralTitle4);
                        reservationMail.Add("<%GeneralTitle5%>", Arackiralama.Resources.LanguageFields.GeneralTitle5);
                        reservationMail.Add("<%GeneralTitle6%>", Arackiralama.Resources.LanguageFields.GeneralTitle6);
                        reservationMail.Add("<%GeneralTitle7%>", Arackiralama.Resources.LanguageFields.GeneralTitle7);
                        reservationMail.Add("<%RightWith%>", Arackiralama.Resources.LanguageFields.RightWith);
                        reservationMail.Add("<%Right2%>", Arackiralama.Resources.LanguageFields.Right2);
                        reservationMail.Add("<%Right3%>", Arackiralama.Resources.LanguageFields.Right3);
                        reservationMail.Add("<%Right4%>", Arackiralama.Resources.LanguageFields.Right4);
                        reservationMail.Add("<%Right1%>", Arackiralama.Resources.LanguageFields.Right1);
                        reservationMail.Add("<%Right5%>", Arackiralama.Resources.LanguageFields.Right5);
                        reservationMail.Add("<%Right6%>", Arackiralama.Resources.LanguageFields.Right6);
                        reservationMail.Add("<%Right7%>", Arackiralama.Resources.LanguageFields.Right7);
                        reservationMail.Add("<%Right8%>", Arackiralama.Resources.LanguageFields.Right8);
                        reservationMail.Add("<%Right9%>", Arackiralama.Resources.LanguageFields.Right9);
                        reservationMail.Add("<%Right10%>", Arackiralama.Resources.LanguageFields.Right10);
                        reservationMail.Add("<%Right11%>", Arackiralama.Resources.LanguageFields.Right11);
                        reservationMail.Add("<%CourtTitle%>", Arackiralama.Resources.LanguageFields.CourtTitle);
                        reservationMail.Add("<%Court1%>", Arackiralama.Resources.LanguageFields.Court1);
                        reservationMail.Add("<%PreNotification%>", Arackiralama.Resources.LanguageFields.PreNotification);
                        reservationMail.Add("<%VehicleTerm3%>", Arackiralama.Resources.LanguageFields.VehicleTerm3);
                        reservationMail.Add("<%VehicleTerm4%>", Arackiralama.Resources.LanguageFields.VehicleTerm4);
                        reservationMail.Add("<%VehicleTerm5%>", Arackiralama.Resources.LanguageFields.VehicleTerm5);
                        reservationMail.Add("<%VehicleTerm6%>", Arackiralama.Resources.LanguageFields.VehicleTerm6);
                        reservationMail.Add("<%VehicleTerm7%>", Arackiralama.Resources.LanguageFields.VehicleTerm7);
                        reservationMail.Add("<%PaymentTerms%>", Arackiralama.Resources.LanguageFields.PaymentTerms);
                        reservationMail.Add("<%PaymentTerms1%>", Arackiralama.Resources.LanguageFields.PaymentTerms1);
                        reservationMail.Add("<%CustomerTerm6%>", Arackiralama.Resources.LanguageFields.CustomerTerm6);
                        reservationMail.Add("<%CustomerTerm7%>", Arackiralama.Resources.LanguageFields.CustomerTerm7);
                        reservationMail.Add("<%Payment1%>", Arackiralama.Resources.LanguageFields.Payment1);
                        reservationMail.Add("<%Payment2%>", Arackiralama.Resources.LanguageFields.Payment2);
                        reservationMail.Add("<%CustomerTerm%>", Arackiralama.Resources.LanguageFields.CustomerTerm);
                        reservationMail.Add("<%CustomerTerm1%>", Arackiralama.Resources.LanguageFields.CustomerTerm1);
                        reservationMail.Add("<%CustomerTerm2%>", Arackiralama.Resources.LanguageFields.CustomerTerm2);
                        reservationMail.Add("<%CustomerTerm3%>", Arackiralama.Resources.LanguageFields.CustomerTerm3);
                        reservationMail.Add("<%CustomerTerm4%>", Arackiralama.Resources.LanguageFields.CustomerTerm4);
                        reservationMail.Add("<%CustomerTerm5%>", Arackiralama.Resources.LanguageFields.CustomerTerm5);
                        reservationMail.Add("<%Payment3%>", Arackiralama.Resources.LanguageFields.Payment3);
                        reservationMail.Add("<%Payment4%>", Arackiralama.Resources.LanguageFields.Payment4);
                        reservationMail.Add("<%123%>", Arackiralama.Resources.LanguageFields.Hirer.ToUpper());
                        reservationMail.Add("<%FormName%>", Arackiralama.Resources.LanguageFields.FormName);
                        reservationMail.Add("<%FrmAddress%>", Arackiralama.Resources.LanguageFields.AddressTitle);
                        reservationMail.Add("<%Thanks%>", Arackiralama.Resources.LanguageFields.VehicleMailInfoText);
                        //if (currentCulture.ID == 1)
                        if (1 == 1)
                        {
                            reservationMail.Add("<%StartAt%>", vehicleSearchModel.StartAt.ToString("dd MMM yyyy"));
                            reservationMail.Add("<%EndAt%>", vehicleSearchModel.EndAt.ToString("dd MMM yyyy"));
                            //reservationMail.Add("<%Thanks%>", "<a href=http://www.xxx.com style=color:rgb(9, 124, 248);font-family:Museo;text-decoration:none;font-size:15px;line-height:2px;>aracvararac.com&nbsp;</a>'a göstermiş olduğunuz ilgiye teşekkür eder,rezervasyon detaylarını bilgilerinize sunarız...");

                            reservationMail.Add("<%Cont%>", "İşbu sözleşme" + DateTime.Now.ToString("dd MMM yyyy") + "tarihinde kurulmuştur.");
                            reservationMail.Add("<%Conf%>", "<b>" + vehicleSearchModel.Vehicle.CompanyName + " " + vehicleSearchModel.Vehicle.OfficeName + " - " + vehicleSearchModel.Vehicle.OfficeAddress + " - " + vehicleSearchModel.StartAt.ToString("dd MMM yyyy") + " - " + vehicleSearchModel.StartTimeHour + "</b>");
                            reservationMail.Add("<%Confed%>", "<b>" + vehicleSearchModel.Vehicle.CompanyName + " " + vehicleSearchModel.Vehicle.EndOfficeName + " - " + vehicleSearchModel.Vehicle.EndOfficeAddress + " - " + vehicleSearchModel.EndAt.ToString("dd MMM yyyy") + " - " + vehicleSearchModel.EndTimeHour + "</b>");

                        }
                        else
                        {
                            reservationMail.Add("<%StartAt%>", vehicleSearchModel.StartAt.ToString("dd MMM yyyy"));
                            reservationMail.Add("<%EndAt%>", vehicleSearchModel.EndAt.ToString("dd MMM yyyy"));
                            //reservationMail.Add("<%Thanks%>", "Thank you for using <a href=http://www.xxx.com style=color:rgb(9, 124, 248);font-family:Museo;text-decoration:none;font-size:15px;line-height:2px;>aracvararac.com&nbsp;</a> for your travel needs.Below is your reservation details.");
                            reservationMail.Add("<%Cont%>", "This agreement is created on" + DateTime.Now.ToString("dd MMM yyyy"));
                            reservationMail.Add("<%Conf%>", "<b>" + vehicleSearchModel.Vehicle.CompanyName + " " + vehicleSearchModel.Vehicle.OfficeName + " - " + vehicleSearchModel.Vehicle.OfficeAddress + " - " + vehicleSearchModel.StartAt.ToString("dd MMM yyyy") + " - " + vehicleSearchModel.StartTimeHour + "</b>");
                            reservationMail.Add("<%Confed%>", "<b>" + vehicleSearchModel.Vehicle.CompanyName + " " + vehicleSearchModel.Vehicle.EndOfficeName + " - " + vehicleSearchModel.Vehicle.EndOfficeAddress + " - " + vehicleSearchModel.EndAt.ToString("dd MMM yyyy") + " - " + vehicleSearchModel.EndTimeHour + "</b>");
                        }
                        //reservationMail.Add("<%StartCity%>", db.Regions.FirstOrDefault(r => r.RefID == vehicleSearchModel.StartRegionID).City.Translations.FirstOrDefault(t => t.CultureID == currentCulture.ID).Name);
                        //reservationMail.Add("<%EndCity%>", db.Regions.FirstOrDefault(r => r.RefID == vehicleSearchModel.EndRegionID).City.Translations.FirstOrDefault(t => t.CultureID == currentCulture.ID).Name);
                        reservationMail.Add("<%StartHour%>", TimeSpan.FromHours(Convert.ToDouble(vehicleSearchModel.StartTimeHour.Split(':')[0])).ToString(@"hh"));
                        reservationMail.Add("<%EndHour%>", TimeSpan.FromHours(Convert.ToDouble(vehicleSearchModel.EndTimeHour.Split(':')[0])).ToString(@"hh"));
                        reservationMail.Add("<%StartMinute%>", TimeSpan.FromMinutes(Convert.ToDouble(vehicleSearchModel.StartTimeHour.Split(':')[1].Split(' ')[0])).ToString(@"mm"));
                        reservationMail.Add("<%EndMinute%>", TimeSpan.FromMinutes(Convert.ToDouble(vehicleSearchModel.EndTimeHour.Split(':')[1].Split(' ')[0])).ToString(@"mm"));
                        reservationMail.Add("<%StartOffice%>", vehicleSearchModel.Vehicle.CompanyName + " " + vehicleSearchModel.Vehicle.OfficeAddress);
                        reservationMail.Add("<%EndOffice%>", vehicleSearchModel.Vehicle.CompanyName + " " + vehicleSearchModel.Vehicle.EndOfficeAddress);
                        reservationMail.Add("<%UserName%>", contactModel.FirstName);
                        reservationMail.Add("<%UserLastName%>", contactModel.LastName);
                        reservationMail.Add("<%AuthorizedName%>", "-");
                        reservationMail.Add("<%AuthorizedSurname%>", "-");
                        reservationMail.Add("<%Phone%>", vehicleSearchModel.Vehicle.OfficeTel);
                        reservationMail.Add("<%Category%>", "");
                        reservationMail.Add("<%VehicleModel%>", vehicleSearchModel.Vehicle.Name);
                        reservationMail.Add("<%OrderNum%>", Code);
                        reservationMail.Add("<%Price%>", priceInfo);
                        ViewBag.Currency = Session["currency"].ToString();
                        vehicleSearchModel.Currency = ViewBag.Currency;

                        if (vehicleSearchModel.Currency.ToLower().Trim() != vehicleSearchModel.Vehicle.OriginalCurrency.ToLower().Trim())
                        {
                            reservationMail.Add("<%OriginalPrice%>", Arackiralama.Resources.LanguageFields.VehicleOriginalMailPrice);
                            reservationMail.Add("<%OriginalTotal%>", vehicleSearchModel.Vehicle.OriginalAmount.ToString("#,##") + " " + vehicleSearchModel.Vehicle.OriginalCurrency);
                            reservationMail.Add("<%PriceFarkText%>", Arackiralama.Resources.LanguageFields.VehicleDovizText.Replace("<?Price?>", vehicleSearchModel.Vehicle.OriginalAmount.ToString("#,##")).Replace("<?Currency?>", vehicleSearchModel.Vehicle.OriginalCurrency));
                        }
                        else
                        {
                            reservationMail.Add("<%OriginalPrice%>", "");
                            reservationMail.Add("<%OriginalTotal%>", "");
                            reservationMail.Add("<%PriceFarkText%>", "");
                        }
                        if (rsrvModel.extraFeeHdn != null)
                        {
                            reservationMail.Add("<%ExtraFee%>", feess.Replace("~", "<br>"));
                            reservationMail.Add("<%TotalPrice%>", (VehicleOrder.TotalRate + feePrices).ToString("#.##") + " " + ViewBag.Currency);

                            reservationMail.Add("<%AracToplamRate%>", (VehicleOrder.TotalRate + feePrices).ToString("#.##") + " " + ViewBag.Currency);
                            reservationMail.Add("<%SoforGunluk%>", feess.Replace("~", "<br>"));
                        }
                        else
                        {
                            reservationMail.Add("<%ExtraFee%>", " - ");
                            reservationMail.Add("<%TotalPrice%>", VehicleOrder.TotalRate.ToString("#.##") + " " + ViewBag.Currency);

                            reservationMail.Add("<%AracToplamRate%>", VehicleOrder.TotalRate.ToString("#.##") + " " + ViewBag.Currency);
                            reservationMail.Add("<%SoforGunluk%>", " - ");
                        }
                        //---------------Yeni Eklenen Özellikler
                        reservationMail.Add("<%BugunTarih%>", DateTime.Now.ToString("dd MMMM yyyy"));
                        reservationMail.Add("<%BaslagicOfisi%>", vehicleSearchModel.Vehicle.OfficeName);
                        reservationMail.Add("<%BaslangicOfisAdres%>", vehicleSearchModel.Vehicle.OfficeAddress);
                        reservationMail.Add("<%OfisTelNo%>", vehicleSearchModel.Vehicle.OfficeTel);
                        reservationMail.Add("<%OfisFaxNo%>", "-");
                        reservationMail.Add("<%KiralayanKisi%>", contactModel.FirstName + " " + contactModel.LastName);
                        reservationMail.Add("<%BaslangicTarihSaat%>", vehicleSearchModel.StartAt.ToString("dd MMMM yyyy") + " " + vehicleSearchModel.StartTimeHour);
                        reservationMail.Add("<%IdadeTarihSaat%>", vehicleSearchModel.EndAt.ToString("dd MMMM yyyy") + " " + vehicleSearchModel.EndTimeHour);
                        reservationMail.Add("<%AracSinifi%>", vehicleSearchModel.Vehicle.Name);
                        reservationMail.Add("<%AracTotalRate%>", priceInfo);
                        //reservationMail.Add("<%UserAddress%>", rsrvModel.Account.Address != null ? rsrvModel.Account.Address: " - ");
                        reservationMail.Add("<%UserEmail%>", contactModel.Email);
                        reservationMail.Add("<%UserTel%>", contactModel.Phone != null ? contactModel.Phone : " - ");

                        Models.Helpers.MessageSender mailSender = new Models.Helpers.MessageSender();

                        string mailMessageFrom = System.Configuration.ConfigurationManager.AppSettings["mailMessageFrom"];
                        string mailMessagePassword = System.Configuration.ConfigurationManager.AppSettings["mailMessagePassword"];
                        string mailMessageHost = System.Configuration.ConfigurationManager.AppSettings["mailMessageHost"];
                        int mailMessagePort = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["mailMessagePort"]);
                        string mailMessageTo = contactModel.Email;

                        var messageSubject = "Siparişiniz";
                        string MailPath = Server.MapPath("~/Content/CarTrawler/MailTemplates/") + "VehicleReservationMailMessageV2.txt";
                        mailSender.SendMail(MailPath, mailMessageFrom, mailMessagePassword, mailMessageHost, mailMessagePort, mailMessageTo, reservationMail, messageSubject);



                        //messageSender.SendMail(mailMessageFrom, mailMessagePassword, mailMessageHost, mailMessagePort, mailMessageTo, reservationMail, messageSubject);

                        //mailSender.SendMail(System.Configuration.ConfigurationManager.AppSettings["MailPath"] + "VehicleReservationMailMessageV2.txt", Resources.LanguageFields.VehicleMailSubject, contactModel.Email, reservationMail);
                        //





                        //
                        //---------------Yeni Eklenen Özellikler
                        //Tourism.Utility.Utils.SendMail(System.Configuration.ConfigurationManager.AppSettings["MailPath"] + "VehicleReservationMailMessageV2.txt", Arackiralama.Resources.LanguageFields.VehicleMailSubject, contactModel.Email, reservationMail, string.Empty);

                    }
                    catch (Exception e)
                    {
                        return RedirectToAction("VehicleError", new { errorNum = e.Message });
                    }


                    //buraya mı


                }



                //return RedirectToAction("Thanks", new { uniqueKey = vehicleSearchModel.UniqueKey });

            } //HTTPPOST Bitişi

            return View(vehicleSearchModel);
        }

        //public static void EMailOfferTemplateSendMail(string PassengerCount, string BaggageCount, string DoorCount, string Name, string ThumImage, Nullable<bool> AirConditionInd, Nullable<int> CategoryID, string CompanyImage, string EndOfficeName, string OfficeAddress, string FuelPolicy, string FuelType, string GearType, int ID, Nullable<decimal> TotalRate, Nullable<decimal> TotalAll, string TransmissionType, Nullable<DateTime> ValidEndAt, Nullable<DateTime> ValidStartAt, List<string> VehicleCharges, Nullable<int> TotalDays, string Currency, List<string> PricedCoverages, string Email)
        //{
        //    string path = System.Web.HttpContext.Current.Server.MapPath("~/Content/SteepOneModal/EMailOfferTemplate.html");
        //    string text = System.IO.File.ReadAllText(path);
        //    text = text.Replace("##VehicleName##", Name != null ? Name : "");
        //    text = text.Replace("##CarImage##", ThumImage != null ? ThumImage : "");
        //    if (CategoryID == 1)
        //    {
        //        text = text.Replace("##Category##", "Mini");
        //    }
        //    else if (CategoryID == 3)
        //    {
        //        text = text.Replace("##Category##", "Economy");
        //    }
        //    else if (CategoryID == 4)
        //    {
        //        text = text.Replace("##Category##", "Compact");
        //    }
        //    else if (CategoryID == 6)
        //    {
        //        text = text.Replace("##Category##", "Intermediate");
        //    }
        //    else if (CategoryID == 7)
        //    {
        //        text = text.Replace("##Category##", "Standart");
        //    }
        //    else if (CategoryID == 8)
        //    {
        //        text = text.Replace("##Category##", "FullSize");
        //    }
        //    else if (CategoryID == 9)
        //    {
        //        text = text.Replace("##Category##", "Luxary");
        //    }
        //    else if (CategoryID == 10)
        //    {
        //        text = text.Replace("##Category##", "Premium");
        //    }
        //    else if (CategoryID == 11)
        //    {
        //        text = text.Replace("##Category##", "Minivan");
        //    }
        //    else if (CategoryID == 12)
        //    {
        //        text = text.Replace("##Category##", "12 passanger van");
        //    }
        //    else if (CategoryID == 24)
        //    {
        //        text = text.Replace("##Category##", "Exotic");
        //    }
        //    else
        //    {
        //        text = text.Replace("##Category##", Arackiralama.Resources.LanguageFields.VehicleNonCategory);
        //    }

        //    text = text.Replace("##StartOffice##",  OfficeAddress);
        //    text = text.Replace("##TotalPrice##", TotalRate != null ? TotalRate.ToString() : "");
        //    text = text.Replace(" ##TotalDays##", TotalDays != null ? TotalDays.ToString() +" "+ Arackiralama.Resources.LanguageFields.DayTitle : "");
        //    text = text.Replace("##Currency##", Currency != null ? Currency : "");
        //    text = text.Replace("##PassengerCount##", PassengerCount != null ? PassengerCount : "");
        //    text = text.Replace("##BaggageCount##", BaggageCount != null ? BaggageCount : "");
        //    text = text.Replace("##DoorCount##", DoorCount != null ? DoorCount : "");

        //    string vehiclecharges = "";
        //    foreach (var item in VehicleCharges)
        //    {
        //        vehiclecharges += item+", ";
        //    }
        //    text = text.Replace("##VehicleCharges##", vehiclecharges!=null? vehiclecharges:"");
        //    text = text.Replace("##AirConditionInd##", AirConditionInd == true ? "<tr style='width:100%;'>< td style = 'padding:15px;'>< img src = 'https://www.aracvararac.com/Contents/img/mail-tick.png' style = 'width:20px; height:20px;' /><span>"+Arackiralama.Resources.LanguageFields.AirConditionIng+"</span> </td></tr>":"");
        //    text = text.Replace("##FuelType##", FuelType != null ? FuelType : "");
        //    text = text.Replace("##EndOfficeName##", EndOfficeName != null ? EndOfficeName : "");
        //    text = text.Replace("##CompanyImage##", CompanyImage != null ? CompanyImage : "~/Contents/images/no-image.jpg");
        //    string pricedCoverages = "";
        //    foreach (var item in PricedCoverages)
        //    {
        //        pricedCoverages += item + ", ";
        //    }
        //    text = text.Replace("##PricedCoverages##", pricedCoverages!=null ? pricedCoverages:"");


        //    MailMessage msg = new MailMessage();
        //    string mail = ConfigurationManager.AppSettings["mailMessageFrom"];

        //    msg.From = new MailAddress(mail);
        //    msg.To.Add(Email);
        //    msg.Subject = "aracvararac.com E-Posta Teklifi";
        //    msg.Body = text;

        //    msg.IsBodyHtml = true;
        //    msg.Priority = MailPriority.High;


        //    using (SmtpClient client = new SmtpClient())
        //    {
        //        mail = ConfigurationManager.AppSettings["mailMessageFrom"];
        //        string password = ConfigurationManager.AppSettings["mailMessagePassword"];
        //        string Host = ConfigurationManager.AppSettings["mailMessageHost"];
        //        client.EnableSsl = true;
        //        client.UseDefaultCredentials = false;
        //        client.Credentials = new NetworkCredential(mail,password);
        //        client.Host = Host;
        //        client.Port = 587;
        //        client.DeliveryMethod = SmtpDeliveryMethod.Network;

        //        client.Send(msg);

        //    }

        //}
        public static void EMailOfferTemplateSendMail(EMailOfferSenMailModel model)
        {
            string path = System.Web.HttpContext.Current.Server.MapPath("~/Content/SteepOneModal/EMailOfferTemplate.html");
            string text = System.IO.File.ReadAllText(path);
            text = text.Replace("##VehicleName##", model.Name != null ? model.Name : "");
            text = text.Replace("##CarImage##", model.ThumImage != null ? model.ThumImage : "");
            if (model.CategoryID == 1)
            {
                text = text.Replace("##Category##", "Mini");
            }
            else if (model.CategoryID == 3)
            {
                text = text.Replace("##Category##", "Economy");
            }
            else if (model.CategoryID == 4)
            {
                text = text.Replace("##Category##", "Compact");
            }
            else if (model.CategoryID == 6)
            {
                text = text.Replace("##Category##", "Intermediate");
            }
            else if (model.CategoryID == 7)
            {
                text = text.Replace("##Category##", "Standart");
            }
            else if (model.CategoryID == 8)
            {
                text = text.Replace("##Category##", "FullSize");
            }
            else if (model.CategoryID == 9)
            {
                text = text.Replace("##Category##", "Luxary");
            }
            else if (model.CategoryID == 10)
            {
                text = text.Replace("##Category##", "Premium");
            }
            else if (model.CategoryID == 11)
            {
                text = text.Replace("##Category##", "Minivan");
            }
            else if (model.CategoryID == 12)
            {
                text = text.Replace("##Category##", "12 passanger van");
            }
            else if (model.CategoryID == 24)
            {
                text = text.Replace("##Category##", "Exotic");
            }
            else
            {
                text = text.Replace("##Category##", Arackiralama.Resources.LanguageFields.VehicleNonCategory);
            }

            text = text.Replace("##StartOfficeAddress##", model.StartOfficeAddress != null ? model.StartOfficeAddress:"");
            text = text.Replace("##TotalPrice##", model.TotalRate != null ? model.TotalRate.ToString() : "");
            text = text.Replace(" ##TotalDays##", model.TotalDays != null ? model.TotalDays.ToString() + " " + Arackiralama.Resources.LanguageFields.DayTitle : "");
            text = text.Replace("##Currency##", model.Currency != null ? model.Currency : "");
            text = text.Replace("##PassengerCount##", model.PassengerCount != null ? model.PassengerCount : "");
            text = text.Replace("##BaggageCount##", model.BaggageCount != null ? model.BaggageCount : "");
            text = text.Replace("##DoorCount##", model.DoorCount != null ? model.DoorCount : "");

            string vehiclecharges = "";
            foreach (var item in model.VehicleCharges)
            {
                vehiclecharges += item + ", ";
            }
            text = text.Replace("##VehicleCharges##", vehiclecharges != null ? vehiclecharges : "");
            text = text.Replace("##AirConditionInd##", model.AirConditionInd == true ? "<tr style='width:100%;'>< td style = 'padding:15px;'>< img src = 'https://www.aracvararac.com/Contents/img/mail-tick.png' style = 'width:20px; height:20px;' /><span>" + Arackiralama.Resources.LanguageFields.AirConditionIng + "</span> </td></tr>" : "");
            text = text.Replace("##FuelType##", model.FuelType != null ? model.FuelType : "");
            text = text.Replace("##EndOfficeName##", model.EndOfficeName != null ? model.EndOfficeName : "");
            text = text.Replace("##CompanyImage##", model.CompanyImage != null ? model.CompanyImage : "~/Contents/images/no-image.jpg");
            string pricedCoverages = "";
            foreach (var item in model.PricedCoverages)
            {
                pricedCoverages += item + ", ";
            }
            text = text.Replace("##PricedCoverages##", pricedCoverages != null ? pricedCoverages : "");


            MailMessage msg = new MailMessage();
            string mail = ConfigurationManager.AppSettings["mailMessageFrom"];

            msg.From = new MailAddress(mail);
            msg.To.Add(model.Email);
            msg.Subject = "aracvararac.com E-Posta Teklifi";
            msg.Body = text;

            msg.IsBodyHtml = true;
            msg.Priority = MailPriority.High;


            using (SmtpClient client = new SmtpClient())
            {
                mail = ConfigurationManager.AppSettings["mailMessageFrom"];
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
