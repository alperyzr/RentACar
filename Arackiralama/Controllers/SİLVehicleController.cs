//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web.Mvc;


//using System.Web.Security;
//using System.Globalization;
//using System.Xml;
//using System.Net;
//using System.IO;
//using System.Text;
//using System.Text.RegularExpressions;

//namespace Tourism.Controllers
//{
//	public class VehicleController : Controller
//	{
//		public ActionResult iframeVehicle()
//		{
//			return View();
//		}
//		protected override void OnActionExecuting(ActionExecutingContext filterContext)
//		{
//			base.OnActionExecuting(filterContext);

//			if (RouteData.Values["culture"] as string == "tr")
//			{

//				ViewBag.Title = "En hesaplı araç kiralamının yolu aracvararac.com - Ucuz Araç kiralama";
//				ViewBag.Keywords = ": Araç kiralama, ucuz oto rent, hesaplı araç kiralama, İstanbul rent a car, araç kiralama Antalya, en ucuz araba kiralama, avis fiyatları, budget rent a car, side arackiralama, en iyi fiyat, araç kira fiyatları, kampanya, araç, avis, budget, dollar, hertz, national, sixt";
//				ViewBag.Description = "Turkiye'de ve tüm dünyada en ucuz araç kiralama fiyatları aracvararac.com'da. En tanınmış araba kiralama firmalarını karşılaştırıp, en uygun fiyatlı aracı kiralayın. Avis, budget, hertz, dollar ve diğer firmaların filolarini en iyi fiyat garantisi ile hemen ayırtın.";

//			}
//			else
//			{
//				ViewBag.Title = "Cheap Car Rentals in Turkey – Best prices for car rental around the world.";
//				ViewBag.Keywords = "Rent a car, cheap car rentals, avis, budget, dollar, hertz, discount car rentals, Car reservations, book your car, worldwide car rentals, Istanbul rent a car, Turkey rent a car, Antalya car rentals, bodrum rent a car, izmir car rentals";
//				ViewBag.Description = "Best car rental prices in Turkey and around the world. aracvararac.com offers guaranteed best prices for car rentals. Rent your car all around the world and save on rent a car. ";
//			}
//		}

//		public ActionResult Index()
//		{
//			//return Redirect("http://www.xxxx.com" + Url.Action("iframeVehicle", "Vehicle"));

//			//var vehicleSearchModel = new VehicleSearchModel();

//			//vehicleSearchModel.StartAt = DateTime.Today.AddDays(1);
//			//vehicleSearchModel.EndAt = DateTime.Today.AddDays(2);

//			return View();
//		}

	
//		DateTime tarih;

//		decimal topPrice = 0;
	

//		DateTime GeciciTarih;
	

//		public ActionResult VehicleError(string errorNum)
//		{
//			Dictionary<string, string> ErrorArr = new Dictionary<string, string>();
//			ErrorArr.Add("3", "No service on requested date Supplier does not support");
//			ErrorArr.Add("15", "Invalid date Invalid pickup/return date");
//			ErrorArr.Add("83", "Leg/journey/itinerary reference invalid Validation check failed. Pickup date/time/location or Return date/time/location do not match details in Reservation.");
//			ErrorArr.Add("95", "Booking already cancelled Self-Explanatory.");
//			ErrorArr.Add("97", "Booking reference not found The booking reference has expired. You will need to obtain a fresh Booking reference by doing a fresh availability.");
//			ErrorArr.Add("99", "Booking not owned by requester Reservation was not created by your POS Id.");
//			ErrorArr.Add("161", "Search Criteria Invalid The search returned to many records and cannot be returned. The OTA Specifies that 100 is the maximum number of records returned from a Search. You must narrow the search criteria.");
//			ErrorArr.Add("189", "Payment not authorised Credit card authorisation refused");
//			ErrorArr.Add("193", "Cancellation process failed Basic validation failed. Verify that CancelType=Book Verify that Reservation ID is present in ID attribute of UniqueID.");
//			ErrorArr.Add("194", "No matching bookings found Could not find Reservation.");
//			ErrorArr.Add("214", "Dropoff date time not within operating hours Self explanatory");
//			ErrorArr.Add("219", "Need advance notice for this pickup time Self explanatory");
//			ErrorArr.Add("226", "Pickup date has passed Pickup date for Reservation has already passed.");
//			ErrorArr.Add("227", "Pickup date time not within operating hours Self explanatory");
//			ErrorArr.Add("229", "Pickup location not recognized Invalid pickup location supplied");
//			ErrorArr.Add("233", "Return location not Invalid return location supplied");
//			ErrorArr.Add("240", "Credit card has expired Credit card expiry date has expired");
//			ErrorArr.Add("264", "Reservation cannot be cancelled Reservation is in a state that prevents it from being cancelled. e.g. It is not in a confirmed state");
//			ErrorArr.Add("281", "Reservation requires credit card data Reservation requires a credit card, and none is present.");
//			ErrorArr.Add("292", "Country in address is invalid Self explanatory");
//			ErrorArr.Add("309", "Requested rate may have changed - note rate The car supplier is not able to process this car reservation at this time. This could be an intermittent problem with the supplier. We recommend the customer chooses a different car.");
//			ErrorArr.Add("319", "Required data missing: address Self explanatory");
//			ErrorArr.Add("352", "Invalid credit card type Credit card type (i.e. Visa / MasterCard ) is not supported.");
//			ErrorArr.Add("365", "Error credit card Generic error occurred processing the credit card");
//			ErrorArr.Add("10001", "No service on requested pickup date Self explanatory");
//			ErrorArr.Add("10002", "No service on requested dropoff date Self explanatory Unsupported XML Request The ‘Version’ attribute in the root element of the request is not supported.");
//			ErrorArr.Add("10004", "Search returned no records The search returned no records.");
//			ErrorArr.Add("10005", "Error with Credit Card Processor A problem has occurred with our Credit Card Processor.");
//			ErrorArr.Add("10006", "Location Mismatch The locations passed in the Reservation message do not match the locations used in the original availability message.");
//			ErrorArr.Add("10009", "Invalid Credit Card Verification number Self Explanatory");
//			ErrorArr.Add("10011", "The Credit Card Number does not correspond to the Credit Card Type Self Explanatory");
//			ErrorArr.Add("10012", "Invalid Credit Card Issue number Self Explanatory");
//			ErrorArr.Add("10014", "Commercial terms vary between availability and booking request - significant variation in consumer residence or driver age This means that key information like drivers age/consumer residence/currency has changed between the availability and the reservation message. If this is detected then it is not possible to proceed with the reservation.");
//			ErrorArr.Add("10015", "Required data missing: drivers age Self Explanatory");
//			ErrorArr.Add("10016", "Location must be an Airport Location Only Airport locations are allowed for this Client.");
//			ErrorArr.Add("10017", "Car is not available Car requested to be booked is no longer available.");
//			ErrorArr.Add("10019", "Required data missing: Consumer IP address Self Explanatory");
//			ErrorArr.Add("10020", "Invalid VehRentalCore Low level error if no ‘VehRentalCore’ element is found in a OTA_VehResRQ message.");
//			ErrorArr.Add("10021", "Unfortunately we are unable to process your booking at this time The car supplier is not able to process this car reservation at this time. This could be an intermittent problem with the supplier. We recommend the customer chooses a different car.");
//			ErrorArr.Add("10022", "Expiry date invalid Self Explanatory");
//			ErrorArr.Add("10023", "Card number fails Luhn Check.Please try again Self Explanatory");
//			ErrorArr.Add("10024", "NonNumeric in Credit card number Self Explanatory");
//			ErrorArr.Add("10026", "Expiry month invalid Self Explanatory");

//			Dictionary<string, string> ErrorArrTR = new Dictionary<string, string>();
//			ErrorArrTR.Add("3", "İstenilen tarihte hizmet bulunamadı. Sağlayıcı desteği yok.");
//			ErrorArrTR.Add("15", "Geçersiz tarih Geçersiz teslimat/iade tarihi.");
//			ErrorArrTR.Add("83", " Geçersiz seyahat ayağı/yolculuk referansı.Geçerlilik kontrolü başarısız. Teslimat tarihi/zamanı/lokasyonu ya da İade tarihi/zamanı/lokasyonu rezervasyon detayları ile uyumsuz.");
//			ErrorArrTR.Add("95", "Rezervasyon zaten iptal edilmiş.");
//			ErrorArrTR.Add("97", "Rezervasyon referansı bulunamadı. Rezervasyon referansının süresi dolmuş.Yeni bir uygunluk araması yaparak yeni bir rezervasyon referansı almanız gerekiyor.");
//			ErrorArrTR.Add("99", "İstem sahibi Rezervasyon sahibi değil. Rezervasyon sizin POS'unuz tarafından oluşturulmamış.");
//			ErrorArrTR.Add("161", "Arama kriterleri geçersiz.Arama çok fazla sonuç getirdi ve gösterilemiyor. OTA'ya göre bir aramadan en fazla 100 adet sonuç getirilebilir. Arama kriterlerinizi daraltın.");
//			ErrorArrTR.Add("189", "Ödeme için yetki alınamadı. Kredi Kartı ödemesi reddedildi.");
//			ErrorArrTR.Add("193", "İptal işlemi başarısız. Temel doğrulama başarısız. CancelType=Book olduğundan emin olun. UniqueID'nin ID sekmesinde Reservasyon ID'si olduğundan emin olun.");
//			ErrorArrTR.Add("194", "Eşleşen bir rezervasyon bulunamadı. Rezervasyon bulunamadı.");
//			ErrorArrTR.Add("214", "Bu teslimat için önceden bildirim olması gerekli.");
//			ErrorArrTR.Add("219", "Araç teslim tarihi geçmiş. Bu rezervasyon için araç teslim saati geçmiş durumda.");
//			ErrorArrTR.Add("226", "Araç teslim tarihi geçmiş. Bu rezervasyon için araç teslim saati geçmiş durumda.");
//			ErrorArrTR.Add("227", "Araç teslim tarihi ve saati çalışma saatleri dışında.");
//			ErrorArrTR.Add("229", "Araç teslim lokasyonu bulunamadı. Geçersiz teslimat adresi.");
//			ErrorArrTR.Add("233", "Araç iade lokasyonu bulunamadı. Geçersiz iade adresi.");
//			ErrorArrTR.Add("240", "Kredi Kartı'nın süresi geçmiş. Kredi KArtı'nın son kullanma tarihi geçmiş.");
//			ErrorArrTR.Add("264", "Rezervasyon iptal edilemez. Rezervasyon iptal etmeye elverişli değil. Yani henüz konfirme edilmemiş.");
//			ErrorArrTR.Add("281", "Rezervasyon için kredi kartı bilgileri gerekli. Rezervasyonun gerçekleşmesi için kredi kartı bilgileri girilmelidir.");
//			ErrorArrTR.Add("292", "Adresteki ülke adı geçersiz.");
//			ErrorArrTR.Add("309", "İstenen fiyat değişmiş olabilir. Araç kiralama şirketi şu an bu rezervasyona izin vermiyor. Bu geçici bir sorun olabilir. Müşterinin bir başka araç seçmesini öneririz.");
//			ErrorArrTR.Add("319", "Gerekli olan bir bilgi eksik: Adres.");
//			ErrorArrTR.Add("352", "Geçersiz kredi kartı cinsi. Bu Kredi KArtı (Visa/MAstercard, vb) desteklenmiyor.");
//			ErrorArrTR.Add("365", "Kredi Kartı hatası. Kredi KArtı işleminde genel bir sorun var.");
//			ErrorArrTR.Add("10001", "İstenen teslim tarihinde hizmet verilemiyor.");
//			ErrorArrTR.Add("10002", "İstenen tarihte araç iadesi yapılamıyor. . Desteklenmeyen XML istemi. İstemin kök öğesindeki Versiyon niteliği desteklenmiyor.");
//			ErrorArrTR.Add("10004", "Arama sonuç bulamadı. Aramaya uygun kayıt bulunamadı.");
//			ErrorArrTR.Add("10005", "Kredi Kartı işlemcisinde hata oluştu. Kredi Kartı işlemcimizde bir sorun yaşandı.");
//			ErrorArrTR.Add("10006", "Lokasyon uyumsuzluğu. Rezervasyon mesajındaki lokasyon bilgisi orijinal uygunluk mesajındaki lokasyon bilgisi ile uyuşmuyor.");
//			ErrorArrTR.Add("10009", "Geçersiz kredi kartı doğrulama numarası.");
//			ErrorArrTR.Add("10011", "Girilen Kredi kartı numarası Kredi kartı türü ile uyuşmuyor.");
//			ErrorArrTR.Add("10012", "Geçersiz Kredi KArtı numarası.");
//			ErrorArrTR.Add("10014", "Uygunluk ile rezervasyon isteği arasındaki ticari şartlar farklı -Müşterinin ikametgah adresi ya da yaşı ile ilgili bilgiler farklı. Yani müşterinin yaşı/ikametgahı/para cinsi bilgileri uygunluk zamanı  ile rezervasyon zamanı arasında değişiklik gösteriyor. Bu yüzden rezervasyon işlemine devam edilemiyor.");
//			ErrorArrTR.Add("10015", "Gerekli olan bir bilgi eksik: Kullanıcının yaşı.");
//			ErrorArrTR.Add("10016", "Lokasyon bir havalimanı olmak zorunda. Bu müşteri için sadece havalanı lokasyonları kullanılabilir.");
//			ErrorArrTR.Add("10017", "Araç müsait değil. rezervasyon için istenen araç müsait değil.");
//			ErrorArrTR.Add("10019", "Gerekli olan bir bilgi eksik: Müşteri IP adresi.");
//			ErrorArrTR.Add("10020", "Geçersiz VehRentalCore. OTA_VehResRQ mesajında VahRentalCore öğesi bulunmadığında oluşan düşük seviyeli hata.");
//			ErrorArrTR.Add("10021", "Maalesef şu anda rezervasyonunuzu gerçekleştiremiyoruz.  Şu anda araç kiralama şirketi bu araç kiralama rezervasyonunu gerçekleştiremiyor. Bu sorun geçici bir süre için geçerli olabilir. Başka araç seçmenizi tavsiye ederiz.");
//			ErrorArrTR.Add("10022", "Son kullanım tarihi geçersiz.");
//			ErrorArrTR.Add("10023", "Kart numarası Luhn Kontrolünde başarısız. Lütfen yeniden deneyiniz.");
//			ErrorArrTR.Add("10024", "Kredi Kartında numara olmayan bilgi.");
//			ErrorArrTR.Add("10026", "Son kullanım tarihi ay bilgisi geçersiz.");

//			if (ErrorArr.Keys.Contains(errorNum))
//			{
//				Session["ErrorMessage"] = ViewBag.Culture == "tr" ? ErrorArrTR[errorNum] : ErrorArr[errorNum];
//			}
//			else
//			{
//				Session["ErrorMessage"] = "Bilinmeyen bir hata oluştu.";
//			}

//			return View();
//		}

//		private void RedirectSessionClear()
//		{
//			Session["UcusURL"] = null;
//			Session["OtelURL"] = null;
//			Session["AracURL"] = null;
//			Session["FSBURL"] = null;
//			Session["PackageUrl"] = null;
//			Session["HFSBUrl"] = null;
//		}

//		private void ErrorLog(string p, string name)
//		{
//			System.IO.StreamWriter file = new System.IO.StreamWriter(System.Configuration.ConfigurationManager.AppSettings["aracvararacErrorLog"] + "VehicleErrorLog\\" + name + ".xml");
//			file.WriteLine(p);
//			file.Close();
//		}
//	}

//	public class vuserDT
//	{
//		public int ID { get; set; }
//		public string Email { get; set; }
//		public string FirstName { get; set; }
//		public string LastName { get; set; }
//		public string Description { get; set; }
//		public string Phone { get; set; }
//		public string CellPhone { get; set; }
//		public string Address { get; set; }
//		public string GovermentNo { get; set; }
//	}








//		//public class VehicleSearchModel
//		//{
//		//	public VehicleSearchModel()
//		//	{
//		//		UniqueKey = Guid.NewGuid();
//		//		StartOfficeList = new List<Tuple<int, string>>();
//		//		EndOfficeList = new List<Tuple<int, string>>();
//		//	}

//		//	public Guid UniqueKey { get; set; }

//		//	public int? StartRegionID { get; set; }

//		//	public DateTime StartAt { get; set; }

//		//	public string StartTimeHour { get; set; }

//		//	public int StartTimeMinute { get; set; }

//		//	public int? EndRegionID { get; set; }

//		//	public DateTime EndAt { get; set; }

//		//	public string EndTimeHour { get; set; }

//		//	public int EndTimeMinute { get; set; }

//		//	public int StartOfficeID { get; set; }

//		//	public int EndOfficeID { get; set; }

//		//	public string Country { get; set; }

//		//	public string Currency { get; set; }
//		//	public int TotalDays
//		//	{
//		//		get
//		//		{
//		//			return (int)EndAt.Subtract(StartAt).TotalDays;
//		//		}
//		//	}





//		//	public List<Tuple<int, string>> StartOfficeList { get; set; }
//		//	public List<Tuple<int, string>> EndOfficeList { get; set; }
//		//}
//	}











////using System;
////using System.Collections.Generic;
////using System.Data;
////using System.Data.Entity;
////using System.Linq;
////using System.Net;
////using System.Web;
////using System.Web.Mvc;
////using Arackiralama.Models;

////namespace Arackiralama.Controllers
////{
////    public class VehicleController : Controller
////    {
////        private AracKiralamaEntities1 db = new AracKiralamaEntities1();

////        // GET: Vehicle
////        public ActionResult Index()
////        {
////            var car = db.Car.Include(c => c.CarPointScale).Include(c => c.Company).Include(c => c.ExtraMaterial);
////            return View(car.ToList());
////        }

////        // GET: Vehicle/Details/5
////        public ActionResult Details(Guid? id)
////        {
////            if (id == null)
////            {
////                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
////            }
////            Car car = db.Car.Find(id);
////            if (car == null)
////            {
////                return HttpNotFound();
////            }
////            return View(car);
////        }

////        // GET: Vehicle/Create
////        public ActionResult Create()
////        {
////            ViewBag.CarPoitScaleID = new SelectList(db.CarPointScale, "ID", "PuanAraligi");
////            ViewBag.CompanyID = new SelectList(db.Company, "ID", "Logo");
////            ViewBag.CarExtraMaterialID = new SelectList(db.ExtraMaterial, "ID", "Icon");
////            return View();
////        }

////        // POST: Vehicle/Create
////        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
////        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
////        [HttpPost]
////        [ValidateAntiForgeryToken]
////        public ActionResult Create([Bind(Include = "ID,CompanyID,Marka,Model,Sinif,Segment,Resim,KisiSayisi,BagajKapasitesi,KapiSaysi,Sanzuman,YakitTuru,CarPoitScaleID,CarExtraMaterialID,KiralamaTutari,EklendigiTarih,EkleyenKisi,GuncellendigiTarih,GuncelleyenKisi,IsActive")] Car car)
////        {
////            if (ModelState.IsValid)
////            {
////                car.ID = Guid.NewGuid();
////                db.Car.Add(car);
////                db.SaveChanges();
////                return RedirectToAction("Index");
////            }

////            ViewBag.CarPoitScaleID = new SelectList(db.CarPointScale, "ID", "PuanAraligi", car.CarPoitScaleID);
////            ViewBag.CompanyID = new SelectList(db.Company, "ID", "Logo", car.CompanyID);
////            ViewBag.CarExtraMaterialID = new SelectList(db.ExtraMaterial, "ID", "Icon", car.CarExtraMaterialID);
////            return View(car);
////        }

////        // GET: Vehicle/Edit/5
////        public ActionResult Edit(Guid? id)
////        {
////            if (id == null)
////            {
////                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
////            }
////            Car car = db.Car.Find(id);
////            if (car == null)
////            {
////                return HttpNotFound();
////            }
////            ViewBag.CarPoitScaleID = new SelectList(db.CarPointScale, "ID", "PuanAraligi", car.CarPoitScaleID);
////            ViewBag.CompanyID = new SelectList(db.Company, "ID", "Logo", car.CompanyID);
////            ViewBag.CarExtraMaterialID = new SelectList(db.ExtraMaterial, "ID", "Icon", car.CarExtraMaterialID);
////            return View(car);
////        }

////        // POST: Vehicle/Edit/5
////        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
////        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
////        [HttpPost]
////        [ValidateAntiForgeryToken]
////        public ActionResult Edit([Bind(Include = "ID,CompanyID,Marka,Model,Sinif,Segment,Resim,KisiSayisi,BagajKapasitesi,KapiSaysi,Sanzuman,YakitTuru,CarPoitScaleID,CarExtraMaterialID,KiralamaTutari,EklendigiTarih,EkleyenKisi,GuncellendigiTarih,GuncelleyenKisi,IsActive")] Car car)
////        {
////            if (ModelState.IsValid)
////            {
////                db.Entry(car).State = EntityState.Modified;
////                db.SaveChanges();
////                return RedirectToAction("Index");
////            }
////            ViewBag.CarPoitScaleID = new SelectList(db.CarPointScale, "ID", "PuanAraligi", car.CarPoitScaleID);
////            ViewBag.CompanyID = new SelectList(db.Company, "ID", "Logo", car.CompanyID);
////            ViewBag.CarExtraMaterialID = new SelectList(db.ExtraMaterial, "ID", "Icon", car.CarExtraMaterialID);
////            return View(car);
////        }

////        // GET: Vehicle/Delete/5
////        public ActionResult Delete(Guid? id)
////        {
////            if (id == null)
////            {
////                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
////            }
////            Car car = db.Car.Find(id);
////            if (car == null)
////            {
////                return HttpNotFound();
////            }
////            return View(car);
////        }

////        // POST: Vehicle/Delete/5
////        [HttpPost, ActionName("Delete")]
////        [ValidateAntiForgeryToken]
////        public ActionResult DeleteConfirmed(Guid id)
////        {
////            Car car = db.Car.Find(id);
////            db.Car.Remove(car);
////            db.SaveChanges();
////            return RedirectToAction("Index");
////        }

////        protected override void Dispose(bool disposing)
////        {
////            if (disposing)
////            {
////                db.Dispose();
////            }
////            base.Dispose(disposing);
////        }
////    }
////}
