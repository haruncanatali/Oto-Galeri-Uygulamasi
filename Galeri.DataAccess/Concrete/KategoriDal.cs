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
    public class KategoriDal : EntityRepository<Kategori, GaleriContext>, IKategoriDal
    {
        public List<Kategori> GetEntities(Expression<Func<Kategori, bool>> filter = null)
        {
            using (GaleriContext context = new GaleriContext())
            {
                return filter == null ? context.Kategori.Include(c => c.Tasitlar).ToList() : context.Kategori.Include(c => c.Tasitlar).Where(filter).ToList();
            }
        }

        public Kategori GetEntity(Expression<Func<Kategori, bool>> filter)
        {
            using (GaleriContext context = new GaleriContext())
            {
                return context.Kategori.Include(c => c.Tasitlar).SingleOrDefault(filter);
            }
        }
    }
}
