using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Shared.Helper;
using SchoolProject.Application.Features.Students.Queries.Models;
using SchoolProject.Core.Features.Students.Queries.Models;
using School.Shared;

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
        [HttpGet(ApiRoutes.StudentRouting.GetById)]

        public async Task<IActionResult> GetStudentById(int id) 
        {
            var response = await _mediator.Send(new GetStudentByIdQuery(id));
            return Ok(response);
        
        }
    }
}
