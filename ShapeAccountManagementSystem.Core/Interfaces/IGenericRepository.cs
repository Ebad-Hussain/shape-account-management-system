using System.Linq.Expressions;

namespace ShapeAccountManagementSystem.Core.Interfaces
{
    public interface IGenericRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> expression);
        Task<TEntity?> Get(long id);
        Task Add(TEntity entity);
    }
}
