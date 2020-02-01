using System;
using System.Collections.Generic;
using System.Text;

namespace Xpepper.Core.Data
{
    public abstract class RepositoryFactoryBase<TEntity, TDataContextFactory, TContext, TDataContextConfiguration> : IRepositoryFactory<TEntity, TDataContextFactory, TContext, TDataContextConfiguration>
        where TEntity : class, IEntity
        where TDataContextFactory : IDataContextFactory<TContext, TDataContextConfiguration>
        where TDataContextConfiguration : IDataContextConfiguration
        where TContext : class
    {
        public TDataContextFactory DataContextFactory { get; }

        protected RepositoryFactoryBase(TDataContextFactory dataContextFactory)
        {
            DataContextFactory = dataContextFactory;
        }

        public abstract IRepository<TEntity> CreateRepository();
    }
}
