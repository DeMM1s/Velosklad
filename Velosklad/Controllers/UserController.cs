using Microsoft.AspNetCore.Mvc;
using Velosklad.Core.Users;
using Velosklad.Core.Models;
using MediatR;

namespace Velosklad.Controllers
{
    [Route("/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("/createUser")]
        public async Task<UserDto> Create(CreateUser.Request request, CancellationToken cancellationToken)
        {
            var createUserResponse = await _mediator.Send(request, cancellationToken);

            return new UserDto
            {
                Name = createUserResponse.User.Name,
                Login = createUserResponse.User.Login,
                Password = createUserResponse.User.Password,
                Orders = createUserResponse.User.Orders
            };
        }
    }
}
