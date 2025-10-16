using FluentValidation;
using SchoolProject.Api.Error_Handling;
using System.Net;
using System.Text.Json;

namespace SchoolProject.Api.Middlewares
{
   
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IWebHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IWebHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "[{Middleware}] {ExceptionType}: {Message}",
                    nameof(ExceptionMiddleware),
                    ex.GetType().Name,
                    ex.Message);

                httpContext.Response.ContentType = "application/json";

                var jsonOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                // Validation errors
                if (ex is ValidationException validationEx)
                {
                    httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    var validationResponse = new ApiValidationError
                    {
                        Message = "Validation Failed",
                        Errors = validationEx.Errors.Select(e => $"{e.PropertyName}: {e.ErrorMessage}")
                    };

                    await httpContext.Response.WriteAsync(JsonSerializer.Serialize(validationResponse, jsonOptions));
                    return;
                }

                ApiResponse response;

                // Other
                switch (ex)
                {
                    case KeyNotFoundException:
                        httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        response = new ApiExceptionResponse(httpContext.Response.StatusCode, ex.Message);
                        break;

                    case UnauthorizedAccessException:
                        httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        response = new ApiExceptionResponse(httpContext.Response.StatusCode, ex.Message);
                        break;

                    case InvalidOperationException or ArgumentException:
                        httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        response = new ApiExceptionResponse(httpContext.Response.StatusCode, ex.Message);
                        break;

                    default:
                        httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        response = _env.IsDevelopment()
                            ? new ApiExceptionResponse(
                                httpContext.Response.StatusCode,
                                $"{ex.GetType().Name}: {ex.Message}",
                                ex.StackTrace)
                            : new ApiExceptionResponse(
                                httpContext.Response.StatusCode,
                                "An unexpected error occurred. Please try again later.");
                        break;
                }

                await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response, jsonOptions));
            }
        }
    }

}
