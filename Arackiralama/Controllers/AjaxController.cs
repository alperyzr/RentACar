using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web.Mvc;

using System.Web;

namespace Arackiralama.Controllers
{
	public class AjaxController:Controller
    {
        //public JsonResult Newsletter(string culture, string email)
        //{
        //    try
        //    {
        //        email = new MailAddress(email).Address;
        //    }
        //    catch
        //    {
        //        return Json(Tourism.Resources.Home.Index.WrongMail);
        //    }

        //    if (String.IsNullOrWhiteSpace(email))
        //    {
        //        if (culture == "tr")
        //            return Json("Mail Alanı Boş Bırakılamaz");
        //        else
        //            return Json("Please Enter Your E-Mail Address");
        //    }
        //    using (var db = new TourismContext())
        //    {
        //        var cultureModel = db.Cultures.Single(c => c.Code == culture);

        //        if (db.NewsletterRegistrations.All(n => n.Email != email))
        //        {
        //            var newsletterRegistration = db.NewsletterRegistrations.Create();

        //            newsletterRegistration.Culture = cultureModel;

        //            newsletterRegistration.Email = email;

        //            db.NewsletterRegistrations.Add(newsletterRegistration);

        //            db.SaveChanges();

        //        }
        //        else
        //        {
        //            if (culture == "tr")
        //                return Json("Sistemimizde kaydınız bulunmaktadır.");
        //            else
        //                return Json("You have already registered our mail list");
        //        }
        //    }

        //    if (culture == "tr")
        //        return Json("Kaydınız alınmıştır, teşekkürler.");
        //    else
        //        return Json("Thanks for joining the mail list.");
        //}




		//public JsonResult VehicleAutoComplateRegion(string culture, string q) 
		//{
		//	List<Tuple<string, int>> result = new List<Tuple<string, int>>();

		//	using (var db = new TourismContext())
		//	{
		//		var regions = from t in db.VehicleOffices
		//					  select t.RegionID;

		//		var ListRegion = db.Regions.Where(r => (r.Translations.Any(t => t.Slug.StartsWith(q)) || r.City.Translations.FirstOrDefault(t=>t.CultureID == currentCulture.ID).Slug.StartsWith(q)) && r.City.CountryID == 64 && regions.Contains(r.ID)).Take(10);
		//		foreach (var item in ListRegion)
		//		{
		//			result.Add(new Tuple<string, int>(string.Concat(item.Translations.FirstOrDefault(t=>t.CultureID==currentCulture.ID).Name, " - <b>", item.City.Translations.FirstOrDefault(t=>t.CultureID==currentCulture.ID).Name, "</b> - <b>", item.City.Country.Translations.FirstOrDefault(t=>t.CultureID==currentCulture.ID).Name, "</b>"), item.ID));
		//		}
		//	}

		//	return Json(result, JsonRequestBehavior.AllowGet);
		//}

		public JsonResult VehicleComplateRegion(string culture,string q)
		{
            int cultureID = 1;
            if (culture!="tr")
            {
                cultureID = 2;
            }

            List<Tuple<string, int>> result = new List<Tuple<string, int>>();
			
			//q = SearchWordFunctions.WordFunctions(q);



            System.Data.SqlClient.SqlConnection conn = null;
            System.Data.SqlClient.SqlDataReader rdr = null;


            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["RentACar"].ConnectionString;
            try
            {
                // create and open a connection object
                conn = new
                     System.Data.SqlClient.SqlConnection(connStr);
                conn.Open();

                // 1. create a command object identifying
                // the stored procedure

                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(
                    "GetVehicleRegions", conn);

                // 2. set the command object so it knows
                // to execute a stored procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                // 3. add parameter to command, which
                // will be passed to the stored procedure
                cmd.Parameters.Add(
                    new System.Data.SqlClient.SqlParameter("@query", q));
                cmd.Parameters.Add(
                    new System.Data.SqlClient.SqlParameter("@culture",cultureID));

                // execute the command
                rdr = cmd.ExecuteReader();

                // iterate through results, printing each to console
                while (rdr.Read())
                {
                  // select (rt.Name +'- <b>'+ct.Name+'</b> - <b>'+co.Code+'</b>') as Name,r.RefID
                    result.Add(new Tuple<string, int>(string.Concat(rdr[0].ToString(), "- <b>", rdr[1].ToString(), "</b> - <b>", rdr[2].ToString(),"</b>"), Convert.ToInt32(rdr["RefID"])));
                }
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
                if (rdr != null)
                {
                    rdr.Close();
                }
            }	




            //using (var db = new TourismContext())
            //{
            //    /*var regions = from t in db.VehicleOffices
            //                  select t.RegionID;*/

            //    var ListRegion = db.Regions.Where(r => (r.Translations.FirstOrDefault().Slug.Contains(q) || r.City.Translations.FirstOrDefault(t => t.CultureID == currentCulture.ID).Slug.StartsWith(q)) && r.RefID > 0).Take(20);
            //    foreach (var item in ListRegion)
            //    {
            //        result.Add(new Tuple<string, int>(string.Concat(item.Translations.FirstOrDefault(t => t.CultureID == currentCulture.ID).Name, " - <b>", item.City.Translations.FirstOrDefault(t => t.CultureID == currentCulture.ID).Name, "</b> - <b>", item.City.Country.Translations.FirstOrDefault(t => t.CultureID == currentCulture.ID).Name, "</b>"), item.RefID));
            //    }
            //}

			return Json(result, JsonRequestBehavior.AllowGet);
		}




      

     
   

	

       
    }
}
