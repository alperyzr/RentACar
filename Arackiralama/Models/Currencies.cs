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
    
    public partial class Currencies
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Currencies()
        {
            this.Cultures = new HashSet<Cultures>();
            this.VehicleOrders = new HashSet<VehicleOrders>();
        }
    
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsDefault { get; set; }
        public Nullable<int> RefID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cultures> Cultures { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VehicleOrders> VehicleOrders { get; set; }
    }
}