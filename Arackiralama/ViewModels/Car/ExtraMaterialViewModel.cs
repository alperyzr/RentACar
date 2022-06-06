using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Arackiralama.ViewModels.Car
{
    public class ExtraMaterialViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Lütfen logo Seçiniz")]
        public HttpPostedFileBase Icon { get; set; }
        public string ImageUrl { get; set; }
        public string Materyal { get; set; }
        public string Aciklama { get; set; }
        public Nullable<int> MinDeger { get; set; }
        public Nullable<int> MaxDeger { get; set; }
        public Nullable<System.DateTime> EklendigiTarih { get; set; }
        public string EkleyenKisi { get; set; }
        public Nullable<System.DateTime> GuncellemeTarihi { get; set; }
        public string GuncelleyenKisi { get; set; }
        public string IsActive { get; set; }
        public byte[] IconByte { get; set; }

        public string IconExtension { get; set; }

        public string IconUrl { get; set; }
    }
}