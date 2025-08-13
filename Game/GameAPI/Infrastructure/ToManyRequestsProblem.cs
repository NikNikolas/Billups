using Microsoft.AspNetCore.Mvc;

namespace GameAPI.Infrastructure
{
    public class ToManyRequestsProblem : ProblemDetails
    {
        public ToManyRequestsProblem()
        {
            Status = StatusCodes.Status429TooManyRequests;
            Title = "TooManyRequests";
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5";
        }
    }
}
