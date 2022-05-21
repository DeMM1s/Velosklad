using MediatR;
using Velosklad.Core.Models;
using Velosklad.Domain.Models;
using Velosklad.Domain.Repositories;

namespace Velosklad.Core.Products
{
    public class CreateProduct
    {
        public record Request(string Name, decimal Price, int Amount) : IRequest<Response>;

        public record Response(ProductDto Product);

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IProductRepository _productRepository;

            public Handler(IProductRepository productRepository)
            {
                _productRepository = productRepository;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var product = new Product(
                    request.Name,
                    request.Price,
                    request.Amount);

                _productRepository.Add(product);
                await _productRepository.Commit(cancellationToken);

                return new Response(new Models.ProductDto
                {
                    Name = request.Name,
                    Price = request.Price,
                    Amount = request.Amount
                });
            }
        }
    }

    
}
