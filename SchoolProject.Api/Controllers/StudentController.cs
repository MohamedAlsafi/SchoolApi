using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Application.Features.Students.Queries.Models;
using SchoolProject.Core.Features.Students.Queries.Models;

namespace SchoolProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator )
        {
            _mediator = mediator;
        }

        [HttpGet("/ Student/List")]
        public async Task<IActionResult> GetStudentList()
        {
            var response = await _mediator.Send(new GetStudentListQuery());
            return Ok(response);
        }
        [HttpGet("/student/{id}")]

        public async Task<IActionResult> GetStudentById(int id) 
        {
            var response = await _mediator.Send(new GetStudentByIdQuery(id));
            return Ok(response);
        
        }
    }
}
