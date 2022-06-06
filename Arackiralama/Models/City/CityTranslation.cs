using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Arackiralama.Models
{
    [System.Serializable()]
    public class CityTranslation
    {

        public int ID { get; set; }

       
        public int CityID { get; set; }

     
        public int CultureID { get; set; }

     
        public string Name { get; set; }

  
        public string Slug { get; set; }

        
        public string Information { get; set; }

        public string MetaKeyWord { get; set; }

        public string MetaDescription { get; set; }

     
        public string Html { get; set; }

        public string Title { get; set; }

    
        public virtual City.City City { get; set; }

        public virtual Culture Culture { get; set; }
    }
}