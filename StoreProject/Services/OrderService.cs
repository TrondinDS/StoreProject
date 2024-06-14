using StoreProject.DB.Models;
using StoreProject.Repository.Interfaces;
using StoreProject.Services.Interfaces;

namespace StoreProject.Services
{
    public class OrderService : IOrderService
    {
        protected readonly IOrderRepository orderRepository;
        protected readonly IOrderItemRepository orderItemRepository;
        protected readonly IOrderProductInformationRepository orderProductInformationRepository;
        protected readonly IProductRepository productRepository;

        public async Task<Order> CreateOrder(int UserId, Dictionary<int, int> orders)
        {
            //переделать
        }

        public async Task DeleteAsync(int id)
        {
            var order = await orderRepository.GetByIdAsync(id);

            if (order != null) 
            {
                orderRepository.Delete(order);
                await orderRepository.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await orderRepository.GetAllAsync();
        }

        public async Task<Order> GetFullOrder(int id)
        {
            return await orderRepository.GetOrderAsync(id);
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomerAndDateRangeAsync(int UserId, DateTime startDate, DateTime endDate)
        {
            return await orderRepository.GetAllOrdersByIdUserAsync(UserId, startDate, endDate);
        }
    }
}
