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
    
    public partial class CityTranslations
    {
        public int ID { get; set; }
        public int CityID { get; set; }
        public int CultureID { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Information { get; set; }
        public string MetaKeyWord { get; set; }
        public string MetaDescription { get; set; }
        public string Html { get; set; }
        public string Title { get; set; }
    
        public virtual Cities Cities { get; set; }
        public virtual Cultures Cultures { get; set; }
    }
}
