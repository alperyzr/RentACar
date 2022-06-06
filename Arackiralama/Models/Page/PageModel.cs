using System.ComponentModel.DataAnnotations;

namespace Arackiralama.Models.Page
{
    public class PageModel
    {
        public int ID { get; set; }

        [Required]
        public string Path { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public string Tags { get; set; }
    }
}