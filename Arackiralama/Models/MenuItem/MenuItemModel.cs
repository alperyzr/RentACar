using System.ComponentModel.DataAnnotations;

namespace Arackiralama.Models
{
    [System.Serializable()]
    public class MenuItemModel
    {
        public int ID { get; set; }

   
        public int Sequence { get; set; }


        public string Title { get; set; }

 
        public string Url { get; set; }

        public string MetaKeyWord { get; set; }

        public string MetaDescription { get; set; }
    }
}