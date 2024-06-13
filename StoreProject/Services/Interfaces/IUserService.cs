using StoreProject.DB.Models;

namespace StoreProject.Services.Interfaces
{
    public interface IUserService
    {
        Task AddAsync(User customer);
        Task DeleteAsync(int id);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task UpdateAsync(User customer);
    }
}
