namespace StoreProject.Repository.Generic
{
    public interface IGenericRepository <T,TId> where T : class
    {
        Task AddAsync(params T[] entity);
        void Delete(params T[] entity);
        void Update(params T[] entity);
        Task<T> GetByIdAsync(TId id);
        Task<IEnumerable<T>> GetAllAsync();
        Task SaveChangesAsync();
    }
}
