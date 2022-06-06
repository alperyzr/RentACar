using Arackiralama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Arackiralama.ViewModels.Content
{
    public class BlogViewModel
    {
        public int ID { get; set; }
        public Nullable<int> CultureID { get; set; }
        public string Title { get; set; }
        public string ImageURLPath { get; set; }
        public HttpPostedFileBase ImageURL { get; set; }
        public string ShowCaseDescription { get; set; }

        [AllowHtml]
        public string DescriptionCK { get; set; }
        public Nullable<int> Rank { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public string IsActive { get; set; }
        public byte[] IconByte { get; set; }

        public string IconExtension { get; set; }

        public string IconUrl { get; set; }
        public IEnumerable<Cultures> cultureList { get; set; }
        public IEnumerable<Blog> blogList { get; set; }
        public string ImageTitle { get; set; }
    }
}