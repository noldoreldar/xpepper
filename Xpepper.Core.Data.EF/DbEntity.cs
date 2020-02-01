using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Xpepper.Core.Data.EF
{
    public abstract class DbEntity : IEntity<Guid>
    {
        object IEntity.Id
        {
            get => Id;
            set => Id = (Guid)value;
        }
        public Guid CreatedBy { get; set; }
        public Guid? ModifiedBy { get; set; }
        public Guid? DeletedBy { get; set; }
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        
        [NotMapped]
        object IEntity.CreatedBy
        {
            get => CreatedBy;
            set => CreatedBy = (Guid)value;
        }

        public DateTime? ModifiedOn { get; set; }
        
        [NotMapped]
        object IEntity.ModifiedBy
        {
            get => ModifiedBy;
            set => ModifiedBy = (Guid)value;
        }

        public DateTime? DeletedOn { get; set; }
        
        [NotMapped]
        object IEntity.DeletedBy
        {
            get => DeletedBy;
            set => DeletedBy = (Guid)value;
        }
    }
}
