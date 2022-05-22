using MediatR;
using Velosklad.Core.Models;
using Velosklad.Domain.Models;
using Velosklad.Domain.Repositories;

namespace Velosklad.Core.Users
{
    public class CreateUser
    {
        public record Request(string Name, string Login, string Password, ICollection<Order> Orders) : IRequest<Response>;

        public record Response(UserDto User);
        public class Handler : IRequestHandler<Request, Response>
        {
            public Handler() { }
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var user = new User(request.Name,
                                    request.Login,
                                    request.Password,
                                    request.Orders);
                return new Response(new UserDto
                {
                    Name = request.Name,
                    Login = request.Login,
                    Password = request.Password,
                    Orders = request.Orders
                });
            }
        }
    }
}
