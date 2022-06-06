using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arackiralama.Models.Vehicle
{
    public class VehicleOrderModel
    {
        public int OrderNum { get; set; }
        public int ReservationStatus { get; set; }
        public string VehicleName { get; set; }
        public int VehicleID { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public decimal TotalRate { get; set; }
        public string CurrencyCode { get; set; }
        public string ExpHotelImage { get; set; }
        public string StartOfficeName { get; set; }
        public string EndOfficeName { get; set; }
       
    }
}
