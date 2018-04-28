namespace ymanasayfa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Mesaj")]
    public partial class Mesaj
    {
        [Key]
        public int mesaj_id { get; set; }

        public int mesaj_alan_id { get; set; }

        public int mesaj_gönderen_id { get; set; }

        [Required]
        public string mesaj_icerik { get; set; }

        public virtual Kullanıcı Kullanıcı { get; set; }

        public virtual Kullanıcı Kullanıcı1 { get; set; }
    }
}
