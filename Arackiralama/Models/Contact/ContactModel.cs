using System.ComponentModel.DataAnnotations;

namespace Arackiralama.Models
{
    public class ContactModel
    {

        public string Name { get; set; }

	
        public string Surname { get; set; }


        public string Email { get; set; }


        public string Message { get; set; }
        //[Required(ErrorMessageResourceType = typeof(Tourism.Data.Resources.Common), ErrorMessageResourceName = "ContactCaptcha")]
        public string Captcha { get; set; }
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public string DriverAge { get; set; }
        
            
            
    }
}