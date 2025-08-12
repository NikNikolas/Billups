using Game.Domain.Data.Abstractions.Entities.GameRpsls;
using Game.Domain.DTO.GameRpsls.InternalModels;
using Game.Domain.DTO.GameRpsls.Requests;
using Game.Infrastructure.Utilities.Enums.Rpsls;
using Game.Infrastructure.Utilities.ErrorHandling;
using Game.Infrastructure.Utilities.ErrorHandling.ConcreteErrors.GameRpsls;
using Game.Service.Abstractions.Validators;

namespace Game.Service.Validators
{
    /// <summary>
    /// Class for validating GameRpsls data
    /// </summary>
    internal class GameRpslsValidator : IGameRpslsValidator
    {
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
                return Result.Failure(PlayGameErrors.PlayGameNullRequest());
            }

            if (!Enum.IsDefined(typeof(GameRpslsChoice), request.Player))
            {
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
