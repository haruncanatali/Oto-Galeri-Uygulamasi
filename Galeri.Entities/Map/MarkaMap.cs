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
    public class MarkaMap:EntityTypeConfiguration<Marka>
    {
        public MarkaMap()
        {
            this.HasKey(c => c.Id);
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(c => c.MarkaAdi).HasMaxLength(50).IsRequired();

            this.ToTable("Marka");
            this.Property(c => c.Id).HasColumnName("Id");
            this.Property(c => c.MarkaAdi).HasColumnName("MarkaAdi");
        }
    }
}
