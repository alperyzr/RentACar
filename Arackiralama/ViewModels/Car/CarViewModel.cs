using Arackiralama.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Arackiralama.ViewModels.Car
{
    public class CarViewModel
    {
        public System.Guid ID { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public string Sinif { get; set; }
        public string Segment { get; set; }

        public HttpPostedFileBase Resim { get; set; }
        public string ImageUrl { get; set; }
        public string KisiSayisi { get; set; }
        public string BagajKapasitesi { get; set; }
        public string KapiSaysi { get; set; }
        public string Sanzuman { get; set; }
        public string YakitTuru { get; set; }
        public Nullable<int> CarPoitScaleID { get; set; }
        public Nullable<int> CarExtraMaterialID { get; set; }
        public Nullable<double> KiralamaTutari { get; set; }
        public Nullable<System.DateTime> EklendigiTarih { get; set; }
        public string EkleyenKisi { get; set; }
        public Nullable<System.DateTime> GuncellendigiTarih { get; set; }
        public string GuncelleyenKisi { get; set; }
        public string IsActive { get; set; }
        public virtual CarPointScale CarPointScale { get; set; }
        //public virtual Company Company { get; set; }
        public virtual ExtraMaterial ExtraMaterial { get; set; }
        public byte[] IconByte { get; set; }

        public string IconExtension { get; set; }

        public string IconUrl { get; set; }
    }
}