using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Xpepper.Core.Data.EF
{
    public class DbRepository<TEntity> : RepositoryBase<TEntity>
           where TEntity : class, IEntity
    {
        private readonly DbSet<TEntity> _baseDbSet;

        public DbRepository(DbSet<TEntity> baseDbSet) : base(baseDbSet)
        {
            _baseDbSet = baseDbSet;
        }

        protected override TEntity DeleteEntity(TEntity entity)
        {
            var entityEntry = _baseDbSet.Remove(entity);
            return entityEntry?.Entity;
        }

        protected override TEntity InsertEntity(TEntity entity)
        {
            var entityEntry = _baseDbSet.Add(entity);
            return entityEntry?.Entity;
        }

        protected override void InsertEntities(IEnumerable<TEntity> entities)
        {
            _baseDbSet.AddRange(entities);
        }
    }
}
