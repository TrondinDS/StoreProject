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

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrdersItem { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductsType { get; set; }
        public DbSet<OrderProductInformation> ProductInformation { get; set; }

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
            modelBuilder.Entity<OrderProductInformation>().HasQueryFilter(x => x.IsDeleted == false);
        }
    }
}
