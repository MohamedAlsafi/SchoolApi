using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Application.Bases;
using System.Net;

namespace SchoolProject.Api.Controllers
{
    [ApiController]
    public abstract class AppControllerBase : ControllerBase
    {
        protected readonly IMediator Mediator;

        protected AppControllerBase(IMediator mediator)
        {
            Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        protected ActionResult NewResult<T>(Response<T> response)
        {
            return response.StatusCode switch
            {
                HttpStatusCode.OK => Ok(response),
                HttpStatusCode.Created => Created(string.Empty, response),
                HttpStatusCode.Unauthorized => Unauthorized(response),
                HttpStatusCode.BadRequest => BadRequest(response),
                HttpStatusCode.NotFound => NotFound(response),
                HttpStatusCode.Accepted => Accepted(string.Empty, response),
                HttpStatusCode.UnprocessableEntity => UnprocessableEntity(response),
                _ => StatusCode((int)response.StatusCode, response)
            };
        }
    }

}
