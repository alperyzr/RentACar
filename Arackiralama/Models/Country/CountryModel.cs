namespace Arackiralama.Models.Country
{
    public class CountryModel
    {
        public int ID { get; set; }

        public string Code { get; set; }

        public int? RefID { get; set; }

        public bool IsDomestic { get; set; }

        public string Name { get; set; }
    }
}