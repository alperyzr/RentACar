using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arackiralama.Models.City
{
	public class CityLandMarkerModel
	{
		public int ID { get; set; }
		public decimal Latitude { get; set; }
		public decimal Longitude { get; set; }
		public int CultureID { get; set; }
		public string Description { get; set; }
		public string Name { get; set; }
		public int LandCategory { get; set; }

	}
}
