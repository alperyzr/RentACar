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
    
    public partial class UserSearchLogs
    {
        public int ID { get; set; }
        public string LeaveCity { get; set; }
        public string ReturnCity { get; set; }
        public System.DateTime InsertedDate { get; set; }
        public int LogType { get; set; }
        public System.DateTime StartAt { get; set; }
        public Nullable<System.DateTime> EndAt { get; set; }
    }
}
