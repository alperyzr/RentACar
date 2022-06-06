namespace Arackiralama.Models
{
    public class VehicleReservationModel
    {
        public VehicleSearchModel SearchModel { get; set; }

        public Contacts Contact { get; set; }

        public CreditCard CreditCard { get; set; }

        public LoginAccount Account { get; set; }

		public string extraFeeHdn { get; set; }



		public Order.Order vorder { get; set; }
    }
    public class CreditCard
    {
     
        public string Number { get; set; }

     
        public int Month { get; set; }

        public int Year { get; set; }

     
        public string Code { get; set; }

        public string extraFee { get; set; }

        public string NameSurname { get; set; }

        public string Type { get; set; }
    }
}