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
                //log
                _logger.LogError(ex, "[{Middleware}] {ExceptionType}: {Message}",
                    nameof(ExceptionMiddleware), ex.GetType().Name, ex.Message);
                //2 
                httpContext.Response.StatusCode = ex switch
                {
                    InvalidOperationException or ArgumentException => (int)HttpStatusCode.BadRequest,
                    KeyNotFoundException => (int)HttpStatusCode.NotFound,
                    UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,
                    _ => (int)HttpStatusCode.InternalServerError
                };

                httpContext.Response.ContentType = "application/json";

               
                var response = _env.IsDevelopment()
                    ? new ApiExceptionResponse(httpContext.Response.StatusCode, $"{ex.GetType().Name}: {ex.Message}", ex.StackTrace)
                    : new ApiExceptionResponse(httpContext.Response.StatusCode, "An unexpected error occurred. Please try again later.");

                var jsonOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response, jsonOptions));
            }
        }
    }
}
