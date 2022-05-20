using Velosklad.Domain.Models;

namespace Velosklad.Domain.Repositories
{
    public interface IProductRepository
    {
        void Add(Product product);

        Task<Product?> Get(int productId, CancellationToken cancellationToken);
    }
}
