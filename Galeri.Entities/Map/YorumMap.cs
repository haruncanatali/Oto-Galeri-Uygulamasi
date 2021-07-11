using Galeri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeri.Entities.Map
{
    public class YorumMap:EntityTypeConfiguration<Yorum>
    {
        public YorumMap()
        {
            this.HasKey(c => c.Id);
            this.Property(c => c.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.Property(c => c.Ad).HasMaxLength(25).IsRequired();
            this.Property(c => c.Soyad).HasMaxLength(25).IsRequired();
            this.Property(c => c.Mail).HasMaxLength(100).IsRequired();
            this.Property(c => c.Icerik).HasMaxLength(2500).IsRequired();
            this.Property(c => c.TasitId).IsRequired();

            this.ToTable("Yorum");
            this.Property(c => c.Id).HasColumnName("Id");
            this.Property(c => c.Ad).HasColumnName("Ad");
            this.Property(c => c.Soyad).HasColumnName("Soyad");
            this.Property(c => c.Mail).HasColumnName("Mail");
            this.Property(c => c.Icerik).HasColumnName("Icerik");
            this.Property(c => c.TasitId).HasColumnName("TasitId");
        }
    }
}
