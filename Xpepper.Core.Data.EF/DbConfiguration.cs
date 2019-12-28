namespace Xpepper.Core.Data.EF
{ 
    public sealed class DbConfiguration : IDataConfiguration
    {
        public string ConnectionString { get; set; }
        public bool EnsureDatabaseCreated { get; set; }
    }
}
