using System;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Xpepper.Core.Data.MongoDb
{
    public sealed class MongoDbUnitOfWork : UnitOfWorkBase<MongoDbContextClient, MongoDbContextFactory, MongoDbConfiguration>, IDisposable, IAsyncDisposable
    {
        private bool _isDisposed;
        
        private readonly IMongoDatabase _mongoDbDatabase;

        public MongoDbUnitOfWork(MongoDbConfiguration configuration) : base(configuration)
        {
            DataContextFactory = new MongoDbContextFactory(configuration);
            _mongoDbDatabase = GetContext().GetDatabase(configuration.DatabaseName);
        }
        
        public override MongoDbContextFactory DataContextFactory { get; }

        protected override IRepositoryFactory<TEntity> CreateRepositoryFactory<TEntity>()
        {
            return new MongoRepositoryFactory<TEntity>(DataContextFactory);
        }

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        private void Dispose(bool disposing)
        {
            if (_isDisposed)
                return;

            if (disposing)
            {
                //ContextSource.Client.;
            }
            // Free any unmanaged objects here.
            //
            _isDisposed = true;
        }

        ~MongoDbUnitOfWork()
        {
            Dispose(false);
        }

        public ValueTask DisposeAsync()
        {
            var valueTask = DisposeAsync(true);
            GC.SuppressFinalize(this);
            return valueTask;
        }

        private ValueTask DisposeAsync(bool disposing)
        {
            try
            {
                //return ContextSource.DisposeAsync();
                return new ValueTask(Task.FromResult(0));
            }
            catch (Exception exc)
            {
                return new ValueTask(Task.FromException(exc));
            }
        }

    }
}
