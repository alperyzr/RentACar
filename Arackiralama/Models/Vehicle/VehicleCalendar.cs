using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arackiralama.Models.Vehicle
{
	public class VehicleCalendar
	{
		public int ID { get; set; }
		public int Month { get; set; }
		public int Year { get; set; }

		public List<Tuple<string, string, string, string, string, int>> DayDayPrice { get; set; }
	}
}
