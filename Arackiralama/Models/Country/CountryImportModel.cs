using System;

namespace Arackiralama.Models.Country
{
    public class CountryImportModel
    {
        public Guid Guid { get; set; }

        public int ID { get; set; }

        public string Code { get; set; }

        public int? RefID { get; set; }

        public string Name { get; set; }
    }
}