using Microsoft.EntityFrameworkCore;
using Velosklad.Domain.Models;

namespace Velosklad.DB
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {

        }

        public DbSet<Order> Orders => Set<Order>();

        public DbSet<Product> Products => Set<Product>();
    }


}
