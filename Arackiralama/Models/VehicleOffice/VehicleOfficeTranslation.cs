using System.ComponentModel.DataAnnotations;
namespace Arackiralama.Models
{
	[System.Serializable()]
    public class VehicleOfficeTranslation
    {
   
        public int ID { get; set; }

 
        public int VehicleOfficeID { get; set; }

      
        public int CultureID { get; set; }

  
        public string Name { get; set; }


        public virtual VehicleOffice VehicleOffice { get; set; }

        public virtual Culture Culture { get; set; }
    }
}