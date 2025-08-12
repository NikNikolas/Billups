using Microsoft.AspNetCore.Diagnostics;

namespace GameAPI.Infrastructure
{
    /// <summary>
    /// Most of the class is taken from web article https://www.milanjovanovic.tech/blog/global-error-handling-in-aspnetcore-8
    /// written by Milan Jovanovic https://www.milanjovanovic.tech/"
    /// </summary>
    internal sealed class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError(exception, $"Exception occurred: {exception.Message}");

            var problemDetails = new InternalServerErrorProblem();

            httpContext.Response.StatusCode = problemDetails.Status.Value;

            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }
}
