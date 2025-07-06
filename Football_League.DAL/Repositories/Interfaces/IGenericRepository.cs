using Football_League.DAL.Entities;
using System.Linq.Expressions;

namespace Football_League.DAL.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity, new()
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        Task AddAsync(T entity);
        Task Update(T entity);          
        Task Delete(T entity);          
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    }
}
