using Microsoft.AspNetCore.Mvc;
using Velosklad.Core.Products;
using Velosklad.Core.Models;
using MediatR;

namespace Velosklad.Controllers
{
    [Route("/product")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("/create")]
        public async Task<ProductDto> Create(CreateProduct.Request request, CancellationToken cancellationToken)
        {
            var createProductResponse = await _mediator.Send(request, cancellationToken);

            return new ProductDto
            {
                Name = createProductResponse.Product.Name,
                Price = createProductResponse.Product.Price,
                Amount = createProductResponse.Product.Amount
            };
        }

        [HttpGet("/get{productId}")]
        public async Task<IActionResult> Get(int productId, CancellationToken cancellationToken)
        {
            var request = new GetProduct.Request(productId);

            var getProductResponse = await _mediator.Send(request, cancellationToken);

            return Ok(getProductResponse);
        }
    }
}
