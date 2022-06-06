using System.ComponentModel.DataAnnotations;

namespace Arackiralama.Models.VehicleProperty
{
    public class VehiclePropertyModel
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}