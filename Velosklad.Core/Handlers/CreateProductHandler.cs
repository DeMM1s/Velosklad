using MediatR;
using Velosklad.Core.Requests;
using Velosklad.Core.Responses;
using Velosklad.Domain.Models;
using Velosklad.Domain.Repositories;

namespace Velosklad.Core.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductRequest>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<Unit> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var product = new Product(
                request.Name,
                request.Price,
                request.Amount);

            _productRepository.Add(product);

            var response = new CreateProductResponse(product);

            return Task.FromResult(Unit.Value);
        }
    }
}
