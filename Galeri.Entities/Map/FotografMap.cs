using Galeri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeri.Entities.Map
{
    public class FotografMap:EntityTypeConfiguration<Fotograf>
    {
        public FotografMap()
        {
            this.HasKey(c => c.Id);
            this.Property(c => c.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.Property(c => c.FotografAdi).IsRequired();
            this.Property(c => c.TasitId).IsRequired();

            this.ToTable("Fotograf");
            this.Property(c => c.FotografAdi).HasColumnName("FotografAdi");
            this.Property(c => c.TasitId).HasColumnName("TasitId");
        }
    }
}
