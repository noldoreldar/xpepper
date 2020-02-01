using System.Collections.Generic;
using System.Linq;

namespace Xpepper.Core.Data
{
    public interface IRepository : IQueryable
    {
       
    }

    public interface IRepository<TEntity> : IRepository, IQueryable<TEntity>
        where TEntity : class, IEntity
    {
        TEntity Insert(TEntity entity);

        void InsertRange(IEnumerable<TEntity> entities);

        TEntity Delete(TEntity entity);
    }
}
