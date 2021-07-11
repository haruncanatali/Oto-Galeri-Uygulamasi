using Galeri.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeri.Entities.Concrete
{
    public class Tasit:IEntity
    {
        public Tasit()
        {
            HasarKayitlari = new List<HasarKayit>();
            AracaAitFotograflar = new List<Fotograf>();
            AracaAitYorumlar = new List<Yorum>();
        }

        public int Id { get; set; }
        public int Kilometre { get; set; }
        public string TasitBaslik { get; set; }
        public decimal Fiyat { get; set; }
        public bool Garanti { get; set; }
        public bool Takas { get; set; }
        public string Durum { get; set; }
        public string Renk { get; set; }
        public string Plaka { get; set; }
        public string Aciklama { get; set; }

        public int ModelId { get; set; }
        public int KategoriId { get; set; }

        public virtual Model Modeli { get; set; }
        public virtual Kategori Kategorisi { get; set; }
        public virtual ICollection<HasarKayit> HasarKayitlari { get; set; }
        public virtual ICollection<Fotograf> AracaAitFotograflar { get; set; }
        public virtual ICollection<Yorum> AracaAitYorumlar { get; set; }

    }
}
