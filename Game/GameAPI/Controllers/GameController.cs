using Game.Domain.DTO.GameRpsls.Requests;
using Game.Domain.DTO.GameRpsls.Responses;
using Game.Infrastructure.Utilities.ErrorHandling.ConcreteErrors.GameRpsls;
using Game.Service.Abstractions.GameRpsls;
using GameAPI.Controllers.Base;
using GameAPI.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace GameAPI.Controllers
{
    /// <summary>
    /// Controller for Game endpoints
    /// </summary>
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class GameController : BaseApiController<GameController>
    {

        /// <summary>
        /// 
        /// </summary>
        private readonly IGameService _gameService;
        /// <summary>
        /// Logger
        /// </summary>
        private readonly ILogger<GameController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameController"/> class.
        /// </summary>
        /// <param name="gameService"></param>
        /// <param name="logger">Instance of logger</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <remarks>For use when creating a <see cref="GameController"/> by DI</remarks>
        public GameController(IGameService gameService, ILogger<GameController> logger) : base(logger)
        {
            _gameService = gameService ?? throw new ArgumentNullException(nameof(gameService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Returns collection of DTO classes <see cref="GetChoiceResponse"/>
        /// </summary>
        /// <returns>Returns <see cref="IActionResult"/></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("choices")]
        public async Task<IActionResult> GetAllChoices()
        {
            _logger.LogInformation($"Started method GetAllChoice from controller {nameof(GameController)}");

            var response = await _gameService.GetAllChoicesAsync();

            _logger.LogInformation($"Finished method GetAllChoice from controller {nameof(GameController)}");

            return Ok(response);
        }

        /// <summary>
        /// Returns one instance of DTO class <see cref="GetChoiceResponse"/>
        /// </summary>
        /// <returns>Returns <see cref="IActionResult"/></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("choice")]
        public async Task<IActionResult> GetCustomChoice()
        {
            _logger.LogInformation($"Started method GetCustomChoice from controller {nameof(GameController)}");

            var result = await _gameService.GetCustomChoiceAsync();

            if (result.IsFailure)
            {
                if (result.Error.Code == RandomNumberGeneratorErrors.CodeToManyRequests)
                {
                    return StatusCode(429, new ToManyRequestsProblem());
                }

                return StatusCode(500, new InternalServerErrorProblem());
            }

            _logger.LogInformation($"Finished method GetCustomChoice from controller {nameof(GameController)}");

            return Ok(result.Value);
        }

        /// <summary>
        /// Returns one instance of DTO class <see cref="GetChoiceResponse"/>
        /// </summary>
        /// <returns>Returns <see cref="IActionResult"/></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost("play")]
        public async Task<IActionResult> PlayGame(PlayGameRequest request)
        {
            _logger.LogInformation($"Started method PlayGame from controller {nameof(GameController)}");

            var response = await _gameService.PlayGameAsync(request);

            if (response.IsFailure)
            {
                if (response.Error.Code == PlayGameErrors.CodeInvalidValueRequest) 
                {
                    return BadRequest(response.Error.Message);
                }

                if (response.Error.Code == RandomNumberGeneratorErrors.CodeToManyRequests)
                {
                    return StatusCode(429, new ToManyRequestsProblem());
                }

                return StatusCode(500, new InternalServerErrorProblem());
            }

            _logger.LogInformation($"Finished method PlayGame from controller {nameof(GameController)}");

            return Ok(response);
        }
    }
}
