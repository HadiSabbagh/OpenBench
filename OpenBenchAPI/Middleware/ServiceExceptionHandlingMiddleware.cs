using Microsoft.EntityFrameworkCore;

namespace OpenBenchAPI.Middleware
{
    public class ServiceExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ServiceExceptionHandlingMiddleware> _logger;

        public ServiceExceptionHandlingMiddleware(RequestDelegate next, ILogger<ServiceExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                httpContext.Response.ContentType = "application/json";
                await _next(httpContext);
            }

            catch (KeyNotFoundException e)
            {
                _logger.LogError(e, "KeyNotFoundException occured");
                httpContext.Response.StatusCode = StatusCodes.Status404NotFound;

                var errorResponse = new
                {
                    error = "Not Found",
                    message = e.Message,
                    //details = "The requested resource could not be found."
                };

                await httpContext.Response.WriteAsJsonAsync(errorResponse);
            }
            catch (DbUpdateException e)
            {
                _logger.LogError(e, "DbUpdateException  occured");
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                var errorResponse = new
                {
                    error = "Database Error",
                    message = e.Message,
                    details = "There was an error updating the database."
                };

                await httpContext.Response.WriteAsJsonAsync(errorResponse);
            }
            catch (ArgumentNullException e)
            {
                _logger.LogError(e, "ArgumentNullException occurred in request: {RequestMethod} {RequestPath}. {Message}", httpContext.Request.Method, httpContext.Request.Path, e.Message);
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

                var errorResponse = new
                {
                    error = "Bad Request",
                    message = e.Message,
                    details = "A required parameter was missing or null."
                };

                await httpContext.Response.WriteAsJsonAsync(errorResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred");
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

                var errorResponse = new
                {
                    error = "Internal Server Error",
                    message = ex.Message,
                    details = "An unexpected error occurred. Please try again later."
                };

                await httpContext.Response.WriteAsJsonAsync(errorResponse);
            }

        }
    }
}
