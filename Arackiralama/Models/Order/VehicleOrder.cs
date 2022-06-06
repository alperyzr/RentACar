using System;
using System.ComponentModel.DataAnnotations;

namespace Arackiralama.Models
{
	[Serializable]
    public class VehicleOrder
    {
 
        public int ID { get; set; }

   
        public int VehicleID { get; set; }

		public int VehicleRefID { get; set; }

	
		public int StartOfficeID { get; set; }

	
		public int EndOfficeID { get; set; }

		public string Identifier { get; set; }

    
        public string StartOfficeName { get; set; }

     
        public string EndOfficeName { get; set; }

		public string EndOfficeAddress { get; set; }

		public string EndOfficePhone { get; set; }

		public string OfficeAddress { get; set; }

		public string OfficePhone { get; set; }

     
        public DateTime StartAt { get; set; }

     
        public DateTime EndAt { get; set; }


        public int PaymentStatusID { get; set; }

		public string VehicleExtraFee { get; set; }

		public int PaymentTypeID { get; set; }

        public string PaymentIdentifier { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

     
        public decimal TotalRate { get; set; }

  
        public int CurrencyID { get; set; }

		public string CreditCardNumber { get; set; }

		public string CreditCardNameandSurname { get; set; }

		public string CreditCardType { get; set; }

		public string CreditCardExpirationMonth { get; set; }

		public string CreditCardExpirationYear { get; set; }

		public string CreditCardSecurityCode { get; set; }

        public string FlightNumber { get; set; }

		public string VehicleName { get; set; }

		public string ConfirmedID { get; set; }
        public string ThumImage { get; set; }

		public virtual Vehicle.Vehicle Vehicle { get; set; }

		public virtual VehicleOffice StartOffice { get; set; }

		public virtual VehicleOffice EndOffice { get; set; }
		
        public virtual Order.Order Order { get; set; }

        public virtual Currency Currency { get; set; }
    }
}