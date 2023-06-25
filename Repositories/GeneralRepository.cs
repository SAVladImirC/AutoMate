using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Repositories
{
    public class GeneralRepository<T> where T : class
    {
        public readonly AutoMateDbContext _context;

        public GeneralRepository(AutoMateDbContext context)
        {
            _context = context;
        }

        public async Task<T?> FindSingle(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).SingleOrDefaultAsync();
        }

        public async Task<List<T>> FindAll(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<T> Insert(T entity)
        {
            var e = await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return e.Entity;
        }

        public async Task<T> Update(T entity)
        {
            var e = _context.Update<T>(entity);
            await _context.SaveChangesAsync();
            return e.Entity;
        }

        public async Task BatchInsert(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public async Task BatchUpdate(IEnumerable<T> entities)
        {
            _context.Set<T>().UpdateRange(entities);
            await _context.SaveChangesAsync();
        }

        public async Task<T> Delete(T entity)
        {
            var rm = _context.Set<T>().Remove(entity).Entity;
            await _context.SaveChangesAsync();
            return rm;
        }
        public void BatchDelete(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public int Count()
        {
            return _context.Set<T>().Count();
        }

        public EntityEntry GetEntry(T entry)
        {
            return _context.Entry(entry);
        }
    }
}
