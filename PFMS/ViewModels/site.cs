using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PFMS.ViewModels
{
    public class site
    {
        public int? s_id { get; set; }
        public string s_name { get; set; }
        public int? avg_a_time { get; set; }
        public string type { get; set; }
    }
}