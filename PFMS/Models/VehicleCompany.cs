namespace PFMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VehicleCompany
    {
        [Key]
        public int c_id { get; set; }

        [Required]
        public string c_name { get; set; }
    }
}
