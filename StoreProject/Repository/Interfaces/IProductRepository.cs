using StoreProject.DB.Models;
using StoreProject.Repository.Generic;

namespace StoreProject.Repository.Interfaces
{
    public interface IProductRepository : IGenericRepository <Product, int>
    {
        public Task<IEnumerable<Product>> GetAllByIdAsync(params int[] Ids);
        public Task<IEnumerable<Product>> GetFilterProductAsync(int? productTypeId, bool? isAvailable, bool? isAscending);
        public Task<IEnumerable<Product>> GetCheckUnavailableProductsInOrderAsync(Dictionary<int,int> mapCountProductsInOder_Id_CountInOrder);
        public Task UpdateProductCount(Dictionary<int, int> mapUpdateProducts);
    }
}
