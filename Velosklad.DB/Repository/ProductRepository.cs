using Microsoft.EntityFrameworkCore;
using Velosklad.Domain.Models;
using Velosklad.Domain.Repositories;

namespace Velosklad.DB.Repository
{
    public class ProductRepository : Repository<OrderDbContext>, IProductRepository
    {
        protected ProductRepository(IDbContextFactory<OrderDbContext> factory) : base(factory)
        {
        }

        public void Add(Product product)
        {
            Context.Products.Add(product);
        }

        public async Task<Product?> Get(int productId, CancellationToken cancellationToken)
        {
            return await Context.Products.SingleOrDefaultAsync(o => o.Id == productId, cancellationToken);
        }
    }
}
