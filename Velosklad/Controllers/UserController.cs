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
        public async Task<UserDto> Create(CreateUser.RequestCreateUser request, CancellationToken cancellationToken)
        {
            var createUserResponse = await _mediator.Send(request, cancellationToken);

            return createUserResponse.User;
        }
    }
}
