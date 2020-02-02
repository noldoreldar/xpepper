using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Xpepper.Core.Data.EF.SqlServer
{
    public sealed class DbServiceCollectionHelper<TContext, TUnitOfWorkService, TUnitOfWorkImplementation> : ServiceCollectionHelperBase<TUnitOfWorkService, TUnitOfWorkImplementation, DbContextConfiguration>
        where TUnitOfWorkService : class, IUnitOfWork
        where TUnitOfWorkImplementation : DbUnitOfWork<TContext>, TUnitOfWorkService
        where TContext : DbContextBase
    {
        protected override TUnitOfWorkImplementation CreateUnitOfWorkInstance(DbContextConfiguration dataConfiguration)
        {
            return new DbUnitOfWork<TContext>(dataConfiguration) as TUnitOfWorkImplementation;
        }
    }

    public static class ServiceCollectionExtension
    {
        public static void AddSqlDbUnitOfWork<TContext>(this IServiceCollection collection, DbContextConfiguration dataConfiguration)
            where TContext : DbContextBase
        {
            AddSqlDbUnitOfWork<TContext, DbUnitOfWork<TContext>, DbUnitOfWork<TContext>>(collection, dataConfiguration);
        }

        public static void AddSqlDbUnitOfWork<TContext, TUnitOfWorkService, TUnitOfWorkImplementation>(this IServiceCollection collection, DbContextConfiguration dataConfiguration)
            where TUnitOfWorkService : class, IUnitOfWork
            where TUnitOfWorkImplementation : DbUnitOfWork<TContext>, TUnitOfWorkService
            where TContext : DbContextBase
        {
            new DbServiceCollectionHelper<TContext, TUnitOfWorkService, TUnitOfWorkImplementation>().AddUnitOfWork(collection, dataConfiguration);
        }
    }
}
