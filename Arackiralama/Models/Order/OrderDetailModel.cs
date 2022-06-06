using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arackiralama.Models
{
    public class OrderDetailModel
    {
        //1-Hotel, 2-Flight
        public int ID { get; set; }
        public byte OrderType { get; set; }
        public string HotelName { get; set; }
        public DateTime HotelStartAt { get; set; }
        public DateTime HotelEndAt { get; set; }
        public decimal TotalRate { get; set; }
        public decimal PricePerNight { get; set; }
        public string HotelRoomName { get; set; }
        public string specialRequests { get; set; }
        public string Currency { get; set; }
        public string CreditCardNo { get; set; }
        public string CreditCardNameAndSurname { get; set; }
        public string CreditCardType { get; set; }
        public string CreditCardExpMonth { get; set; }
        public string CreditCardExpYear { get; set; }
        public string CreditCardSecurityCode { get; set; }
        public decimal? BreakfastPrice { get; set; }
        public decimal? LunchPrice { get; set; }
        public decimal? DinnerPrice { get; set; }
        public int ChildCount { get; set; }
        public int AdultCount { get; set; }
        public decimal ChildPrice { get; set; }
        public decimal TaxPrice { get; set; }
        public decimal ExtraPrice { get; set; }
        public string HotelOrderType { get; set; }
        public DateTime? CancellationDate { get; set; }
        public string CancellationTime { get; set; }
        public int? HotelClassification { get; set; }
        public string ExpediaConfirmationNumbers { get; set; }
        public string ExpediaItineraryId { get; set; }

        public OrderContactModel OrderContact { get; set; }
        public OrderVehicleModel OrderVehicle { get; set; }
        public List<OrderCommentModel> OrderCommentModel { get; set; }
       

        public DateTime? InsertedDate { get; set; }

        //public decimal PricePerNight { get; set; }
    }
    public class OrderVehicleModel
    {
        public string VehicleName { get; set; }
        public string VehicleCategory { get; set; }
        public string StartOffice { get; set; }
        public string EndOffice { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
		public string StartTime { get; set; }
		public string EndTime { get; set; }
		public string CreditCardNumber { get; set; }
		public decimal TotalRate { get; set; }
		public string CreditCardNameandSurname { get; set; }
		public string CreditCardType { get; set; }
		public string CreditCardExpirationMonth { get; set; }
		public string CreditCardExpirationYear { get; set; }
		public string CreditCardSecurityCode { get; set; }
		public string ExtrFee { get; set; }
		public string ConfirmedID { get; set; }
    }

    public class OrderContactModel
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string GovermentNo { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }

    }
    public class OrderCommentModel
    {
        public string Comment { get; set; }
        public string CommentOwner { get; set; }
        public string CreatedAt { get; set; }
        public int ID { get; set; }
    }
}
