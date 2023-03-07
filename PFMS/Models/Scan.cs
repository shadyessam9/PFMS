namespace PFMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Scan
    {
        [Key]
        public int sc_id { get; set; }

        public string sc_date { get; set; }

        public int? sc_shift { get; set; }

        public int? vehicle { get; set; }

        public int? site { get; set; }

        public string ship { get; set; }

        public int? pump { get; set; }

        public TimeSpan? time { get; set; }

        public TimeSpan? trip_time { get; set; }

        public TimeSpan? loading_time { get; set; }

        public TimeSpan? delay { get; set; }

        [StringLength(50)]
        public string state { get; set; }

        [StringLength(50)]
        public string type { get; set; }

        public int? load { get; set; }
    }
}
