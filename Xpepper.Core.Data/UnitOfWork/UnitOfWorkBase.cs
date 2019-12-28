using System.Threading.Tasks;
using Xpepper.Core.Data.Entity;
using Xpepper.Core.Data.Repository;

namespace Xpepper.Core.Data.UnitOfWork
{
    public abstract class UnitOfWorkBase<TContext, TContextSourceProvider, TConfiguration> : IUnitOfWork
        where TContext : class
        where TContextSourceProvider : class, IContextSourceProvider<TContext, TConfiguration>, new()
        where TConfiguration : IDataConfiguration
    {
        protected readonly TConfiguration Configuration;

        protected readonly TContextSourceProvider ContextSourceProvider;

        protected readonly TContext ContextSource;

        protected UnitOfWorkBase(TConfiguration configuration)
        {
            Configuration = configuration;
            ContextSourceProvider = new TContextSourceProvider();
            ContextSource = ContextSourceProvider.GetContext(configuration);
        }

        public void SaveChanges()
        {
            SaveChangesAsync().GetAwaiter().GetResult();
        }

        public abstract Task SaveChangesAsync();

        public abstract IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity;
        
    }
}
