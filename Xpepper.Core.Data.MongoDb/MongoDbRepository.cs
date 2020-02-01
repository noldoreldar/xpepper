using System.Collections.Generic;
using MongoDB.Driver;

namespace Xpepper.Core.Data.MongoDb
{
    public sealed class MongoDbRepository<TEntity> : RepositoryBase<TEntity> where TEntity : class, IEntity
    {
        private readonly IMongoCollection<TEntity> _collection;

        public MongoDbRepository(IMongoCollection<TEntity> collection) : base(collection.AsQueryable())
        {
            _collection = collection;
        }

        protected override TEntity DeleteEntity(TEntity entity)
        {
            _collection.DeleteOne(new ExpressionFilterDefinition<TEntity>(x=> x.Id == entity.Id));
            return entity;
        }

        protected override void InsertEntities(IEnumerable<TEntity> entities)
        {
            _collection.InsertMany(entities);
        }

        protected override TEntity InsertEntity(TEntity entity)
        {
            _collection.InsertOne(entity);
            return entity;
        }
    }
}
