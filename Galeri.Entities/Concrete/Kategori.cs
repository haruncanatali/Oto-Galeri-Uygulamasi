using Galeri.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeri.Entities.Concrete
{
    public class Kategori:IEntity
    {
        public Kategori()
        {
            Tasitlar = new List<Tasit>();
        }

        public int Id { get; set; }
        public string KategoriAdi { get; set; }

        public virtual ICollection<Tasit> Tasitlar{ get; set; }
    }
}
