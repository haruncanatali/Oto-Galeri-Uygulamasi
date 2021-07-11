using Galeri.DataAccess.Abstract;
using Galeri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Galeri.DataAccess.Concrete
{
    public class FotografDal : EntityRepository<Fotograf, GaleriContext>, IFotografDal
    {
        public List<Fotograf> GetEntities(Expression<Func<Fotograf, bool>> filter = null)
        {
            using (GaleriContext context = new GaleriContext())
            {
                return filter == null ? context.Fotograf.ToList() : context.Fotograf.Where(filter).ToList();
            }
        }

        public Fotograf GetEntity(Expression<Func<Fotograf, bool>> filter)
        {
            using (GaleriContext context = new GaleriContext())
            {
                return context.Fotograf.SingleOrDefault(filter);
            }
        }
    }
}
