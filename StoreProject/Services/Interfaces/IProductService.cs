using StoreProject.DB.Models;

namespace StoreProject.Services.Interfaces
{
    public interface IProductService
    {
        Task AddAsync(Product product);
        Task DeleteAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetFilteredProductsAsync(int? productTypeId, bool? isAvailable, bool? isAscending);
        Task UpdateAsync(Product product);
    }
}
