using System.Collections.Generic;
using System.Linq;
using Xpepper.Core.Data.Entity;

namespace Xpepper.Core.Data.Repository
{
    public interface IRepository : IQueryable
    {

    }

    public interface IRepository<TEntity> : IRepository, IQueryable<TEntity> where TEntity : IEntity
    {
        TEntity Insert(TEntity entity);

        void InsertRange(IEnumerable<TEntity> entities);

        TEntity Delete(TEntity entity);
    }
}
