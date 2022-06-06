using System;

namespace Arackiralama.Models.Order
{
    public class OrderModel
    {
        public int ID { get; set; }

        public Guid Identifier { get; set; }

        public long? HotelRef { get; set; }

        public string ContactFirstName { get; set; }

        public string ContactLastName { get; set; }

        public string ContactPhone { get; set; }

        public string ContactEmail { get; set; }

        public DateTime OrderedAt { get; set; }

        public int? ReservationStatus { get; set; }

        public int? HotelPaymentStatusID { get; set; }

        public int? FlightPaymentStatusID { get; set; }

        public int? VehiclePaymentStatusID { get; set; }

        public string ZipCode { get; set; }

		public string OrderType { get; set; }


    

     

        public PaymentStatus? VehiclePaymentStatus
        {
            get
            {
                return
                    VehiclePaymentStatusID.HasValue ?
                        (PaymentStatus)VehiclePaymentStatusID.Value :
                        (PaymentStatus?)null;
            }
        }
    }
    //[TypeConverter(typeof(EnumToStringUsingDescription))]
    public enum PaymentStatus
    {
       
        Unpaid,
       
        Network,
        
        Error,
       
        Denied,
       
        Paid,
        
        OtelOdemesi,
    }
}
