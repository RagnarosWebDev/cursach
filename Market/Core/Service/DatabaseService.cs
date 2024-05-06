using Market.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Market.Core.Service
{
    public class DatabaseService : DbContext
    {
        public DatabaseService(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        
        public DbSet<Product> Products { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
