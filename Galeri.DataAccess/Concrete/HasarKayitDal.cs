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
    public class HasarKayitDal : EntityRepository<HasarKayit, GaleriContext>, IHasarKayitDal
    {
        public List<HasarKayit> GetEntities(Expression<Func<HasarKayit, bool>> filter = null)
        {
            using (GaleriContext context = new GaleriContext())
            {
                return filter == null ? context.HasarKayit.Include(c => c.Tasiti).ToList() : context.HasarKayit.Include(c => c.Tasiti).Where(filter).ToList(); 
            }
        }

        public HasarKayit GetEntity(Expression<Func<HasarKayit, bool>> filter)
        {
            using (GaleriContext context = new GaleriContext())
            {
                return context.HasarKayit.Include(c => c.Tasiti).SingleOrDefault(filter);
            }
        }
    }
}
