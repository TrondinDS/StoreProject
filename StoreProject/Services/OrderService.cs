using StoreProject.DB.Models;
using StoreProject.Repository.Interfaces;
using StoreProject.Services.Interfaces;

namespace StoreProject.Services
{
    public class OrderService : IOrderService
    {
        protected readonly IOrderRepository orderRepository;
        protected readonly IOrderItemRepository orderItemRepository;
        protected readonly IOrderInformationRepository orderProductInformationRepository;
        protected readonly IProductRepository productRepository;

        public OrderService(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository, IOrderInformationRepository orderProductInformationRepository, IProductRepository productRepository)
        {
            this.orderRepository = orderRepository;
            this.orderItemRepository = orderItemRepository;
            this.orderProductInformationRepository = orderProductInformationRepository;
            this.productRepository = productRepository;
        }

        public async Task<Order> CreateOrder(int UserId, Dictionary<int, int> orders)
        {
            var productInOrderUnvaliable = await productRepository.GetCheckUnavailableProductsInOrderAsync(orders);

            if (productInOrderUnvaliable.Any()) return null;

            var requestedProducts = await productRepository.GetAllByIdAsync(orders.Select(x => x.Key).ToArray());
            var requestedProductsDict = requestedProducts.ToDictionary(x => x.Id, x => x);

            var orderItems = new List<OrderItem>();
            var orderProductInformation = new List<OrderInformation>();

            foreach (var orderItem in orders)
            {
                var newOrderItem = new OrderItem()
                {
                    ProductId = orderItem.Key                    
                };

                var newOrderInformation = new OrderInformation()
                {
                    OrderItem = newOrderItem,
                    CountProduct = orderItem.Value,
                    Price = requestedProductsDict[orderItem.Key].Price
                };

                orderItems.Add(newOrderItem);
                orderProductInformation.Add(newOrderInformation);
            }
            var newOrder = new Order()
            {
                DateCreate = DateTime.UtcNow,
                UserId = UserId,
                OrderItems = orderItems
            };

            await productRepository.UpdateProductCount(orders);
            await orderProductInformationRepository.AddAsync(orderProductInformation.ToArray());
            await orderItemRepository.AddAsync(orderItems.ToArray());
            await orderRepository.AddAsync(newOrder);
            await orderItemRepository.SaveChangesAsync();
            return newOrder;
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
