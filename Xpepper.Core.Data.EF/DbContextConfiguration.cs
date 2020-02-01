namespace Xpepper.Core.Data.EF
{ 
    public class DbContextConfiguration : IDataContextConfiguration
    {
        public string ConnectionString { get; set; }
        public bool EnsureDatabaseCreated { get; set; }
    }
}
