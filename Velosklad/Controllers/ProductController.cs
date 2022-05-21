﻿using Microsoft.AspNetCore.Mvc;
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

        //Velosklad.ru/Product/Create
        [HttpPost]
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
    }
}
