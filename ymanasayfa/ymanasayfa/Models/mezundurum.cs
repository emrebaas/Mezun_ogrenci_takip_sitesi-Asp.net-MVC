namespace ymanasayfa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("mezundurum")]
    public partial class mezundurum
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public mezundurum()
        {
            Hakkindas = new HashSet<Hakkinda>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(10)]
        public string durum { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hakkinda> Hakkindas { get; set; }
    }
}
