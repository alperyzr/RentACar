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
    
    public partial class Orders
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Orders()
        {
            this.VehicleOrders = new HashSet<VehicleOrders>();
            this.VehicleOtherPassengers = new HashSet<VehicleOtherPassengers>();
        }
    
        public int ID { get; set; }
        public System.DateTime OrderedAt { get; set; }
        public System.Guid Identifier { get; set; }
        public int ContactID { get; set; }
        public Nullable<decimal> Total { get; set; }
        public int CommisionStatus { get; set; }
        public int ReservationStatus { get; set; }
        public string OrderType { get; set; }
    
        public virtual Contacts Contacts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VehicleOrders> VehicleOrders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VehicleOtherPassengers> VehicleOtherPassengers { get; set; }
    }
}
