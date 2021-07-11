using Galeri.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeri.Entities.Concrete
{
    public class Model:IEntity
    {
        public Model()
        {
            Tasitlari = new List<Tasit>();
        }

        public int Id { get; set; }
        public string ModelAdi { get; set; }
        public string Vites { get; set; }
        public string Yakit { get; set; }
        public short Yil { get; set; }
        public string KasaTipi { get; set; }
        public short MotorGucu { get; set; }
        public short MotorHacmi { get; set; }
        public string Cekis { get; set; }
        public short AzamiSurat { get; set; }
        public short BagajKapasitesi { get; set; }

        public int MarkaId { get; set; }

        public virtual Marka Markasi { get; set; }
        public virtual ICollection<Tasit> Tasitlari { get; set; }
    }
}
