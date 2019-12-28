using System;
using System.Reflection;

namespace Xpepper.Core.Data.EF.SqlServer
{
    public sealed class SqlDbContextProvider<TContext> : IDbContextSourceProvider<TContext>
        where TContext : SqlDbContextBase
    {
        public TContext GetContext(DbConfiguration configuration)
        {
            var dbContext = Activator.CreateInstance(typeof(TContext), BindingFlags.Default, null, new object[] { configuration }, null, null) as TContext;
            if (configuration.EnsureDatabaseCreated)
            {
                dbContext?.Database.EnsureCreated();
            }
            return dbContext;
        }
    }
}
