using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using StoreProject.DB.Context;
using StoreProject.DB.Models;
using StoreProject.Repository.Generic;
using StoreProject.Repository.Interfaces;
using System.Linq;

namespace StoreProject.Repository
{
    public class ProductRepository : GenericRepository<Product, int>, IProductRepository
    {
        public ProductRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetAllByIdAsync(params int[] Ids)
        {
            return await _context.Products.AsNoTracking().Where(x => Ids.Contains(x.Id)).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetCheckUnavailableProductsInOrderAsync(Dictionary<int, int> mapCountProductsInOder_Id_CountInOrder)
        {
            var productIds = mapCountProductsInOder_Id_CountInOrder.Keys.ToList();

            var productsInOrders = await _context.Products.AsNoTracking()
                                                   .Where(x => productIds.Contains(x.Id))
                                                   .ToListAsync();

            var productsInOrdersUnavailable = productsInOrders.Where(x => x.Count < mapCountProductsInOder_Id_CountInOrder[x.Id]).ToList();
            return productsInOrdersUnavailable;
        }

        public async Task UpdateProductCount(Dictionary<int, int> mapUpdateProducts)
        {
            var keyProductsUpdate = mapUpdateProducts.Keys.ToList();

            var productInOrderForUpdate = await _context.Products.Where(x => keyProductsUpdate.Contains(x.Id)).ToListAsync();

            foreach (var product in productInOrderForUpdate)
            { 
                product.Count -= mapUpdateProducts[product.Id];
            }
            _context.Products.UpdateRange(productInOrderForUpdate);
        }

        public async Task<IEnumerable<Product>> GetFilterProductAsync(int? productTypeIds, bool? isAvailable, bool? isAscending)
        {
            var query = _context.Products.AsQueryable();

            if (productTypeIds.HasValue)
            {
                query = query.Where(p => p.ProductTypeId == productTypeIds.Value);
            }

            if (isAvailable.HasValue)
            {
                query = query.Where(p => isAvailable.Value ? p.Count > 0 : p.Count < 0);
            }

            if (isAscending.HasValue)   
            {
                query = isAvailable.Value ? query.OrderBy(p => p.Price) : query.OrderByDescending(p => p.Price);
            }

            return await query.AsNoTracking().ToListAsync();
        }
    }
}
