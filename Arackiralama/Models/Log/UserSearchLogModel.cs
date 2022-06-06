using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arackiralama.Models.Log
{
	public class UserSearchLogModel
	{
		public int ID { get; set; }

		public int LogType { get; set; }

		public string LeaveCity { get; set; }

		public string ReturnCity { get; set; }

		public DateTime StartAt { get; set; }

		public DateTime? EndAt { get; set; }

		public DateTime InsertedDate { get; set; }
	}
}
