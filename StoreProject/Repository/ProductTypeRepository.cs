using StoreProject.DB.Context;
using StoreProject.DB.Models;
using StoreProject.Repository.Generic;
using StoreProject.Repository.Interfaces;

namespace StoreProject.Repository
{
    public class ProductTypeRepository : GenericRepository<ProductType, int>, IProductTypeRepository
    {
        public ProductTypeRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
