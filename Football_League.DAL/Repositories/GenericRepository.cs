using Football_League.DAL.Data;
using Football_League.DAL.Entities;
using Football_League.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace Football_League.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity,new()
    {
        protected readonly FootballLeagueContext _context;
        protected readonly DbSet<T> _dbSet;
        public GenericRepository(FootballLeagueContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);
        public void Delete(T entity) => _dbSet.Update(entity);
        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            return await query.AsNoTracking().ToListAsync();
        }
        public async Task<T> GetByIdAsync(int id) => await _dbSet.FindAsync(id);
        public void Update(T entity) => _dbSet.Update(entity);
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate) => await _dbSet.AnyAsync(predicate);
    }
}
