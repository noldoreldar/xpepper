using Microsoft.EntityFrameworkCore;
using Xpepper.Core.Data.Entity;

namespace Xpepper.Core.Data.EF.SqlServer
{
    public sealed class SqlDbRepositoryBase<TEntity> : DbRepositoryBase<TEntity> where TEntity : class, IEntity
    {
        public SqlDbRepositoryBase(DbSet<TEntity> baseDbSet) : base(baseDbSet)
        {

        }
    }
}
