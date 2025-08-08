using Microsoft.AspNetCore.Mvc;

namespace GameAPI.Controllers.Base
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public abstract class BaseApiController<TContorller> : Controller where TContorller : Controller
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseApiController{TContorller}" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public BaseApiController(ILogger<TContorller> logger)
        {
            Logger = logger;
        }

        /// <summary>
        /// Gets the logger.
        /// </summary>
        /// <value>
        /// The logger.
        /// </value>
        public ILogger<TContorller> Logger { get; }
    }
}
