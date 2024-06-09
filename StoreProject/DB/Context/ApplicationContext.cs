using Microsoft.EntityFrameworkCore;
using StoreProject.DB.Models;

namespace StoreProject.DB.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions dbContext) : base (dbContext)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> users { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderItem> ordersItem { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<ProductType> productsType { get; set; }
        public DbSet<ProductInformation> productInformation { get; set; }

    }
}
