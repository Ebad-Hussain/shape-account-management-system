using Microsoft.EntityFrameworkCore;
using ShapeAccountManagementSystem.Core.Interfaces;
using ShapeAccountManagementSystem.Infrastracture.Context;
using System.Linq.Expressions;

namespace ShapeAccountManagemenSystem.Application.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ShapeDbContext _context;
        public GenericRepository(ShapeDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> expression) => 
            await _context.Set<TEntity>().Where(expression).ToListAsync();
        public async Task<TEntity?> Get(long id) => await _context.Set<TEntity>().FindAsync(id);
        public async Task<IEnumerable<TEntity>> GetAll() => await _context.Set<TEntity>().AsNoTracking().ToListAsync();
        public async Task Add(TEntity entity)
        {
            _ = await _context.Set<TEntity>().AddAsync(entity);
            _ = await _context.SaveChangesAsync();
        }
    }
}
