namespace Arackiralama.Models.Airport
{
    public class AirportModel
    {
        public int ID { get; set; }

        public int CityID { get; set; }

        public City.CityModel City { get; set; }

        public string Code { get; set; }

        public int? RefID { get; set; }

        public string Name { get; set; }
    }
}