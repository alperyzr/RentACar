//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Arackiralama.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class VehicleOrders
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VehicleOrders()
        {
            this.VehicleInfo = new HashSet<VehicleInfo>();
        }
    
        public int ID { get; set; }
        public int VehicleID { get; set; }
        public System.DateTime StartAt { get; set; }
        public System.DateTime EndAt { get; set; }
        public int PaymentStatusID { get; set; }
        public string PaymentIdentifier { get; set; }
        public decimal TotalRate { get; set; }
        public int CurrencyID { get; set; }
        public int OrderID { get; set; }
        public string FlightNumber { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string VehicleExtraFee { get; set; }
        public string CreditCardNumber { get; set; }
        public string CreditCardNameandSurname { get; set; }
        public string CreditCardType { get; set; }
        public string CreditCardExpirationMonth { get; set; }
        public string CreditCardExpirationYear { get; set; }
        public string CreditCardSecurityCode { get; set; }
        public string Identifier { get; set; }
        public string StartOfficeName { get; set; }
        public string EndOfficeName { get; set; }
        public string OfficeAddress { get; set; }
        public string OfficePhone { get; set; }
        public string VehicleName { get; set; }
        public int VehicleRefID { get; set; }
        public int StartOfficeID { get; set; }
        public int EndOfficeID { get; set; }
        public int PaymentTypeID { get; set; }
        public string ConfirmedID { get; set; }
        public string EndOfficeAddress { get; set; }
        public string EndOfficePhone { get; set; }
        public string ThumImage { get; set; }
    
        public virtual Currencies Currencies { get; set; }
        public virtual Orders Orders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VehicleInfo> VehicleInfo { get; set; }
    }
}
