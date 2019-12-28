using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Xpepper.Core.Data.Entity;

namespace Xpepper.Core.Data.Repository
{
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        protected readonly IQueryable<TEntity> BaseQueryable;
        protected RepositoryBase(IQueryable<TEntity> baseQueryable)
        {
            BaseQueryable = baseQueryable;
        }

        IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator() 
        {
            return BaseQueryable.GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            return BaseQueryable.GetEnumerator();
        }

        public Type ElementType => BaseQueryable.ElementType;
        public Expression Expression => BaseQueryable.Expression;
        public IQueryProvider Provider => BaseQueryable.Provider;
        public TEntity Insert(TEntity entity)
        {
           return InsertEntity(entity);
        }

        public void InsertRange(IEnumerable<TEntity> entities)
        {
            InsertEntities(entities);
        }

        public TEntity Delete(TEntity entity)
        {
            return DeleteEntity(entity);
        }

        protected abstract TEntity InsertEntity(TEntity entity);

        protected abstract TEntity DeleteEntity(TEntity entity);

        protected abstract void InsertEntities(IEnumerable<TEntity> entities);
    }
}
