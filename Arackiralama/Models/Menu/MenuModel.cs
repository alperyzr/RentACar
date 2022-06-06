using System.Collections.Generic;

namespace Arackiralama.Models
{
    [System.Serializable()]
    public class MenuModel
    {
        public int ID { get; set; }

        public string Key { get; set; }

        public int Separator { get; set; }

        public IEnumerable<MenuItemModel> Items { get; set; }
    }
}