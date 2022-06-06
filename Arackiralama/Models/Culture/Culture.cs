using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arackiralama.Models
{
    public class Culture
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsDefault { get; set; }
        public string Currency { get; set; }
    }
}
