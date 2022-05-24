using MediatR;
using Velosklad.Core.Models;
using Velosklad.Domain.Models;
using Velosklad.Domain.Repositories;

namespace Velosklad.Core.Users
{
    public class CreateUser
    {
        public record RequestCreateUser(string Name, string Login, string Password) : IRequest<ResponseCreateUser>;

        public record ResponseCreateUser(UserDto User);
        public class Handler : IRequestHandler<RequestCreateUser, ResponseCreateUser>
        {
            public Handler() { }
            public async Task<ResponseCreateUser> Handle(RequestCreateUser request, CancellationToken cancellationToken)
            {
                var user = new User(request.Name,
                                    request.Login,
                                    request.Password);
                return new ResponseCreateUser(new UserDto
                {
                    Name = user.Name,
                    Login = user.Login,
                    Password = user.Password,
                });
            }
        }
    }
}
