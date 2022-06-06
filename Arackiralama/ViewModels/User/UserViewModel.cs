using Arackiralama.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Arackiralama.ViewModels.User
{
    public class UserViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Lütfen resim Seçiniz")]
        public HttpPostedFileBase AvatarResim { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Telefon { get; set; }
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "{0} alanı boş geçilemez!")]
        [DataType(DataType.Date, ErrorMessage = "Doğum tarihi hatalı!")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        [Display(Name = "Doğum Tarihi")]
        public Nullable<System.DateTime> DogumTarihi
        {
            get; set;
        }
        public string DTarihi { get; set; }
        public string Adres { get; set; }
        public string EPosta { get; set; }


        public string Sifre { get; set; }

        public string SifreTekrar { get; set; }
        public string YeniSifre { get; set; }

        public string YeniSifreTekrar { get; set; }
        public string Cinsiyet { get; set; }



        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Son Giriş Tarihi Tarihi")]
        public Nullable<System.DateTime> SonGirisTarihi { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Kayıt Tarihi Tarihi")]
        public Nullable<System.DateTime> KayitTarihi { get; set; }
        public string KayıtEdenKisi { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Günelleme Tarihi Tarihi")]
        public Nullable<System.DateTime> GuncellemeTarihi { get; set; }
        public string GuncelleyenKisi { get; set; }
        public Nullable<int> RolID { get; set; }
        public string IsActive { get; set; }
        public byte[] IconByte { get; set; }

        public string IconExtension { get; set; }
      
        public Nullable<bool> CookiePolicyIsChecked { get; set; }
        public string IconUrl { get; set; }
        public IEnumerable<Cultures> cultureList { get; set; }
    }
}