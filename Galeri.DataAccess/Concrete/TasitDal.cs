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
    public class TasitDal : EntityRepository<Tasit, GaleriContext>, ITasitDal
    {
        public List<Tasit> GetEntities(Expression<Func<Tasit, bool>> filter = null)
        {
            using (GaleriContext context = new GaleriContext())
            {
                return filter == null ? context.Tasit.Include(c=>c.AracaAitYorumlar).Include(c=>c.HasarKayitlari).Include(c => c.Modeli).Include(c=>c.Kategorisi).Include(c=>c.AracaAitFotograflar).ToList() : context.Tasit.Include(c => c.AracaAitYorumlar).Include(c => c.Modeli).Include(c => c.HasarKayitlari).Include(c => c.AracaAitFotograflar).Where(filter).ToList();
            }
        }

        public Tasit GetEntity(Expression<Func<Tasit, bool>> filter)
        {
            using (GaleriContext context = new GaleriContext())
            {
                return context.Tasit.Include(c => c.AracaAitYorumlar).Include(c => c.Modeli).Include(c => c.HasarKayitlari).Include(c=>c.Kategorisi).Include(c => c.AracaAitFotograflar).SingleOrDefault(filter);
            }
        }
    }
}
