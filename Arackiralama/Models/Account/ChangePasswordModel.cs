//using System.ComponentModel.DataAnnotations;
//using System.Web.Mvc;

//namespace Arackiralama.Models.Account
//{
//    public class ChangePasswordModel
//    {
//        [Required]
//        [DataType(DataType.Password)]
//        [Display(Name = "Eski Şifre")]
//        public string OldPassword { get; set; }

//        [Required]
//        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
//        [DataType(DataType.Password)]
//        [Display(Name = "Yeni Şifre")]
//        public string NewPassword { get; set; }

//        [DataType(DataType.Password)]
//        [Display(Name = "Yeni Şifre (tekrar)")]
//        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
//        public string ConfirmPassword { get; set; }
//    }
//}
