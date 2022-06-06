using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arackiralama.Models.Reporting
{
    public class ReportingModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string OrderType { get; set; }
        public decimal CommissionRate { get; set; }
        public decimal TotalRate { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public string ProductType { get; set; }
        public DateTime OrderedAt { get; set; }
        public string InvoiceInformation { get; set; }
    }
}
