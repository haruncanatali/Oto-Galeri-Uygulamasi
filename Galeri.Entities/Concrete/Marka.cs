using Galeri.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeri.Entities.Concrete
{
    public class Marka:IEntity
    {
        public Marka()
        {
            Modeller = new List<Model>();
        }
        
        public int Id { get; set; }
        public string MarkaAdi { get; set; }

        public virtual ICollection<Model> Modeller{ get; set; }
    }
}
