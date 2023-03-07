namespace PFMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Violation
    {
        [Key]
        public int vi_id { get; set; }

        public int? sc_id { get; set; }

        public int? vehicle { get; set; }

        public int? site { get; set; }

        [StringLength(100)]
        public string cause { get; set; }

        public int? shift { get; set; }

        public string date { get; set; }

        public TimeSpan? time { get; set; }

        public int? resolved { get; set; }
    }
}
