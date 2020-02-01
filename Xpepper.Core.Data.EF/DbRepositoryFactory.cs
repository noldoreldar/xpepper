using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Xpepper.Core.Data.EF
{
    public class DbRepositoryFactory<TEntity, TContext> : RepositoryFactoryBase<TEntity, DbContextFactory<TContext>, TContext, DbContextConfiguration>
        where TEntity : class, IEntity
        where TContext : DbContextBase
    {
        public DbRepositoryFactory(DbContextFactory<TContext> dataContextFactory) : base(dataContextFactory)
        {

        }


        public override IRepository<TEntity> CreateRepository()
        {
            var dbSet = DataContextFactory.GetContext().Set<TEntity>();
            return dbSet == null ? null : new DbRepository<TEntity>(dbSet);
        }

    }
}

