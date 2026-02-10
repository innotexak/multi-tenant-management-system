using System.Net;
using System.Text.Json;

namespace TenantPM.API.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(
            RequestDelegate next,
            ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred");

                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode statusCode;
            string message;

            switch (exception)
            {
                case KeyNotFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    message = "Data not found";
                    break;

                case UnauthorizedAccessException:
                    statusCode = HttpStatusCode.Unauthorized;
                    message = "You are not authorized to perform this action";
                    break;

                case ArgumentException:
                    statusCode = HttpStatusCode.BadRequest;
                    message = "Invalid request parameters";
                    break;

                case InvalidOperationException:
                    statusCode = HttpStatusCode.BadRequest;
                    message = "Invalid operation";
                    break;

                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    message = "An unexpected error occurred";
                    break;
            }

            var response = new
            {
                success = false,
                status = (int)statusCode,
                message
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            return context.Response.WriteAsync(
                JsonSerializer.Serialize(response)
            );
        }

    }
}
