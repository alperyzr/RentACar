using System.ComponentModel.DataAnnotations;

namespace Arackiralama.Models
{
    [System.Serializable()]
    public class Currency
    {
        
        public int ID { get; set; }


        public string Code { get; set; }

    
        public string Name { get; set; }

        public int? RefID { get; set; }

        
        

        public bool IsDefault { get; set; }

        public virtual System.Collections.Generic.ICollection<Culture> Cultures { get; set; }
    }
}