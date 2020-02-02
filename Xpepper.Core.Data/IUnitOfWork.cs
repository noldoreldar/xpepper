using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Xpepper.Core.Data
{
    public interface IUnitOfWork
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity;

        IRepositoryFactory<TEntity> GetRepositoryFactory<TEntity>() where TEntity : class, IEntity;
    }
   
    public interface IUnitOfWork<TContext, out TDataContextFactory, out TDataContextConfiguration> : IUnitOfWork
        where TContext : class
        where TDataContextFactory : IDataContextFactory<TContext, TDataContextConfiguration>
        where TDataContextConfiguration : IDataContextConfiguration
    {
        TDataContextConfiguration DataContextConfiguration { get; }

        TDataContextFactory DataContextFactory { get; }
    }

}
