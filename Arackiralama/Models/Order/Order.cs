using System;
using System.ComponentModel.DataAnnotations;


namespace Arackiralama.Models.Order
{

    public class Order
    {

        public int ID { get; set; }

  
        public Guid Identifier { get; set; }


        public int ContactID { get; set; }

 
        public DateTime OrderedAt { get; set; }

        public int CommisionStatus { get; set; }

        public int ReservationStatus { get; set; }

        public virtual ContactModel Contact { get; set; }

        public virtual VehicleOrder VehicleOrder { get; set; }

        public decimal? Total { get; set; }

		public string OrderType { get; set; }

        //public static implicit operator Order(Orders v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}