using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Xpepper.Core.Data.Entity;
using Xpepper.Core.Data.Repository;

namespace Xpepper.Core.Data.EF
{
    public abstract class DbRepositoryBase<TEntity> : RepositoryBase<TEntity> where TEntity : class, IEntity
    {
        protected readonly DbSet<TEntity> BaseDbSet;

        protected DbRepositoryBase(DbSet<TEntity> baseDbSet) : base(baseDbSet)
        {
            BaseDbSet = baseDbSet;
        }

        protected override TEntity DeleteEntity(TEntity entity)
        {
            var entityEntry = BaseDbSet.Remove(entity);
            return entityEntry?.Entity;
        }

        protected override TEntity InsertEntity(TEntity entity)
        {
            var entityEntry = BaseDbSet.Add(entity);
            return entityEntry?.Entity;
        }

        protected override void InsertEntities(IEnumerable<TEntity> entities)
        {
            BaseDbSet.AddRange(entities);
        }
    }
}
