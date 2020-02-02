using Microsoft.Extensions.DependencyInjection;

namespace Xpepper.Core.Data.MongoDb
{
    public sealed class MongoDbServiceCollectionHelper<TUnitOfWorkService, TUnitOfWorkImplementation> : ServiceCollectionHelperBase<TUnitOfWorkService, TUnitOfWorkImplementation, MongoDbConfiguration>
        where TUnitOfWorkService : class, IUnitOfWork
        where TUnitOfWorkImplementation : MongoDbUnitOfWork, TUnitOfWorkService
    {
        protected override TUnitOfWorkImplementation CreateUnitOfWorkInstance(MongoDbConfiguration dataConfiguration)
        {
            return new MongoDbUnitOfWork(dataConfiguration) as TUnitOfWorkImplementation;
        }
    }

    public static class ServiceCollectionExtension
    {
        public static void AddMongoDbUnitOfWork(this IServiceCollection collection, MongoDbConfiguration dataConfiguration)
        {
            AddMongoDbUnitOfWork<MongoDbUnitOfWork, MongoDbUnitOfWork>(collection, dataConfiguration);
        }

        public static void AddMongoDbUnitOfWork<TUnitOfWorkService, TUnitOfWorkImplementation>(this IServiceCollection collection, MongoDbConfiguration dataConfiguration)
            where TUnitOfWorkService : class, IUnitOfWork
            where TUnitOfWorkImplementation : MongoDbUnitOfWork, TUnitOfWorkService
        {
            new MongoDbServiceCollectionHelper<TUnitOfWorkService, TUnitOfWorkImplementation>().AddUnitOfWork(collection, dataConfiguration);
        }
    }
}
