namespace Xpepper.Core.Data.MongoDb
{ 
    public sealed class MongoDbConfiguration : IDataContextConfiguration
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
