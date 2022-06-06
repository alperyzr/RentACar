using System;

namespace Arackiralama.Models.Airport
{
    public class AirportImportModel
    {
        public Guid Guid { get; set; }

        public int ID { get; set; }

        public int CityID { get; set; }

        public string Code { get; set; }

        public int? RefID { get; set; }

        public string Name { get; set; }
    }
}