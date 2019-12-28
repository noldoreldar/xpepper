using Microsoft.EntityFrameworkCore;

namespace Xpepper.Core.Data.EF
{
    public abstract class DbContextBase : DbContext
    {
        public DbConfiguration DbDataConfiguration { get; set; }

        protected DbContextBase(DbConfiguration configuration)
        {
            DbDataConfiguration = configuration;
        }
    }
}
