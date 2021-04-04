namespace ShopProject.Areas.Administrator.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tranning_model
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(5)]
        public string ID_GP { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string proID { get; set; }

        public string model { get; set; }

        public virtual GP GP { get; set; }

        public virtual Product Product { get; set; }
    }
}
