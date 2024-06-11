using StoreProject.DB.Models;
using StoreProject.Repository.Generic;

namespace StoreProject.Repository.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order,int>
    {
        public Task<IEnumerable<Order>> GetAllOrdersByIdUserAsync(int id, DateTime startDate, DateTime endDate);
        public Task<Order> GetOrderAsync(int Id);
    }
}
