using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Arackiralama.Models
{
	[Serializable]
	public class VehicleFeePrice
	{
	
		public int ID { get; set; }

	
		public int CompanyID { get; set; }

		public int VehiclePropertyID { get; set; }

		
		public decimal TotalPrice { get; set; }

		public DateTime InsertedDate { get; set; }

		//public virtual Company Company { get; set; }

		public virtual VehicleProperty.VehicleProperty VehicleProperty { get; set; }
	}
}
