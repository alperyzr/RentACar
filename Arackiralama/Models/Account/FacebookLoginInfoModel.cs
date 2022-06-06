using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arackiralama.Models.Account
{
    public class FacebookLoginInfoModel
    {
        public FacebookLoginInfoModel()
        {
            AppId = "Constants.FacebookAppID";
            Scope = "Constants.FacebookScope";
        }

        public string AppId { get; set; }
        public string Scope { get; set; }
    }
}
