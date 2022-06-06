using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Arackiralama.Models
{
	[System.Serializable]
    public class VehicleCategory
    {
  
        public int ID { get; set; }

     
        public string ImageUrl { get; set; }

		public int Sequence { get; set; }

        private ICollection<VehicleCategoryTranslation> _translations;

        public virtual ICollection<VehicleCategoryTranslation> Translations
        {
            get { return _translations ?? (_translations = new HashSet<VehicleCategoryTranslation>()); }
            protected set { _translations = value; }
        }

        private ICollection<Vehicle.Vehicle> _vehicles;

        public virtual ICollection<Vehicle.Vehicle> Vehicles
        {
            get { return _vehicles ?? (_vehicles = new HashSet<Vehicle.Vehicle>()); }
            protected set { _vehicles = value; }
        }
    }
}