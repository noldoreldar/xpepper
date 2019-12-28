using MongoDB.Driver;

namespace Xpepper.Core.Data.MongoDb
{
    public sealed class MongoDbContextClient : MongoClient
    {   
        public MongoDbContextClient(MongoDbConfiguration configuration) : base(configuration.ConnectionString)
        {
        
        }
    }
}
