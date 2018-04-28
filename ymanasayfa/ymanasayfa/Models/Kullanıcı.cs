namespace ymanasayfa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Kullanıcı
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kullanıcı()
        {
            Duyurus = new HashSet<Duyuru>();
            Hakkindas = new HashSet<Hakkinda>();
            Mesajs = new HashSet<Mesaj>();
            Mesajs1 = new HashSet<Mesaj>();
            Yorums = new HashSet<Yorum>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string kadi { get; set; }

        [Required]
        [StringLength(50)]
        public string ksifre { get; set; }

        [Required]
        [StringLength(50)]
        public string isim { get; set; }

        [StringLength(250)]
        public string resim { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Duyuru> Duyurus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hakkinda> Hakkindas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mesaj> Mesajs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mesaj> Mesajs1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Yorum> Yorums { get; set; }
    }
}
