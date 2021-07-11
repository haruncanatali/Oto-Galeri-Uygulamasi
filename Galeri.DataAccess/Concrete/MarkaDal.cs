using Galeri.DataAccess.Abstract;
using Galeri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Galeri.DataAccess.Concrete
{
    public class MarkaDal : EntityRepository<Marka, GaleriContext>, IMarkaDal
    {
        public List<Marka> GetEntities(Expression<Func<Marka, bool>> filter = null)
        {
            using (GaleriContext context = new GaleriContext())
            {
                return filter == null ? context.Marka.Include(c => c.Modeller).ToList() : context.Marka.Include(c => c.Modeller).Where(filter).ToList();
            }
        }

        public Marka GetEntity(Expression<Func<Marka, bool>> filter)
        {
            using (GaleriContext context = new GaleriContext())
            {
                return context.Marka.Include(c => c.Modeller).SingleOrDefault(filter);
            }
        }
    }
}
