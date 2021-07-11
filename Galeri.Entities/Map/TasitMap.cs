using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Galeri.Entities.Concrete;

namespace Galeri.Entities.Map
{
    public class TasitMap:EntityTypeConfiguration<Tasit>
    {
        public TasitMap()
        {
            this.HasKey(c => c.Id);
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(c => c.TasitBaslik).IsRequired().HasMaxLength(250);
            this.Property(c => c.Kilometre).IsRequired();
            this.Property(c => c.Fiyat).IsRequired().HasPrecision(18, 2);
            this.Property(c => c.Garanti).IsRequired();
            this.Property(c => c.Takas).IsRequired();
            this.Property(c => c.Durum).HasMaxLength(15).IsRequired();
            this.Property(c => c.Renk).HasMaxLength(50).IsRequired();
            this.Property(c => c.Plaka).HasMaxLength(7).IsRequired();
            this.Property(c => c.Aciklama).HasMaxLength(15000).IsOptional();

            this.Property(c => c.ModelId).IsRequired();
            this.Property(c => c.KategoriId).IsRequired();

            this.ToTable("Tasit");
            this.Property(c => c.Id).HasColumnName("Id");
            this.Property(c => c.Kilometre).HasColumnName("Kilometre");
            this.Property(c => c.TasitBaslik).HasColumnName("TasitBaslik");
            this.Property(c => c.Fiyat).HasColumnName("Fiyat");
            this.Property(c => c.Garanti).HasColumnName("Garanti");
            this.Property(c => c.Takas).HasColumnName("Takas");
            this.Property(c => c.Durum).HasColumnName("Durum");
            this.Property(c => c.Renk).HasColumnName("Renk");
            this.Property(c => c.Plaka).HasColumnName("Plaka");
            this.Property(c => c.Aciklama).HasColumnName("Aciklama");
            this.Property(c => c.ModelId).HasColumnName("ModelId");
            this.Property(c => c.KategoriId).HasColumnName("KategoriId");
        }
    }
}
