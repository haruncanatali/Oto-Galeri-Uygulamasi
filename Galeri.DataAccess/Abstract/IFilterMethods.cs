using Galeri.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Galeri.DataAccess.Abstract
{
    public interface IFilterMethods<TEntity> where TEntity:class,IEntity,new()
    {
        List<TEntity> GetEntities(Expression<Func<TEntity, bool>> filter = null);
        TEntity GetEntity(Expression<Func<TEntity, bool>> filter);
    }
}
