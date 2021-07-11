using Galeri.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeri.Entities.Concrete
{
    public class HasarKayit:IEntity
    {
        public int Id { get; set; }
        public DateTime Tarih { get; set; }
        public decimal Masraf { get; set; }
        public string Parca { get; set; }
        public string Aciklama { get; set; }

        public int TasitId { get; set; }

        public virtual Tasit Tasiti{ get; set; }
    }
}
