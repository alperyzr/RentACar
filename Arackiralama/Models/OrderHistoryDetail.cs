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
    
    public partial class OrderHistoryDetail
    {
        public System.Guid ID { get; set; }
        public Nullable<System.Guid> UserID { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public Nullable<System.Guid> CarID { get; set; }
        public Nullable<int> CarPointScaleID { get; set; }
        public Nullable<System.Guid> CarLocationID { get; set; }
    
        public virtual Car Car { get; set; }
        public virtual CarLocation CarLocation { get; set; }
        public virtual CarPointScale CarPointScale { get; set; }
        public virtual Company Company { get; set; }
        public virtual User User { get; set; }
    }
}