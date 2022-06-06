using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arackiralama.Models.News
{
	public class NewsModel
	{
		public int ID { get; set; }

		public string Header { get; set; }

		public string Content { get; set; }

		public string Description { get; set; }

		public string Tags { get; set; }

		public DateTime InsertedDate { get; set; }

		public string Slug { get; set; }

		public string PrvSlug { get; set; }

		public string NxtSlug { get; set; }

		public int Page { get; set; }

		public int TopPage { get; set; }

		public byte Status { get; set; }
	}
}
