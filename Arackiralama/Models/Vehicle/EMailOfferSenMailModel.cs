using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Arackiralama.Models.Vehicle
{
    public class EMailOfferSenMailModel
    {
        public string PassengerCount { get; set; }
        public string BaggageCount { get; set; }
        public string DoorCount { get; set; }
        public string Name { get; set; }
        public string ThumImage { get; set; }
        public Nullable<bool> AirConditionInd { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public string CompanyImage { get; set; }
        public string StartOfficeAddress { get; set; }
        public string EndOfficeName { get; set; }
        public string OfficeAddress { get; set; }
        public string FuelPolicy { get; set; }
        public string FuelType { get; set; }
        public string GearType { get; set; }
        public int ID { get; set; }
        public string TotalRate { get; set; }
        public Nullable<decimal> TotalAll { get; set; }
        public string TransmissionType { get; set; }
        public Nullable<DateTime> ValidEndAt { get; set; }
        public Nullable<DateTime> ValidStartAt { get; set; }
        public List<string> VehicleCharges { get; set; }
        public Nullable<int> TotalDays { get; set; }
        public string Currency { get; set; }
        public List<string> PricedCoverages { get; set; }
        public string Email { get; set; }
        public Region.RegionTranslation StartRegion { get; set; }
     
    }
}