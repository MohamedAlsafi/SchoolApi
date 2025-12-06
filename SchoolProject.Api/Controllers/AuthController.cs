using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Application.Features.Authentication.Command.Model;
using SchoolProject.Application.Features.Users.Command.Model;

namespace SchoolProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : AppControllerBase
    {

        public AuthController(IMediator mediator) : base(mediator) { }


        [HttpPost("Register")]
        public async Task<IActionResult> Register(AddUserCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(  LoginCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
    }
}
