namespace Xpepper.Core.Data.MongoDb
{ 
    public sealed class MongoDbConfiguration : IDataConfiguration
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
