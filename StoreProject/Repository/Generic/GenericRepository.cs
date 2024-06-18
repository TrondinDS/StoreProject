
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

        public void Update(params T[] entities)
        {
            foreach (var entity in entities)
            {
                var key = GetEntityKey(entity);
                var existingEntity = dbSet.Find(key);

                if (existingEntity != null)
                {
                    // Обновляем значения текущей сущности
                    _context.Entry(existingEntity).CurrentValues.SetValues(entity);
                }
                else
                {
                    // Добавляем новую сущность
                    dbSet.Update(entity);
                }
            }
        }

        private object GetEntityKey(T entity)
        {
            var keyName = _context.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties.Select(x => x.Name).Single();
            return entity.GetType().GetProperty(keyName).GetValue(entity, null);
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
