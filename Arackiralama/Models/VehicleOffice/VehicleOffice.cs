using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Arackiralama.Models
{
	[System.Serializable]
    public class VehicleOffice
    {
 
        public int ID { get; set; }


        public int CompanyID { get; set; }

        public int? RegionID { get; set; }

    
        public decimal? Latitude { get; set; }

   
        public decimal? Longitude { get; set; }

        public string Adress { get; set; }

        public string AuthorizedName { get; set; }

        public string AuthorizedSurname { get; set; }

        public string Title { get; set; }

        public string CompanyPhone { get; set; }

        public string CellPhone { get; set; }

        public string FaxNo { get; set; }

        public string Email { get; set; }

        public string ConfirmMail { get; set; }

		public string WorkTimes { get; set; }

        public virtual Company Company { get; set; }

        public virtual Region.Region Region { get; set; }

        private ICollection<VehicleOfficeTranslation> _translations;

        public virtual ICollection<VehicleOfficeTranslation> Translations
        {
            get { return _translations ?? (_translations = new HashSet<VehicleOfficeTranslation>()); }
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