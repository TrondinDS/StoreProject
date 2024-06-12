
using Microsoft.EntityFrameworkCore;
using StoreProject.DB.Context;

namespace StoreProject.Repository.Generic
{
    public class GenericRepository<T, TId> : IGenericRepository<T, TId> where T : class
    {
        protected readonly ApplicationContext _context;
        protected readonly DbSet<T> dbSet;

        public GenericRepository(ApplicationContext context) 
        {
            this._context = context;
            this.dbSet = this._context.Set<T>();
        }

        public async Task AddAsync(params T[] entity)
        {
            await dbSet.AddRangeAsync(entity);
        }

        public void Delete(params T[] entity)
        {
            dbSet.RemoveRange(entity);
        }

        public void Update(params T[] entity)
        {
            dbSet.UpdateRange(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var items = await dbSet.ToListAsync();
            return items;
        }

        public async Task<T> GetByIdAsync(TId id)
        {
            var item = await dbSet.FindAsync(id);
            return item;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
