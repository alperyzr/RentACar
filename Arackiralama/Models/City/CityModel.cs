using System;
using System.Collections.Generic;
using System.Web.Mvc;
namespace Arackiralama.Models.City
{
    public class CityModel
    {
        public int ID { get; set; }

        public int CountryID { get; set; }

        public Country.CountryModel Country { get; set; }

        public string Code { get; set; }

        public int? RefID { get; set; }

        public decimal? Latitude { get; set; }

        public decimal? Longitude { get; set; }

        public decimal? Temp { get; set; }

        public string TempUrl { get; set; }

        public string Slug { get; set; }

        public string Name { get; set; }

		public string menu { get; set; }

		public string tab { get; set; }

		public int Distance { get; set; }

        public string MetaKeyWord { get; set; }

        public string MetaDescription { get; set; }

        public int CountryPageNumber { get; set; }

        public string Html { get; set; }

        public string Title { get; set; }

        public string Information { get; set; }

  //      public CityInformation.CityInformationModel[] CityInformationModels { get; set; }

  //      public CityInformationDetail.CityInformationDetailModel[] CityInformationDetailModels { get; set; }

		//public List<CityInformationDetail.CityInformationDetailModel> InfoDetail { get; set; }

		//public List<CityLandMarkerModel> LandMarker { get; set; }

  //      public CityHotelsModel CityHotels { get; set; }

  //      public List<Tuple<int,string, string>> CityHotelsList { get; set; }

    }
}