namespace Xpepper.Core.Data.MongoDb
{
    public class MongoRepositoryFactory<TEntity> : RepositoryFactoryBase<TEntity, MongoDbContextFactory, MongoDbContextClient, MongoDbConfiguration>
        where TEntity : class, IEntity
    {
        public MongoRepositoryFactory(MongoDbContextFactory dataContextFactory) : base(dataContextFactory)
        {

        }

        public override IRepository<TEntity> CreateRepository()
        {
            var collection = DataContextFactory.GetContext().GetDatabase(DataContextFactory.DataContextConfiguration.DatabaseName).GetCollection<TEntity>(typeof(TEntity).Name);
            return new MongoDbRepository<TEntity>(collection);
        }

        
    }
}

