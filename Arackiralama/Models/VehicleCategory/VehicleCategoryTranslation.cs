using System.ComponentModel.DataAnnotations;
namespace Arackiralama.Models
{
	[System.Serializable()]
    public class VehicleCategoryTranslation
    {

        public int ID { get; set; }

   
        public int VehicleCategoryID { get; set; }

      
        public int CultureID { get; set; }

       
        public string Name { get; set; }

      
        public string Description { get; set; }


        public virtual VehicleCategory VehicleCategory { get; set; }

        public virtual Culture Culture { get; set; }
    }
}