using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Xpepper.Core.Data
{
    public static class ServiceCollectionExtensions
    {
        public static void AddUnitOfWork<TUnitOfWork, TDataConfiguration>(this IServiceCollection collection, TDataConfiguration dataConfiguration)
            where TUnitOfWork : class, IUnitOfWork
            where TDataConfiguration : class, IDataContextConfiguration
        {
            collection.AddScoped<IDataContextConfiguration, TDataConfiguration>(provider => dataConfiguration);

            collection.AddScoped<IUnitOfWork, TUnitOfWork>(provider =>
            {   
                return Activator.CreateInstance(typeof(TUnitOfWork), BindingFlags.Default, null, new object[] { dataConfiguration }, null, null) as TUnitOfWork;
            });
        }
    }
}
