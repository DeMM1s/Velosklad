using MediatR;
using Velosklad.Core.Responses;

namespace Velosklad.Core.Requests
{
    public record CreateProductRequest(string Name, decimal Price, int Amount) : IRequest<CreateProductResponse>;
}
