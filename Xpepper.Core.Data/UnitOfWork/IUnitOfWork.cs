using System.Threading.Tasks;
using Xpepper.Core.Data.Entity;
using Xpepper.Core.Data.Repository;

namespace Xpepper.Core.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        void SaveChanges();

        Task SaveChangesAsync();
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity;
    }

}
