using Microsoft.EntityFrameworkCore;
using StoreProject.DB.Interceptors;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(new InterceptorOverrideDelete());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasQueryFilter(x => x.IsDeleted == false);
            modelBuilder.Entity<Order>().HasQueryFilter(x => x.IsDeleted == false);
            modelBuilder.Entity<OrderItem>().HasQueryFilter(x => x.IsDeleted == false);
            modelBuilder.Entity<ProductType>().HasQueryFilter(x => x.IsDeleted == false);
            modelBuilder.Entity<Product>().HasQueryFilter(x => x.IsDeleted == false);
            modelBuilder.Entity<ProductInformation>().HasQueryFilter(x => x.IsDeleted == false);
        }
    }
}
