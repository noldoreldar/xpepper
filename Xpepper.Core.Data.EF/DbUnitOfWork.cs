using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Xpepper.Core.Data.EF
{
    public class DbUnitOfWork<TContext> : UnitOfWorkBase<TContext, DbContextFactory<TContext>, DbContextConfiguration>
        where TContext : DbContextBase
    {
        public DbUnitOfWork(DbContextConfiguration configuration) : base(configuration)
        {
            _dbDataConfiguration = configuration;
            DataContextFactory = new DbContextFactory<TContext>(_dbDataConfiguration);
        }

        private bool _isDisposed;

        private readonly DbContextConfiguration _dbDataConfiguration;

        public override DbContextFactory<TContext> DataContextFactory { get; }
        protected override IRepositoryFactory<TEntity> CreateRepositoryFactory<TEntity>()
        {
            return new DbRepositoryFactory<TEntity, TContext>(DataContextFactory);
        }

        public void SaveChanges()
        {
            SaveChangesAsync().GetAwaiter().GetResult();
        }

        public Task SaveChangesAsync()
        {
            return GetContext().SaveChangesAsync();
        }

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed)
                return;

            if (disposing)
            {
                GetContext().Dispose();
            }
            // Free any unmanaged objects here.
            //
            _isDisposed = true;
        }

        ~DbUnitOfWork()
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
                return GetContext().DisposeAsync();
            }
            catch (Exception exc)
            {
                return new ValueTask(Task.FromException(exc));
            }
        }
    }
}
