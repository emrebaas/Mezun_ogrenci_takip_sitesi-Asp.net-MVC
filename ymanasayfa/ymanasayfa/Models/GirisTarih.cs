namespace ymanasayfa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GirisTarih")]
    public partial class GirisTarih
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GirisTarih()
        {
            Hakkindas = new HashSet<Hakkinda>();
        }

        [Key]
        public int idmezuntarih { get; set; }

        public int mezuntarih { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hakkinda> Hakkindas { get; set; }
    }
}
