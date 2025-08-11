using Game.Domain.DTO.GameRpsls.InternalModels;
using Game.Domain.DTO.GameRpsls.Requests;
using Game.Infrastructure.Utilities.Enums.Rpsls;
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
        public void ValidatePlayGameRequest(PlayGameRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (!Enum.IsDefined(typeof(Choice), request.Player))
            {
                throw new ArgumentException($"Invalid value of parameter {nameof(request.Player)}.");
            }
        }

        public void ValidateGameCalculatorRequest(GameCalculationRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (!Enum.IsDefined(typeof(Choice), request.PlayerChoice))
            {
                throw new ArgumentException($"Invalid value of parameter {nameof(request.PlayerChoice)}.");
            }

            if (!Enum.IsDefined(typeof(Choice), request.ComputerChoice))
            {
                throw new ArgumentException($"Invalid value of parameter {nameof(request.ComputerChoice)}.");
            }
        }
    }
}
