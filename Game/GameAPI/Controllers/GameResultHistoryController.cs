using Game.Domain.DTO.GameRpsls.Requests;
using Game.Domain.DTO.GameRpsls.Responses;
using Game.Infrastructure.Utilities.Helpers;
using Game.Service.Abstractions.GameRpsls;
using GameAPI.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace GameAPI.Controllers
{
    /// <summary>
    /// Controller for Game endpoints
    /// </summary>
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class GameResultHistoryController : BaseApiController<GameResultHistoryController>
    {

        /// <summary>
        /// Property to implementation of interface <see cref="IGameResultHistoryService"/>
        /// </summary>
        private readonly IGameResultHistoryService _gameResultHistoryService;
        /// <summary>
        /// Logger
        /// </summary>
        private readonly ILogger<GameResultHistoryController> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="gameResultHistoryService">Implementation of interface <see cref="IGameResultHistoryService"/></param>
        /// <param name="logger">Implementation of Logger</param>
        /// <exception cref="ArgumentNullException"></exception>
        public GameResultHistoryController(IGameResultHistoryService gameResultHistoryService, ILogger<GameResultHistoryController> logger) : base(logger)
        {
            _gameResultHistoryService = gameResultHistoryService ?? throw new ArgumentNullException(nameof(gameResultHistoryService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Returns collection of history records of played games 
        /// </summary>
        /// <returns>Returns <see cref="IActionResult"/></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllHistoryRequest request)
        {
            _logger.LogInformation(LogMessageBuilder.GetStartedMethodMessage());

            var response = await _gameResultHistoryService.GetAllAsync(request);

            _logger.LogInformation(LogMessageBuilder.GetFinishedMethodMessage());

            return Ok(response);
        }
    }
}
