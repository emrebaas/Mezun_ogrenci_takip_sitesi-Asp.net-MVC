namespace ymanasayfa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Yorum")]
    public partial class Yorum
    {
        public int yorumid { get; set; }

        public int yorum_kullanici_id { get; set; }

        public int yorum_duyuru_id { get; set; }

        [Required]
        [StringLength(250)]
        public string yorum_aciklama { get; set; }

        public virtual Duyuru Duyuru { get; set; }

        public virtual Kullanıcı Kullanıcı { get; set; }
    }
}
