//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace RentACar.Data.Model.Query
//{
//   public class SearchRequest
//    {
//        public ServiceError ServiceError { get; set; }
//        public FlightBookingTravelType FlightBookingTravelType { get; set; }
//        public List<RequestedFlightSegment> RequestedFlightSegments { get; set; }


//		string path = System.Configuration.ConfigurationManager.AppSettings["CarPath"] + "detailService.xsd";
//		string readText = System.IO.File.ReadAllText(path);


//		string Deger = readText.Replace("\\", string.Empty);

//		Deger = Deger.Replace("<?StartDate?>", startDate + "T" + vehicleSearchModel.StartTimeHour + ":00");
//			Deger = Deger.Replace("<?EndDate?>", endDate + "T" + vehicleSearchModel.EndTimeHour + ":00");

//			Deger = Deger.Replace("<?StartLocation?>", vehicleSearchModel.StartRegionID.ToString());
//			Deger = Deger.Replace("<?ReturnLocation?>", vehicleSearchModel.EndRegionID.ToString());

//			Deger = Deger.Replace("<?Culture?>", currentCulture.Code);

//			Deger = Deger.Replace("<?Currency?>", vehicleSearchModel.Currency);

//			Deger = Deger.Replace("<?Country?>", vehicleSearchModel.Country == null ? "TR" : vehicleSearchModel.Country);

//			if (Request.ServerVariables != null)
//			{
//				if (Request.ServerVariables["REMOTE_ADDR"] != null)
//				{
//					Deger = Deger.Replace("<?ClientIP?>", "85.105.17.177");//Request.ServerVariables["REMOTE_ADDR"]);
//				}
//				else
//				{
//					Deger = Deger.Replace("<?ClientIP?>", "85.105.17.177");
//				}
//			}
//			else
//			{
//				Deger = Deger.Replace("<?ClientIP?>", "85.105.17.177");
//			}
//    }
//}
