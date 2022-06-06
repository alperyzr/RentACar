using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Arackiralama.Models.VehicleProperty
{
	[System.Serializable]
    public class VehicleProperty
    {
      
        public int ID { get; set; }


        private ICollection<VehiclePropertyTranslation> _translations;

        public virtual ICollection<VehiclePropertyTranslation> Translations
        {
            get { return _translations ?? (_translations = new HashSet<VehiclePropertyTranslation>()); }
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