using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Shared.Helper;
using SchoolProject.Application.Features.Students.Queries.Models;
using SchoolProject.Core.Features.Students.Queries.Models;
using School.Shared;
using SchoolProject.Application.Features.Students.Commands.Models;
using Microsoft.AspNetCore.Authorization;

namespace SchoolProject.Api.Controllers
{
   // [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator )
        {
            _mediator = mediator;
        }

        [HttpGet(ApiRoutes.StudentRouting.List)]
        public async Task<IActionResult> GetStudentList()
        {
            var response = await _mediator.Send(new GetStudentListQuery());
            return Ok(response);
        }

        [Authorize]
        [HttpGet(ApiRoutes.StudentRouting.Paginated)]
        public async Task<IActionResult> GetStudentPaginated([FromQuery] GetStudentPaginatedQuery paginatedQuery)
        {
            var response = await _mediator.Send(paginatedQuery);
           
            return Ok(response);
        }
        [HttpGet(ApiRoutes.StudentRouting.GetById)]
    
        public async Task<IActionResult> GetStudentById(int Id) 
        {
            var response = await _mediator.Send(new GetStudentByIdQuery(Id));
            return Ok(response);
        
        }
        [HttpPost(ApiRoutes.StudentRouting.Create)]
        public async Task<IActionResult> CreateStudent (AddStudentCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);

        }

        [HttpPut(ApiRoutes.StudentRouting.Update)]
        public async Task<IActionResult> UpdateStudent( int Id , UpdateStudentCommand command)
        {
            if (Id != command.ID) return BadRequest("ID missmatch");
            var response = await _mediator.Send(command);
            return Ok(response);

        }
        [HttpDelete(ApiRoutes.StudentRouting.Delete)]
        public async Task<IActionResult> DeleteStudent(int Id)
        {
            var response = await _mediator.Send(new DeleteStudentCommand(Id));
            return Ok(response);

        }
    }
}
