using Galeri.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeri.Entities.Concrete
{
    public class Fotograf:IEntity
    {
        public int Id { get; set; }
        public string FotografAdi { get; set; }

        public int TasitId { get; set; }

        public virtual Tasit AitOlduguTasit { get; set; }
    }
}
