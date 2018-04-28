namespace ymanasayfa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Duyuru")]
    public partial class Duyuru
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Duyuru()
        {
            Yorums = new HashSet<Yorum>();
        }

        [Key]
        public int duyuru_id { get; set; }

        public int duyuru_kullanici_id { get; set; }

        [Required]
        [StringLength(50)]
        public string duyuruisim { get; set; }

        [StringLength(250)]
        public string duyururesim { get; set; }

        public virtual Kullanıcı Kullanıcı { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Yorum> Yorums { get; set; }
    }
}
