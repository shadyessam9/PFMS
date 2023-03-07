namespace PFMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Site
    {
        [Key]
        public int? s_id { get; set; }

        [Required]
        public string s_name { get; set; }

        public int? avg_a_time { get; set; }

        [Required]
        [StringLength(50)]
        public string type { get; set; }
    }
}
