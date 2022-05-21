using Velosklad.Domain.Models;
using Velosklad.Domain.Shared;

namespace Velosklad.Domain.Repositories
{
    public interface IProductRepository : IRepository
    {
        void Add(Product product);

        Task<Product?> Get(int productId, CancellationToken cancellationToken);
    }
}
