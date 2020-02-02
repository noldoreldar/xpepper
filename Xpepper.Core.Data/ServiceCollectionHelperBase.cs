using System;
using System.Dynamic;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Xpepper.Core.Data
{
    public abstract class ServiceCollectionHelperBase<TUnitOfWorkService, TUnitOfWorkImplementation, TDataContextConfiguration>
        where TUnitOfWorkService : class, IUnitOfWork
        where TUnitOfWorkImplementation : class, TUnitOfWorkService
        where TDataContextConfiguration : class, IDataContextConfiguration
    {

        public void AddUnitOfWork(IServiceCollection collection, TDataContextConfiguration dataConfiguration)
        {
            collection.AddScoped<TUnitOfWorkService, TUnitOfWorkImplementation>(provider => CreateUnitOfWorkInstance(dataConfiguration));
        }

        protected abstract TUnitOfWorkImplementation CreateUnitOfWorkInstance(TDataContextConfiguration dataConfiguration);
    }
}
