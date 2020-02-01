using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Xpepper.Core.Data
{
    public abstract class UnitOfWorkBase<TContext, TDataContextFactory, TDataContextConfiguration> : IUnitOfWork<TContext, TDataContextFactory, TDataContextConfiguration>
        where TContext : class
        where TDataContextFactory : IDataContextFactory<TContext, TDataContextConfiguration>
        where TDataContextConfiguration : IDataContextConfiguration
    {
        protected UnitOfWorkBase(TDataContextConfiguration configuration)
        {
            DataContextConfiguration = configuration;
            RepositoryFactories = new List<object>();
            Repositories = new List<IRepository>();
        }

        public TDataContextConfiguration DataContextConfiguration { get; protected set; }

        public abstract TDataContextFactory DataContextFactory { get; }

        protected readonly List<object> RepositoryFactories;

        protected readonly List<IRepository> Repositories;

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity
        {
            var repo = Repositories.OfType<IRepository<TEntity>>().FirstOrDefault();
            if (repo != null)
            {
                return repo;
            }
            var factory = GetRepositoryFactory<TEntity>();
            repo = factory?.CreateRepository();
            if (repo == null)
            {
                throw new ArgumentException($"Could not create repository of entity type '<{typeof(TEntity).Name}>'", nameof(TEntity));
            }
            Repositories.Add(repo);
            return repo;
        }

        public IRepositoryFactory<TEntity> GetRepositoryFactory<TEntity>() where TEntity : class, IEntity
        {
            var factory = RepositoryFactories.OfType<IRepositoryFactory<TEntity>>().FirstOrDefault();
            if (factory != null)
            {
                return factory;
            }
            factory = CreateRepositoryFactory<TEntity>();
            if (factory == null)
            {
                throw new ArgumentException($"Could not create repository factory of entity type '<{typeof(TEntity).Name}>'", nameof(TEntity));
            }
            RepositoryFactories.Add(factory);
            return factory;
        }

        protected abstract IRepositoryFactory<TEntity> CreateRepositoryFactory<TEntity>() where TEntity : class, IEntity;

        protected TContext GetContext()
        {
            return DataContextFactory.GetContext();
        }
    }
}
