using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arackiralama.Models.Vehicle
{
	public class VehicleFeePriceModel
	{
		public int CompanyID { get; set; }

		public int VehicleID { get; set; }

		public int[] FeeID { get; set; }

		public decimal[] FeePrice { get; set; }

		public List<Tuple<int, string, decimal>> FeeList { get; set; }
	}
}
