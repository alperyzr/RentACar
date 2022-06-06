using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Arackiralama.Models.Vehicle
{
	[Serializable]
    public class Vehicle
    {

        public int ID { get; set; }

  
        public int CategoryID { get; set; }

   
        public int PassengerCount { get; set; }

    
        public int DoorCount { get; set; }

      
        public string BaggageCount { get; set; }

    
        public int GearID { get; set; }

      
        public DateTime ValidStartAt { get; set; }

      
        public DateTime ValidEndAt { get; set; }

     
        public decimal StandardPriceRate { get; set; }

        public decimal? HiddenPriceRate { get; set; }

  
        public int CurrencyID { get; set; }


        public Gear Gear
        {
            get { return (Gear) GearID; }
            set { GearID = (int) value; }
        }

        public virtual VehicleCategory Category { get; set; }

		public virtual Currency Currency { get; set; }

        private ICollection<VehicleTranslation> _translations;

        public virtual ICollection<VehicleTranslation> Translations
        {
            get { return _translations ?? (_translations = new HashSet<VehicleTranslation>()); }
            protected set { _translations = value; }
        }

        private ICollection<VehicleProperty.VehicleProperty> _properties;

        public virtual ICollection<VehicleProperty.VehicleProperty> Properties
        {
            get { return _properties ?? (_properties = new HashSet<VehicleProperty.VehicleProperty>()); }
            protected set { _properties = value; }
        }

		private ICollection<VehiclePrice> _prices;

		public virtual ICollection<VehiclePrice> Prices
		{
			get { return _prices ?? (_prices = new HashSet<VehiclePrice>()); }
			protected set { _prices = value; }
		}

        private ICollection<VehicleOffice> _offices;

        public virtual ICollection<VehicleOffice> Offices
        {
            get { return _offices ?? (_offices = new HashSet<VehicleOffice>()); }
            protected set { _offices = value; }
        }
    }

    //[TypeConverter(typeof(EnumToStringUsingDescription))]
    public enum Gear
    {
        //[Description("Manuel")]
        Manual = 1,
        //[Description("Otomatik")]
        Automatic = 2
    }
}