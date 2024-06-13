﻿using StoreProject.DB.Models;
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
            var unavailableProduct = await productRepository.GetCheckUnavailableProductsInOrderAsync(orders);

            if (unavailableProduct.Any()) return null;

            var requestedProducts = await productRepository.GetAllByIdAsync(orders.Select(x => x.Key).ToArray());
            var requestedProductsDict = requestedProducts.ToDictionary(x => x.Id, x => x);

            var orderItems = new List<OrderItem>();
            var orderProductInformation = new List<OrderProductInformation>();

            foreach (var orderItem in orders)
            {
                var newOrderItem = new OrderItem()
                {
                    
                };

                var newOrderProductInformation = new OrderProductInformation()
                {
                    ProductId = orderItem.Key,
                    OrderItem = newOrderItem,
                    CountProduct = orderItem.Value                    
                };

                orderItems.Add(newOrderItem);
                orderProductInformation.Add(newOrderProductInformation);
            }
            var newOrder = new Order()
            {
                DateCreate = DateTime.Now,
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