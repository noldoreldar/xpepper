namespace Xpepper.Core.Data.MongoDb
{
    public sealed class MongoDbContextProvider : IContextSourceProvider<MongoDbContextClient, MongoDbConfiguration>
    {

        private MongoDbContextClient _client;

        public MongoDbContextClient GetContext(MongoDbConfiguration configuration)
        {
            _client ??= new MongoDbContextClient(configuration);
            return _client;
        }
    }
}
