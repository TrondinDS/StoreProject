using Microsoft.EntityFrameworkCore;
using StoreProject.DB.Context;
using StoreProject.DB.Models;
using StoreProject.Repository.Generic;
using StoreProject.Repository.Interfaces;

namespace StoreProject.Repository
{
    public class OrderRepository : GenericRepository<Order, int>, IOrderRepository
    {
        public OrderRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Order>> GetAllOrdersByIdUserAsync(int id, DateTime startDate, DateTime endDate)
        {
            return await _context.Orders
                                 .AsNoTracking()
                                 .Where(o => o.UserId == id && o.DateCreate >= startDate && o.DateCreate <= endDate)
                                 .OrderBy(o => o.DateCreate)
                                 .ToListAsync();
        }

        public async Task<Order> GetOrderAsync(int Id)
        {
            return await _context.Orders
                                 .AsNoTracking()
                                 .Include(x => x.OrderItems)
                                 .ThenInclude(x => x.OrderProductInformation)
                                 .FirstOrDefaultAsync(x => x.Id == Id);
        }
    }
}
