using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xpepper.Core.Data.Entity;
using Xpepper.Core.Data.Repository;
using Xpepper.Core.Data.UnitOfWork;

namespace Xpepper.Core.Data.EF
{
    public abstract class DbUnitOfWorkBase<TContext, TContextSourceProvider> : UnitOfWorkBase<TContext, TContextSourceProvider, DbConfiguration>
        where TContext : DbContextBase
        where TContextSourceProvider : class, IDbContextSourceProvider<TContext>, new()
    {
        protected bool IsDisposed;

        protected readonly DbConfiguration DbDataConfiguration;

        protected DbUnitOfWorkBase(DbConfiguration configuration) : base(configuration)
        {
            DbDataConfiguration = configuration;
        }

        public override Task SaveChangesAsync()
        {
            return ContextSource.SaveChangesAsync();
        }

        public override IRepository<TEntity> GetRepository<TEntity>()
        {
            var dbSet = ContextSource.Set<TEntity>();
            return CreateOrGetRepositoryFromDbSet(dbSet);
        }

        protected abstract IRepository<TEntity> CreateOrGetRepositoryFromDbSet<TEntity>(DbSet<TEntity> dbSet) where TEntity : class, IEntity;

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (IsDisposed)
                return;

            if (disposing)
            {
                ContextSource.Dispose();
            }
            // Free any unmanaged objects here.
            //
            IsDisposed = true;
        }

        ~DbUnitOfWorkBase()
        {
            Dispose(false);
        }

        public ValueTask DisposeAsync()
        {
            var valueTask = DisposeAsync(true);
            GC.SuppressFinalize(this);
            return valueTask;
        }

        protected virtual ValueTask DisposeAsync(bool disposing)
        {
            try
            {
                return ContextSource.DisposeAsync();
            }
            catch (Exception exc)
            {
                return new ValueTask(Task.FromException(exc));
            }
        }

    }
}
