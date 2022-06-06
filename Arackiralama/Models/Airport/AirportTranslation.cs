using System.ComponentModel.DataAnnotations;

namespace Arackiralama.Models
{
	[System.Serializable()]
    public class AirportTranslation
    {

        public int ID { get; set; }

   
        public int AirportID { get; set; }

     
        public int CultureID { get; set; }

     
        public string Name { get; set; }

      
        public string Slug { get; set; }

        
        public virtual Airport.Airport Airport { get; set; }

        //public virtual Culture Culture { get; set; }
    }
}