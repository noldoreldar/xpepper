using System;
using System.Reflection;

namespace Xpepper.Core.Data.EF
{
    public class DbContextFactory<TContext> : IDataContextFactory<TContext, DbContextConfiguration>
        where TContext : DbContextBase 
    {
        public DbContextFactory(DbContextConfiguration configuration)
        {
            DataContextConfiguration = configuration;
        }

        private TContext _context;

        public DbContextConfiguration DataContextConfiguration { get; }
        public TContext GetContext()
        {
            _context ??= Activator.CreateInstance(typeof(TContext), BindingFlags.Default, null, new object[] { DataContextConfiguration }, null, null) as TContext;
            if (DataContextConfiguration.EnsureDatabaseCreated)
            {
                _context?.Database.EnsureCreated();
            }
            return _context;
        }
    }
}
