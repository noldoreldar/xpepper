using MongoDB.Driver;

namespace Xpepper.Core.Data.MongoDb
{
    public class MongoDbContextClient : MongoClient
    {   
        public MongoDbContextClient(MongoDbConfiguration configuration) : base(configuration.ConnectionString)
        {
        
        }
    }
}
