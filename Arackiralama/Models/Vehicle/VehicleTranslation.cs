using System.ComponentModel.DataAnnotations;


namespace Arackiralama.Models
{
	[System.Serializable]
    public class VehicleTranslation
    {
   
        public int ID { get; set; }

    
        public int VehicleID { get; set; }

        public int CultureID { get; set; }

   
        public string Name { get; set; }


        public virtual Vehicle.Vehicle Vehicle { get; set; }

        public virtual Culture Culture { get; set; }
    }
}