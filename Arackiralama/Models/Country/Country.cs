using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Arackiralama.Models.Country
{
     [System.Serializable()]
    public class Country
    {
  
        public int ID { get; set; }

        public string Code { get; set; }

        public int? RefID { get; set; }

        public bool IsDomestic { get; set; }


        private ICollection<CountryTranslation> _translations;

        public virtual ICollection<CountryTranslation> Translations
        {
            get { return _translations ?? (_translations = new HashSet<CountryTranslation>()); }
            protected set { _translations = value; }
        }

        private ICollection<City.City> _cities;

        public virtual ICollection<City.City> Cities
        {
            get { return _cities ?? (_cities = new HashSet<City.City>()); }
            protected set { _cities = value; }
        }
    }
}
