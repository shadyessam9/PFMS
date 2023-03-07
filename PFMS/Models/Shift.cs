namespace PFMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Shift
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int c_shift { get; set; }
    }
}
