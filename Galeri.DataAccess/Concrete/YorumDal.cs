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
    public class YorumDal : EntityRepository<Yorum, GaleriContext>, IYorumDal
    {
        public List<Yorum> GetEntities(Expression<Func<Yorum, bool>> filter = null)
        {
            using (GaleriContext context = new GaleriContext())
            {
                return filter == null ? context.Yorum.ToList() : context.Yorum.Where(filter).ToList();
            }
        }

        public Yorum GetEntity(Expression<Func<Yorum, bool>> filter)
        {
            using (GaleriContext context = new GaleriContext())
            {
                return context.Yorum.SingleOrDefault(filter);
            }
        }
    }
}
