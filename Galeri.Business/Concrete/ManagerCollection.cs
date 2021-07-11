using FluentValidation;
using Galeri.Business.Abstract;
using Galeri.Business.ValidationTool;
using Galeri.DataAccess.Abstract;
using Galeri.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Galeri.Business.Concrete
{
    public class ManagerCollection<TEntity, TDal, TValidator> : IServiceCollection<TEntity> 
        where TEntity : class, IEntity, new()
        where TValidator:IValidator,new()
        where TDal:IEntityRepository<TEntity>,IFilterMethods<TEntity>
    {

        TDal dal;
        TValidator validator;

        public ManagerCollection(TDal _dal,TValidator _validator)
        {
            dal = _dal;
            validator = _validator;
        }

        public void Add(TEntity entity)
        {
            EntityValidator.Validate(validator, entity);
            dal.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            dal.Delete(entity);
        }

        public List<TEntity> GetEntities(Expression<Func<TEntity, bool>> filter = null)
        {
            return dal.GetEntities(filter);
        }

        public TEntity GetEntity(Expression<Func<TEntity, bool>> filter)
        {
            return dal.GetEntity(filter);
        }

        public void Update(TEntity entity)
        {
            EntityValidator.Validate(validator, entity);
            dal.Update(entity);
        }
    }
}
