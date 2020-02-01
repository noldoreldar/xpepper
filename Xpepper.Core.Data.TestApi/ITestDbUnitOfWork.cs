using Microsoft.EntityFrameworkCore;
using Xpepper.Core.Data.EF;
using Xpepper.Core.Data.EF.SqlServer;
using Xpepper.Core.Data.MongoDb;

namespace Xpepper.Core.Data.TestApi
{
    public class TestEntity : MongoDbEntity
    {
        public string Name { get; set; }
    }

    public class TestContext : SqlDbContextBase
    {
        public TestContext(DbContextConfiguration configuration) : base(configuration)
        {

        }

        public DbSet<TestEntity> TestEntities { get; set; }
    }
}
