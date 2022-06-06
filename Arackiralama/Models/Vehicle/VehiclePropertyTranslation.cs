using System.ComponentModel.DataAnnotations;

namespace Arackiralama.Models
{
	[System.Serializable]
    public class VehiclePropertyTranslation
    {
      
        public int ID { get; set; }

     
        public int VehiclePropertyID { get; set; }

      
        public int CultureID { get; set; }

        [Required]
        public string Name { get; set; }


        public virtual VehicleProperty.VehicleProperty VehicleProperty { get; set; }

        public virtual Culture Culture { get; set; }
    }
}