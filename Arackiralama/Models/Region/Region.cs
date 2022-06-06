using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

//namespace Arackiralama.Models.Region
namespace Arackiralama.Models.Region
{
    public class Region
    {
      
        public int ID { get; set; }


        public int CityID { get; set; }

        public string Coordinate { get; set; }

        public bool IsCenter { get; set; }

        public int IsShow { get; set; }

        public int SearchRating { get; set; }

        
        public string Latitude { get; set; }


        public string Longitude { get; set; }

        public int Distance { get; set; }

        public int SearchRadius { get; set; }

        public int RefID { get; set; }

        public virtual City.City City { get; set; }

        private ICollection<RegionTranslation> _translations;


        public virtual ICollection<RegionTranslation> Translations
        {
            get { return _translations ?? (_translations = new HashSet<RegionTranslation>()); }
            protected set { _translations = value; }
        }

   
    }



     
        public class RegionTranslation
        {

            public int ID { get; set; }

          
            public int RegionID { get; set; }

        
            public int CultureID { get; set; }

         
            public string Name { get; set; }

        
            public string Slug { get; set; }


            public virtual Region Region { get; set; }

            public virtual Culture Culture { get; set; }
        }
    
}
