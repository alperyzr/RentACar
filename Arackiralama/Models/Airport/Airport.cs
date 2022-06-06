using System.Collections.Generic;


namespace Arackiralama.Models.Airport
{
	[System.Serializable()]
    public class Airport
    {

        public int ID { get; set; }

     
        public int CityID { get; set; }

        public string Code { get; set; }

        public int? RefID { get; set; }


        public decimal? Latitude { get; set; }


        public decimal? Longitude { get; set; }

		public int Rating { get; set; }

		public int Status { get; set; }

        //public virtual City City { get; set; }

        private ICollection<AirportTranslation> _translations;

        public virtual ICollection<AirportTranslation> Translations
        {
            get { return _translations ?? (_translations = new HashSet<AirportTranslation>()); }
            protected set { _translations = value; }
        }
    }
}