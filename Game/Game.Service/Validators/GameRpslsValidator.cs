using Game.Domain.Data.Abstractions.Entities.GameRpsls;
using Game.Domain.DTO.GameRpsls.InternalModels;
using Game.Domain.DTO.GameRpsls.Requests;
using Game.Infrastructure.Utilities.Enums.Rpsls;
using Game.Infrastructure.Utilities.ErrorHandling;
using Game.Infrastructure.Utilities.ErrorHandling.ConcreteErrors.GameRpsls;
using Game.Infrastructure.Utilities.Helpers;
using Game.Service.Abstractions.Validators;
using Microsoft.Extensions.Logging;

namespace Game.Service.Validators
{
    /// <summary>
    /// Class for validating GameRpsls data
    /// </summary>
    public class GameRpslsValidator : IGameRpslsValidator
    {
        /// <summary>
        /// Logger  
        /// </summary>
        private readonly ILogger<GameRpslsValidator> _logger;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public GameRpslsValidator(ILogger<GameRpslsValidator> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Validate is request different from null and is submitted player choice correct
        /// </summary>
        /// <param name="request"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public Result ValidatePlayGameRequest(PlayGameRequest request)
        {
            if (request == null)
            {
                _logger.LogError(LogMessageBuilder.GetNullValidationErrorMessage($"{nameof(PlayGameRequest)}"));
                return Result.Failure(PlayGameErrors.PlayGameNullRequest());
            }

            if (!Enum.IsDefined(typeof(GameRpslsChoice), request.Player))
            {
                _logger.LogError(LogMessageBuilder.GetValidationErrorMessage($"Value of {nameof(request.Player)} is out of range"));
                return Result.Failure(PlayGameErrors.PlayGameInvalidValueRequest());
            }

            return Result.Success();
        }

        public void ValidateGameCalculatorRequest(GameCalculationRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (!Enum.IsDefined(typeof(GameRpslsChoice), request.PlayerChoice))
            {
                throw new ArgumentException($"Invalid value of parameter {nameof(request.PlayerChoice)}.");
            }

            if (!Enum.IsDefined(typeof(GameRpslsChoice), request.ComputerChoice))
            {
                throw new ArgumentException($"Invalid value of parameter {nameof(request.ComputerChoice)}.");
            }
        }

        public void ValidateGameResultHistory(GameResultHistory newRecord)
        {
            if (newRecord == null)
            {
                throw new ArgumentNullException(nameof(newRecord));
            }
        }
    }
}
