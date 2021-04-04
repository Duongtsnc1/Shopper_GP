namespace ShopProject.Areas.Administrator.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GP")]
    public partial class GP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GP()
        {
            tranning_model = new HashSet<tranning_model>();
        }

        [Key]
        [StringLength(5)]
        public string ID_GP { get; set; }

        [StringLength(50)]
        public string name_GP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tranning_model> tranning_model { get; set; }
    }
}