using System;

namespace Arackiralama.Models.City
{
    public class CityImportModel
    {
        public Guid Guid { get; set; }

        public int ID { get; set; }

        public int CountryID { get; set; }

        public int? RefID { get; set; }

        public string Name { get; set; }
    }
}