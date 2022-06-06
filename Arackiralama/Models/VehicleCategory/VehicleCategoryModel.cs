using System.ComponentModel.DataAnnotations;

namespace Arackiralama.Models
{
    public class VehicleCategoryModel
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}