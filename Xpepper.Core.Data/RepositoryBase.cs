using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Xpepper.Core.Data
{
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        protected IQueryable<TEntity> BaseQueryable { get; set; }

        public Type ElementType => BaseQueryable.ElementType;
        public Expression Expression => BaseQueryable.Expression;
        public IQueryProvider Provider => BaseQueryable.Provider;

        public IEnumerator GetEnumerator()
        {
            return BaseQueryable.GetEnumerator();
        }
                
        protected RepositoryBase(IQueryable<TEntity> baseEntityQueryable)
        {
            BaseQueryable = baseEntityQueryable;
        }

        IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator()
        {
            return BaseQueryable.GetEnumerator();
        }

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
