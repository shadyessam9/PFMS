namespace PFMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Personnel")]
    public partial class Personnel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int p_id { get; set; }

        [Required]
        public string p_name { get; set; }

        [Required]
        [StringLength(10)]
        public string type { get; set; }

        public int site { get; set; }

        [StringLength(10)]
        public string site_type { get; set; }
    }
}
