using Microsoft.AspNetCore.Mvc;

namespace GameAPI.Controllers.Base
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApiController<TController> : Controller where TController : Controller
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseApiController{TContorller}" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public BaseApiController(ILogger<TController> logger)
        {
            Logger = logger;
        }

        /// <summary>
        /// Gets the logger.
        /// </summary>
        /// <value>
        /// The logger.
        /// </value>
        public ILogger<TController> Logger { get; }
    }
}
