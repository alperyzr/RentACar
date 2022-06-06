using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Arackiralama.Models
{
	[Serializable]
    public class VehicleSearchModel
    {
       

        public VehicleSearchModel()
        {
            UniqueKey = Guid.NewGuid();
			StartOfficeList = new List<Tuple<int, string>>();
			EndOfficeList = new List<Tuple<int, string>>();
        }

        public Guid UniqueKey { get; set; }

        public int? StartRegionID { get; set; }
        public string extraFeeHdn { get; set; }
        public DateTime StartAt { get; set; }

        public string StartTimeHour { get; set; }

        public int StartTimeMinute { get; set; }

        public int? EndRegionID { get; set; }

        public DateTime EndAt { get; set; }

        public string EndTimeHour { get; set; }

        public int EndTimeMinute { get; set; }
               
		public int StartOfficeID { get; set; }

		public int EndOfficeID { get; set; }

		public string Country { get; set; }

        public string Currency { get; set; }
        public int TotalDays
        {
            get
            {
                return (int)EndAt.Subtract(StartAt).TotalDays;
            }
        }

        public  Region.RegionTranslation StartRegion { get; set; }

        public Region.RegionTranslation EndRegion { get; set; }

        public Dictionary<VehicleCategoryTranslation, List<VehicleModel>> Results { get; set; }

		public Orders Orders { get; set; }

        public VehicleModel Vehicle { get; set; }

		public List<VehicleModel> VehicleList { get; set; }

		public List<VehicleModel> VehicleOtherList { get; set; }
        public List<VehicleModel> OrigionalVehicleList { get;  set; }

        public VehicleOfficeTranslation StartOffice { get; set; }

        public VehicleOfficeTranslation EndOffice { get; set; }

		public List<Tuple<int, string>> StartOfficeList { get; set; }
		public List<Tuple<int, string>> EndOfficeList { get; set; }
      
    }
}