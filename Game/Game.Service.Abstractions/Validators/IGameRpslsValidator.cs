using Game.Domain.DTO.GameRpsls.InternalModels;
using Game.Domain.DTO.GameRpsls.Requests;

namespace Game.Service.Abstractions.Validators
{
    /// <summary>
    /// Interface for method definition for validating GameRpsls data
    /// </summary>
    public interface IGameRpslsValidator
    {
        /// <summary>
        /// Checks is request valid
        /// </summary>
        /// <param name="request">DTO request Class <see cref="PlayGameRequest"/> that should be validated</param>
        /// <returns></returns>
        void ValidatePlayGameRequest(PlayGameRequest request);
        /// <summary>
        /// Checks is request valid
        /// </summary>
        /// <param name="request">DTO model Class <see cref="GameCalculationRequest"/> that should be validated</param>
        void ValidateGameCalculatorRequest(GameCalculationRequest request);
    }
}
