using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Arackiralama.Models
{
	
    public class LoginAccount
    {
  
        public int ID { get; set; }

  
        public int RoleID { get; set; }

        public int? CompanyID { get; set; }

        public int? PartnerID { get; set; }

        public string ZipCode { get; set; }

        public string CityName { get; set; }

        public string RegionName { get; set; }

   
        public string Email { get; set; }

   
        public string Password { get; set; }
               
        public string GovermentNo { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string CellPhone { get; set; }

        public string FaxNumber { get; set; }

        public string Address { get; set; }

        public string UniqueKey { get; set; }

        public Int16 Status { get; set; }

  
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? HitAt { get; set; }


        //public virtual Role Role { get; set; }

        //public virtual Company Company { get; set; }

        //private ICollection<Contact> _contacts;

        //public virtual ICollection<Contact> Contacts
        //{
        //    get { return _contacts ?? (_contacts = new HashSet<Contact>()); }
        //    protected set { _contacts = value; }
        //}
    }
}