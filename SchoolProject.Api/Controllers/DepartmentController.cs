using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Shared.Helper;
using SchoolProject.Application.Features.Departement.Queries.Models;

namespace SchoolProject.Api.Controllers
{
   // [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentController(IMediator mediator )
        {
            _mediator = mediator;
        }

        //[HttpGet(ApiRoutes.DepartmentRouting.List)]
        //public async Task<IActionResult> GetDepartmentList()
        //{
        //    var response = await _mediator.Send(new GetDepartmentListQuery());
        //    return Ok(response);
        //}

        //[HttpGet(ApiRoutes.DepartmentRouting.Paginated)]
        //public async Task<IActionResult> GetDepartmentPaginated([FromQuery] GetDepartmentPaginatedQuery paginatedQuery)
        //{
        //    var response = await _mediator.Send(paginatedQuery);
           
        //    return Ok(response);
        //}

        [HttpGet(ApiRoutes.DepartmentRouting.GetById)]

        public async Task<IActionResult> GetDepartmentById(int Id) 
        {
            var response = await _mediator.Send(new GetDepartmentByIDQuery(Id));
            return Ok(response);
        
        }
        //[HttpPost(ApiRoutes.DepartmentRouting.Create)]
        //public async Task<IActionResult> CreateDepartment (AddDepartmentCommand command)
        //{
        //    var response = await _mediator.Send(command);
        //    return Ok(response);

        //}

        //[HttpPut(ApiRoutes.DepartmentRouting.Update)]
        //public async Task<IActionResult> UpdateDepartment( int Id , UpdateDepartmentCommand command)
        //{
        //    if (Id != command.ID) return BadRequest("ID missmatch");
        //    var response = await _mediator.Send(command);
        //    return Ok(response);

        //}
        //[HttpDelete(ApiRoutes.DepartmentRouting.Delete)]
        //public async Task<IActionResult> DeleteDepartment(int Id)
        //{
        //    var response = await _mediator.Send(new DeleteDepartmentCommand(Id));
        //    return Ok(response);

        //}
    }
}
