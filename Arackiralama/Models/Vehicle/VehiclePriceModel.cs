using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arackiralama.Models.Vehicle
{
	public class VehiclePriceModel
	{
		public int ID { get; set; }

		public int VehicleID { get; set; }

		public decimal StandardPriceRate { get; set; }

		public decimal StandardPriceRate2 { get; set; }
		public decimal StandardPriceRate3 { get; set; }
		public decimal StandardPriceRate4 { get; set; }
		public decimal StandardPriceRate5 { get; set; }
		public decimal StandardPriceRate6 { get; set; }
		public decimal StandardPriceRate7 { get; set; }
		public decimal StandardPriceRate8 { get; set; }

		public DateTime ValidStartAt { get; set; }

		public DateTime ValidEndAt { get; set; }
	}
}
