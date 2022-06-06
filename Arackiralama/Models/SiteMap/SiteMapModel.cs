using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Arackiralama.Models.SiteMap
{
    public class SiteMapModel
    {
        public string Title { get; set; }

        public bool IsCreated { get; set; }

        public List<Tuple<int, string, string>> CityHotelsList { get; set; }

        public string Culture { get; set; }
    }
}
