using System;

namespace Xpepper.Core.Data.Entity
{
    public interface IEntity<TId> where TId : struct
    {
        TId Id { get; set; }
        DateTime CreatedOn { get; set; }
        TId CreatedBy { get; set; }
        TId? ModifiedBy { get; set; }
        DateTime? ModifiedOn { get; set; }
        TId? DeletedBy { get; set; }
        DateTime? DeletedOn { get; set; }
    }

    public interface IEntity : IEntity<Guid>
    {

    }
}
