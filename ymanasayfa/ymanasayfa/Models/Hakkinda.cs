namespace ymanasayfa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hakkinda")]
    public partial class Hakkinda
    {
        [Key]
        public int hakkinda_id { get; set; }

        [Required]
        [StringLength(100)]
        public string email { get; set; }

        [StringLength(11)]
        public string telefon { get; set; }

        public int? yas { get; set; }

        [StringLength(50)]
        public string yer { get; set; }

        public int mezungiris_id { get; set; }

        [StringLength(50)]
        public string isyer { get; set; }

        [StringLength(250)]
        public string bio { get; set; }

        public int mezundurumu_id { get; set; }

        public int kullanici_id { get; set; }

        public virtual GirisTarih GirisTarih { get; set; }

        public virtual Kullanıcı Kullanıcı { get; set; }

        public virtual mezundurum mezundurum { get; set; }
    }
}
