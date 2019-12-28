using System;
using System.Reflection;

namespace Xpepper.Core.Data.EF.SqlServer
{
    public sealed class SqlDbContextProvider<TContext> : IDbContextSourceProvider<TContext>
        where TContext : SqlDbContextBase
    {
        private TContext _context;

        public TContext GetContext(DbConfiguration configuration)
        {
            _context ??= Activator.CreateInstance(typeof(TContext), BindingFlags.Default, null, new object[] { configuration }, null, null) as TContext;
            if (configuration.EnsureDatabaseCreated)
            {
                _context?.Database.EnsureCreated();
            }
            return _context;
        }
    }
}
