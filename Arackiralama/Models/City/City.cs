using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Arackiralama.Models.City
{
    [System.Serializable()]
    public class City
    {
 
        public int ID { get; set; }

     
        public int CountryID { get; set; }

        public string Code { get; set; }

        public int? RefID { get; set; }

       
        public bool IsCapital { get; set; }

 
        public decimal? Latitude { get; set; }

  
        public decimal? Longitude { get; set; }

		public int Distance { get; set; }

		public int SearchRadius { get; set; }

        public virtual Country.Country Country { get; set; }

        private ICollection<CityTranslation> _translations;

        public virtual ICollection<CityTranslation> Translations
        {
            get { return _translations ?? (_translations = new HashSet<CityTranslation>()); }
            protected set { _translations = value; }
        }

        //private ICollection<CityInformation> _cityInformations;

        //public virtual ICollection<CityInformation> CityInformations
        //{
        //    get { return _cityInformations ?? (_cityInformations = new HashSet<CityInformation>()); }
        //    protected set { _cityInformations = value; }
        //}

        private ICollection<Region.Region> _regions;

        public virtual ICollection<Region.Region> Regions
        {
            get { return _regions ?? (_regions = new HashSet<Region.Region>()); }
            protected set { _regions = value; }
        }

        private ICollection<Airport.Airport> _airports;

        public virtual ICollection<Airport.Airport> Airports
        {
            get { return _airports ?? (_airports = new HashSet<Airport.Airport>()); }
            protected set { _airports = value; }
        }
    }
}
