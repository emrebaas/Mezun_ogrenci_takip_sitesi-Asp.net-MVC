namespace ymanasayfa.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Veritabani : DbContext
    {
        public Veritabani()
            : base("name=Veritabani")
        {
        }

        public virtual DbSet<Duyuru> Duyurus { get; set; }
        public virtual DbSet<GirisTarih> GirisTarihs { get; set; }
        public virtual DbSet<Hakkinda> Hakkindas { get; set; }
        public virtual DbSet<Kullanıcı> Kullanıcı { get; set; }
        public virtual DbSet<Mesaj> Mesajs { get; set; }
        public virtual DbSet<mezundurum> mezundurums { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Yorum> Yorums { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Duyuru>()
                .HasMany(e => e.Yorums)
                .WithRequired(e => e.Duyuru)
                .HasForeignKey(e => e.yorum_duyuru_id);

            modelBuilder.Entity<GirisTarih>()
                .HasMany(e => e.Hakkindas)
                .WithRequired(e => e.GirisTarih)
                .HasForeignKey(e => e.mezungiris_id);

            modelBuilder.Entity<Kullanıcı>()
                .HasMany(e => e.Duyurus)
                .WithRequired(e => e.Kullanıcı)
                .HasForeignKey(e => e.duyuru_kullanici_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kullanıcı>()
                .HasMany(e => e.Hakkindas)
                .WithRequired(e => e.Kullanıcı)
                .HasForeignKey(e => e.kullanici_id);

            modelBuilder.Entity<Kullanıcı>()
                .HasMany(e => e.Mesajs)
                .WithRequired(e => e.Kullanıcı)
                .HasForeignKey(e => e.mesaj_alan_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kullanıcı>()
                .HasMany(e => e.Mesajs1)
                .WithRequired(e => e.Kullanıcı1)
                .HasForeignKey(e => e.mesaj_gönderen_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kullanıcı>()
                .HasMany(e => e.Yorums)
                .WithRequired(e => e.Kullanıcı)
                .HasForeignKey(e => e.yorum_kullanici_id);

            modelBuilder.Entity<mezundurum>()
                .Property(e => e.durum)
                .IsFixedLength();

            modelBuilder.Entity<mezundurum>()
                .HasMany(e => e.Hakkindas)
                .WithRequired(e => e.mezundurum)
                .HasForeignKey(e => e.mezundurumu_id);
        }
    }
}
