using StoreProject.DB.Context;
using StoreProject.DB.Models;
using StoreProject.Repository.Generic;
using StoreProject.Repository.Interfaces;

namespace StoreProject.Repository
{
    public class OrderInformationRepository : GenericRepository<OrderInformation, int>, IOrderInformationRepository
    {
        public OrderInformationRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
