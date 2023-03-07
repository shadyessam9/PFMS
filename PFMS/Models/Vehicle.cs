namespace PFMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Vehicle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int v_id { get; set; }

        [Required]
        [StringLength(50)]
        public string v_l1 { get; set; }

        [Required]
        [StringLength(50)]
        public string v_l2 { get; set; }

        [Required]
        [StringLength(50)]
        public string v_l3 { get; set; }

        public int v_number { get; set; }

        [Required]
        public string driver { get; set; }

        public int company { get; set; }

        [StringLength(50)]
        public string r_date { get; set; }

        public int? shift { get; set; }

        public int? state { get; set; }

        public int? holds { get; set; }
    }
}
