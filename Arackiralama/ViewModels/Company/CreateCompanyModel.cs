using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Arackiralama.ViewModels.Company
{
    public class CreateCompanyModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Lütfen logo Seçiniz")]
        public HttpPostedFileBase Logo { get; set; }
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Lütfen Şirket Adı Giriniz")]
        public string SirketAdi { get; set; }
        [Required(ErrorMessage = "Lütfen Şirket Adı Giriniz")]
        public string TicariUnvani { get; set; }
        [Required(ErrorMessage = "Lütfen Şirket Adı Giriniz")]
        public string VergiDairesi { get; set; }
        [Required(ErrorMessage = "Lütfen Şirket Adı Giriniz")]
        public string VergiNo { get; set; }
        [Required(ErrorMessage = "Lütfen Şirket Adı Giriniz")]
        public string SirketTuru { get; set; }
        [Required(ErrorMessage = "Lütfen Şirket Adı Giriniz")]
        public string SirketSahibi { get; set; }
        public string IsActive { get; set; }
        public byte[] IconByte { get; set; }

        public string IconExtension { get; set; }

        public string IconUrl { get; set; }
    }
}