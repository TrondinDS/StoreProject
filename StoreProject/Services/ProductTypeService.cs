using StoreProject.DB.Models;
using StoreProject.Repository.Interfaces;
using StoreProject.Services.Interfaces;

namespace StoreProject.Services
{
    public class ProductTypeService : IProductTypeService
    {
        protected IProductTypeRepository productTypeRepository;

        public async Task AddAsync(ProductType productType)
        {
            await productTypeRepository.AddAsync(productType);
            await productTypeRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var productTupe = await productTypeRepository.GetByIdAsync(id);

            if (productTupe != null)
            {
                productTypeRepository.Delete(productTupe);
                await productTypeRepository.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ProductType>> GetAllAsync()
        {
            return await productTypeRepository.GetAllAsync();
        }

        public async Task<ProductType> GetByIdAsync(int id)
        {
            return await productTypeRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(ProductType productType)
        {
            productTypeRepository.Update(productType);
            await productTypeRepository.SaveChangesAsync();
        }
    }
}
