using Microsoft.EntityFrameworkCore;

namespace Xpepper.Core.Data.EF.SqlServer
{
    public abstract class SqlDbContextBase : DbContextBase
    {
        protected SqlDbContextBase(DbConfiguration configuration) : base(configuration)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {   
            optionsBuilder.UseSqlServer(DbDataConfiguration.ConnectionString);
            
            base.OnConfiguring(optionsBuilder);
        }
    }
}
