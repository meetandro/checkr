using Checkr.Exceptions;

namespace Checkr.Middleware
{
    public class ExceptionHandlingMiddleware(
        RequestDelegate next,
        ILogger<ExceptionHandlingMiddleware> logger)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger = logger;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogError(ex, "Entity not found");

                context.Response.StatusCode = StatusCodes.Status404NotFound;

                await context.Response.WriteAsync("Entity not found");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred");

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                await context.Response.WriteAsync("An unexpected error occurred");
            }
        }
    }
}
