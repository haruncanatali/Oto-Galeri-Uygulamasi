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
    public class ModelMap:EntityTypeConfiguration<Model>
    {
        public ModelMap()
        {
            this.HasKey(c => c.Id);
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(c => c.ModelAdi).IsRequired().HasMaxLength(50);
            this.Property(c => c.Vites).IsRequired().HasMaxLength(20);
            this.Property(c => c.Yil).IsRequired();
            this.Property(c => c.MotorGucu).IsRequired();
            this.Property(c => c.MotorHacmi).IsRequired();
            this.Property(c => c.AzamiSurat).IsRequired();
            this.Property(c => c.BagajKapasitesi).IsRequired();
            this.Property(c => c.Yakit).IsRequired().HasMaxLength(15);
            this.Property(c => c.MarkaId).IsRequired();
            this.Property(c => c.KasaTipi).HasMaxLength(25).IsRequired();
            this.Property(c => c.Cekis).HasMaxLength(15).IsRequired();

            this.ToTable("Model");
            this.Property(c => c.Id).HasColumnName("Id");
            this.Property(c => c.ModelAdi).HasColumnName("ModelAdi");
            this.Property(c => c.Vites).HasColumnName("Vites");
            this.Property(c => c.Yil).HasColumnName("Yil");
            this.Property(c => c.MotorGucu).HasColumnName("MotorGucu");
            this.Property(c => c.MotorHacmi).HasColumnName("MotorHacmi");
            this.Property(c => c.AzamiSurat).HasColumnName("AzamiSurat");
            this.Property(c => c.BagajKapasitesi).HasColumnName("BagajKapasitesi");
            this.Property(c => c.Yakit).HasColumnName("Yakit");
            this.Property(c => c.KasaTipi).HasColumnName("KasaTipi");
            this.Property(c => c.Cekis).HasColumnName("Cekis");
            this.Property(c => c.MarkaId).HasColumnName("MarkaId");
        }
    }
}
