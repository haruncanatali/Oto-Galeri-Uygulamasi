using Galeri.Entities.Concrete;
using Galeri.Entities.Map;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeri.DataAccess.Concrete
{
    public class GaleriContext:DbContext
    {
        public DbSet<HasarKayit> HasarKayit { get; set; }
        public DbSet<Kategori> Kategori { get; set; }
        public DbSet<Marka> Marka { get; set; }
        public DbSet<Model> Model { get; set; }
        public DbSet<Tasit> Tasit { get; set; }
        public DbSet<Fotograf> Fotograf { get; set; }
        public DbSet<Yorum> Yorum { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tasit>().HasMany(c => c.HasarKayitlari).WithRequired(c => c.Tasiti).HasForeignKey(c => c.TasitId);
            modelBuilder.Entity<Kategori>().HasMany(c => c.Tasitlar).WithRequired(c => c.Kategorisi).HasForeignKey(c => c.KategoriId);
            modelBuilder.Entity<Marka>().HasMany(c => c.Modeller).WithRequired(c => c.Markasi).HasForeignKey(c => c.MarkaId);
            modelBuilder.Entity<Model>().HasMany(c => c.Tasitlari).WithRequired(c => c.Modeli).HasForeignKey(c => c.ModelId);
            modelBuilder.Entity<Tasit>().HasMany(c => c.AracaAitFotograflar).WithRequired(c => c.AitOlduguTasit).HasForeignKey(c => c.TasitId);
            modelBuilder.Entity<Tasit>().HasMany(c => c.AracaAitYorumlar).WithRequired(c => c.Tasiti).HasForeignKey(c => c.TasitId);

            modelBuilder.Configurations.Add(new HasarKayitMap());
            modelBuilder.Configurations.Add(new KategoriMap());
            modelBuilder.Configurations.Add(new MarkaMap());
            modelBuilder.Configurations.Add(new ModelMap());
            modelBuilder.Configurations.Add(new TasitMap());
            modelBuilder.Configurations.Add(new FotografMap());
            modelBuilder.Configurations.Add(new YorumMap());
        }
    }
}
