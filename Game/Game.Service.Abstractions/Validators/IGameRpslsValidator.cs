using Game.Domain.Data.Abstractions.Entities.GameRpsls;
using Game.Domain.DTO.GameRpsls.InternalModels;
using Game.Domain.DTO.GameRpsls.Requests;
using Game.Infrastructure.Utilities.ErrorHandling;

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
        Result ValidatePlayGameRequest(PlayGameRequest request);
        /// <summary>
        /// Checks is request valid
        /// </summary>
        /// <param name="request">DTO model Class <see cref="GameCalculationRequest"/> that should be validated</param>
        void ValidateGameCalculatorRequest(GameCalculationRequest request);
        /// <summary>
        /// Validates entity of type <see cref="GameResultHistory"/> before saving to db
        /// </summary>
        /// <param name="newRecord"></param>
        void ValidateGameResultHistory(GameResultHistory newRecord);
    }
}
