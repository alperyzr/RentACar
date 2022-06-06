namespace Arackiralama.Models.Airline
{
    public class AirlineModel
    {
        public int ID { get; set; }

        public string Code { get; set; }

        public int? RefID { get; set; }

        public string Name { get; set; }

		public string Slug { get; set; }
    }
}