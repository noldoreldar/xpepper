namespace Xpepper.Core.Data.MongoDb
{
    public sealed class MongoDbContextFactory : IDataContextFactory<MongoDbContextClient, MongoDbConfiguration>
    {
        public MongoDbContextFactory(MongoDbConfiguration configuration)
        {
            DataContextConfiguration = configuration;
        }

        private MongoDbContextClient _client;

        public MongoDbContextClient GetContext()
        {
            _client ??= new MongoDbContextClient(DataContextConfiguration);
            return _client;
        }
        public MongoDbConfiguration DataContextConfiguration { get; }
    }
}
