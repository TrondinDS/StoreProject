using StoreProject.DB.Models;
using StoreProject.Repository.Generic;

namespace StoreProject.Repository.Interfaces
{
    public interface IProduct : IGenericRepository <Product, int>
    {
        public Task<IEnumerable<Product>> GetAllByIdAsync(params int[] Ids);
        public Task<IEnumerable<Product>> GetFilterProductAsync(IEnumerable<int> productTypeIds, bool isAvailable = false, bool isAscending = true);
        public Task<IEnumerable<Product>> GetCheckProductsCountOrderAsync(Dictionary<int,int> mapCountProductsCount);
        public Task UpdateProductCount(Dictionary<int, int> mapUpdateProducts);
    }
}
