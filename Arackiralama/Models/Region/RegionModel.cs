namespace Arackiralama.Models
{
    public class RegionModel
    {
        public int ID { get; set; }

        public int CityID { get; set; }

        public City.CityModel City { get; set; }

        public decimal? Latitude { get; set; }

        public decimal? Longitude { get; set; }

        public string Name { get; set; }

        public int Status { get; set; }
    }
}