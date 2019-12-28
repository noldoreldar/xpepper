using System;
using MongoDB.Bson.Serialization.Attributes;
using Xpepper.Core.Data.Entity;

namespace Xpepper.Core.Data.MongoDb
{
    public abstract class MongoDbEntity : IEntity
    {
        [BsonId(IdGenerator = typeof(GuidIdGenerator))]
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
