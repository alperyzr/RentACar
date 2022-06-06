using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Arackiralama.Models
{
	public class VehiclePrice
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

	
		public DateTime ValidStartDate { get; set; }

	
		public DateTime ValidEndDate { get; set; }

		public virtual Vehicle.Vehicle Vehicle { get; set; }


	}
}
