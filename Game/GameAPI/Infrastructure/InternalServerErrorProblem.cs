using Microsoft.AspNetCore.Mvc;

namespace GameAPI.Infrastructure
{
    /// <summary>
    /// Standard response for internal server error 
    /// </summary>
    public class InternalServerErrorProblem : ProblemDetails
    {
        public InternalServerErrorProblem()
        {
            Status = StatusCodes.Status500InternalServerError;
            Title = "Server Error";
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1";
        }
    }
}
