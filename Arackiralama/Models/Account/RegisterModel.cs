using System.ComponentModel.DataAnnotations;

namespace Arackiralama.Models
{
    public class RegisterModel
    {
    
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

   
        public string Password { get; set; }

     
        public string PasswordAgain { get; set; }

    
        public Gender GenderID { get; set; }

        public string Adress { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public string Country { get; set; }

        public bool IsCampaignRequested { get; set; }

        public bool IsAgreementApproved { get; set; }
        public string Captcha { get; set; }

    }
    public enum Gender
    {
     
        Undefined,
       
        Male,
      
        Female
    }
}