using System.Web.Mvc;

namespace Arackiralama.Models.CityInformationDetail
{
    public class CityInformationDetailModel
    {
        public int ID { get; set; }

        public int Sequence { get; set; }

        public string Title { get; set; }

        [AllowHtml]
        public string Html { get; set; }

		public int InfoID { get; set; }

        public string TabIndex { get; set; }

		public string SelfLink { get; set; }

		public string MetaTag { get; set; }

		public string MetaDescription { get; set; }
    }
}
