using System.ComponentModel.DataAnnotations;

namespace Arackiralama.Models
{
    [System.Serializable()]
    public class CountryTranslation
    {
  
        public int ID { get; set; }

     
        public int CountryID { get; set; }

   
        public int CultureID { get; set; }

    
        public string Name { get; set; }

        public string Slug { get; set; }

        
        public virtual Country.Country Country { get; set; }

        public virtual Culture Culture { get; set; }
    }
}