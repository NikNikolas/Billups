using Game.Domain.DTO.GameRpsls.InternalModels;
using Game.Infrastructure.Utilities.Enums.Rpsls;

namespace Game.Service.Abstractions.GameRpsls
{
    /// <summary>
    /// Interface for method definition related with RPSLS game result calculation
    /// </summary>
    public interface IGameCalculatorService
    {
        /// <summary>
        /// Calculate game result from player perspective.
        /// </summary>
        /// <param name="request">Model class of type <see cref="GameCalculationRequest"/></param>
        /// <returns>Enum value of <see cref="GameResult"/></returns>
        GameResult Calculate(GameCalculationRequest request);
    }
}
