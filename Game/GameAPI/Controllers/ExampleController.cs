using Microsoft.AspNetCore.Mvc;
using Game.Service.Abstractions;
using GameAPI.Controllers.Base;

namespace GameAPI.Controllers
{
    /// <summary>
    /// Initial Example Controller
    /// </summary>
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class ExampleController : BaseApiController<ExampleController>
    { 
        private readonly ILogger<ExampleController> _logger;

        /// <summary>
        /// Creates an instance and initialize all properties
        /// </summary>
        /// <param name="exampleService">Example Service</param>
        /// <param name="logger"></param>
        public ExampleController(ILogger<ExampleController> logger) : base(logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Check does API works
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation($"Started method from controller {nameof(ExampleController)}");
            //await _exampleService.IsServiceWorkingAsync();

            return Ok("Works!");
        }

    }
}
