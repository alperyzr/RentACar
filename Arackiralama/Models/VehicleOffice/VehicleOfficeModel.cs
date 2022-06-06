using System.ComponentModel.DataAnnotations;

namespace Arackiralama.Models
{
    public class VehicleOfficeModel
    {
        public int ID { get; set; }

        [Required]
        public int CompanyID { get; set; }

		public string CompanyName { get; set; }

        public int? RegionID { get; set; }

        public decimal? Latitude { get; set; }

        public decimal? Longitude { get; set; }

        [Required]
        public string Name { get; set; }

		public string Adress { get; set; }

		public string AuthorizedName { get; set; }

		public string AuthorizedSurname { get; set; }

		public string Title { get; set; }

		public string CompanyPhone { get; set; }

		public string CellPhone { get; set; }

		public string FaxNo { get; set; }

		public string Email { get; set; }

		public string ConfirmMail { get; set; }

		public string WebSite { get; set; }

		public string WorkTime { get; set; }
    }
}