using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arackiralama.Models.Vehicle
{
   public class VehiclePointModel
    {
        public int ID { get; set; }

        public int CityID { get; set; }

        

        public string CityName { get; set; }

        

        public string Title { get; set; }

        public string Slug { get; set; }

        public string Description { get; set; }

        public string KeyWords { get; set; }

        public DateTime InsertedDate { get; set; }

        public string Content { get; set; }
    }
}
