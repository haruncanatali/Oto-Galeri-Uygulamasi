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
    public class ModelDal : EntityRepository<Model, GaleriContext>, IModelDal
    {
        public List<Model> GetEntities(Expression<Func<Model, bool>> filter = null)
        {
            using (GaleriContext context = new GaleriContext())
            {
                return filter == null ? context.Model.Include(c => c.Markasi).ToList() : context.Model.Include(c => c.Markasi).Where(filter).ToList();
            }
        }

        public Model GetEntity(Expression<Func<Model, bool>> filter)
        {
            using (GaleriContext context = new GaleriContext())
            {
                return context.Model.Include(c => c.Markasi).SingleOrDefault(filter);
            }
        }
    }
}
