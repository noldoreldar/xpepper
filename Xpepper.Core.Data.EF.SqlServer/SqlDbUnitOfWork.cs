using Microsoft.EntityFrameworkCore;
using Xpepper.Core.Data.Repository;

namespace Xpepper.Core.Data.EF.SqlServer
{
    public class SqlDbUnitOfWork<TContext> : DbUnitOfWorkBase<TContext, SqlDbContextProvider<TContext>>
        where TContext : SqlDbContextBase
    {
        public SqlDbUnitOfWork(DbConfiguration configuration) : base(configuration)
        {

        }

        protected override IRepository<TEntity> CreateOrGetRepositoryFromDbSet<TEntity>(DbSet<TEntity> dbSet)
        {
            return new SqlDbRepositoryBase<TEntity>(dbSet);
        }
    }
}
