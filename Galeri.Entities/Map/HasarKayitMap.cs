using Galeri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Galeri.Entities.Map
{
    public class HasarKayitMap:EntityTypeConfiguration<HasarKayit>
    {
        public HasarKayitMap()
        {
            this.HasKey(c => c.Id);
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(c => c.Tarih).IsRequired();
            this.Property(c => c.Masraf).IsRequired().HasPrecision(18,2);
            this.Property(c => c.Parca).IsRequired().HasMaxLength(50);
            this.Property(c => c.TasitId).IsRequired();

            this.ToTable("HasarKayit");
            this.Property(c => c.Id).HasColumnName("Id");
            this.Property(c => c.Tarih).HasColumnName("Tarih");
            this.Property(c => c.Masraf).HasColumnName("Masraf");
            this.Property(c => c.Parca).HasColumnName("Parca");
            this.Property(c => c.TasitId).HasColumnName("TasitId");
        }
    }
}
