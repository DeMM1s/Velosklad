using Microsoft.EntityFrameworkCore;
using Velosklad.Domain.Models;

namespace Velosklad.DB.Repository
{
    public class OrderRepository : Repository<OrderDbContext>
    {
        protected OrderRepository(IDbContextFactory<OrderDbContext> factory) : base(factory)
        {
        }

        public async Task<Order?> Get(int orderId, CancellationToken cancellationToken)
        {
            return await Context.Orders.SingleOrDefaultAsync(o => o.Id == orderId, cancellationToken);
        }
    }
}
