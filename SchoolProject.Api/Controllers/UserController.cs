using MediatR;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Shared.Helper;
using SchoolProject.Application.Features.Users.Command.Dtos;
using SchoolProject.Application.Features.Users.Command.Model;
using SchoolProject.Application.Features.Users.Queries.Model;

namespace SchoolProject.Api.Controllers
{
   
    [ApiController]
    public class UserController : AppControllerBase
    {
        public UserController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet(ApiRoutes.UserRouting.Paginated)]
        public async Task<IActionResult> Paginated([FromQuery] GetUserPaginationQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }

        [HttpGet(ApiRoutes.UserRouting.GetByID)]
        public async Task<IActionResult> GetUserById([FromRoute] string Id )
        {
            var response = await Mediator.Send(new GetUserByIdQuery(Id));
            
            return Ok(response);
        }

        [HttpPut(ApiRoutes.UserRouting.Edit)]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] EditUserDto updateDto)
        {
            if (updateDto is null)
                return BadRequest();

            var response = await Mediator.Send(new EditUserCommand(id, updateDto));

            return Ok(response);
        }

    }
}