using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Application.Features.Users.Command.Model;

namespace SchoolProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : AppControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator) : base(mediator) { }


        [HttpPost("Register")]
        public async Task<IActionResult> Register(AddUserCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }
    }
}
