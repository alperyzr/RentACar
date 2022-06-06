using System;
using System.Collections.Generic;

namespace Arackiralama.Models
{
	[Serializable]
    public class VehicleModel
    {
		public int point;

        public int ID { get; set; }

        public int CategoryID { get; set; }

		public string GearType { get; set; }

        public string PassengerCount { get; set; }

		public string FuelType { get; set; }

        public string DoorCount { get; set; }

        public string BaggageCount { get; set; }

        public DateTime ValidStartAt { get; set; }

        public DateTime ValidEndAt { get; set; }

        public int? CurrencyID { get; set; }

        public Currency Currency { get; set; }

		public decimal avarageRate { get; set; }

		public decimal TotalRate { get; set; }
		public decimal TotalAll { get; set; }
		public string CompanyEmail { get; set; }

		public string CompanyImage { get; set; }

		public string CompanyName { get; set; }

		public string ThumImage { get; set; }

		public string OfficeName { get; set; }

		public string OfficeAddress { get; set; }

		public string OfficeTel { get; set; }

		public string Url { get; set; }

		public string ReferanceID { get; set; }

		public string FuelPolicy { get; set; }

		public string StartOfficeLatitude { get; set; }

		public string StartOfficeLongitude { get; set; }

		public string EndOfficeLatitude { get; set; }

		public string EndOfficeLongitude { get; set; }

		public string EndOfficeName { get; set; }

		public string EndOfficeAddress { get; set; }

		public string EndOfficeTel { get; set; }

        public string Name { get; set; }

		public decimal OriginalAmount { get; set; }

		public string OriginalCurrency { get; set; }

		//public List<VehicleFeePrice> VehicleFee { get; set; }

		public List<string> VehicleCharges { get; set; }

		public List<Tuple<string, decimal, int, string>> IncludePrice { get; set; }

		public List<string> PricedCoverages { get; set; }
		
		public List<string> vehicleImage { get; set; }

		public string CC_Info { get; set; }
        public List<PricedEquip> PricedEquips { get; internal set; }
        public bool AirConditionInd { get;  set; }
        public string TransmissionType { get;  set; }
        public VehicleOrders VehicleOrders { get; set; }
    }
}