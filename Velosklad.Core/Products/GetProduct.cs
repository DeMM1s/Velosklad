using MediatR;
using Velosklad.Core.Models;
using Velosklad.Infrastructure;
using Velosklad.Domain.Repositories;

namespace Velosklad.Core.Products
{
    public class GetProduct
    {
        public record Request(int Id) : IRequest<Response>;

        public record Response(ProductDto? Product, string? Error = null);

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IProductRepository _repository;

            public Handler(
                IProductRepository productRepository)
            {
                _repository = productRepository;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var product = await _repository.Get(request.Id, cancellationToken);

                if (product == null)
                {
                    return new Response(
                        null,
                        Constants.ErrorMessage.Product.ProductNotFoundError);
                }

                return new Response(new ProductDto
                {
                    Name = product.Name,
                    Price = product.Price,
                    Amount = product.Amount
                });
            }
        }
    }
}
