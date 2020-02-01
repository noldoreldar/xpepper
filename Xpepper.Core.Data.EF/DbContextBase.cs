using Microsoft.EntityFrameworkCore;

namespace Xpepper.Core.Data.EF
{
    public abstract class DbContextBase : DbContext
    {
        public DbContextConfiguration DbDataConfiguration { get; set; }

        protected DbContextBase(DbContextConfiguration configuration)
        {
            DbDataConfiguration = configuration;
        }
    }
}
