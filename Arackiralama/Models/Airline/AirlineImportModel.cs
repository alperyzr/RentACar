using System;

namespace Arackiralama.Models.Airline
{
    public class AirlineImportModel
    {
        public Guid Guid { get; set; }

        public int ID { get; set; }

        public string Code { get; set; }

        public int? RefID { get; set; }

        public string Name { get; set; }
    }
}