using System;
using System.Collections;
using System.Collections.Generic;

namespace Xpepper.Core.Data
{
    public interface IRepositoryFactory<TEntity> where TEntity : class, IEntity
    {
        IRepository<TEntity> CreateRepository();
    }

    public interface IRepositoryFactory<out TDataContextFactory, TContext, TDataContextConfiguration>
        where TDataContextFactory : IDataContextFactory<TContext, TDataContextConfiguration>
        where TDataContextConfiguration : IDataContextConfiguration
        where TContext : class
    {
        TDataContextFactory DataContextFactory { get; }
    }

    public interface IRepositoryFactory<TEntity, out TDataContextFactory, TContext, TDataContextConfiguration>
        : IRepositoryFactory<TDataContextFactory, TContext, TDataContextConfiguration>, IRepositoryFactory<TEntity>
        where TEntity : class, IEntity
        where TDataContextFactory : IDataContextFactory<TContext, TDataContextConfiguration>
        where TDataContextConfiguration : IDataContextConfiguration
        where TContext : class
    {

    }
}
