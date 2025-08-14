using Game.Domain.DTO.GameRpsls.Requests;
using Game.Domain.DTO.GameRpsls.Responses;
using Game.Infrastructure.Utilities.ErrorHandling;

namespace Game.Service.Abstractions.GameRpsls
{
    /// <summary>
    /// Interface for method definition related with RPSLS Game
    /// </summary>
    public interface IGameService
    {
        /// <summary>
        /// Returns collection of Choices asynchronously
        /// </summary>
        /// <returns>IEnumerable of DTO class <see cref="GetChoiceResponse"/></returns>
        Task<IEnumerable<GetChoiceResponse>> GetAllChoicesAsync();
        /// <summary>
        /// Returns randomly chosen Choice asynchronously
        /// </summary>
        /// <returns>DTO class <see cref="GetChoiceResponse"/></returns>
        Task<Result<GetChoiceResponse>> GetCustomChoiceAsync();
        /// <summary>
        /// Calculate result of submitted users choice with random computer choice and return game result asynchronously
        /// </summary>
        /// <param name="request">DTO class <see cref="PlayGameRequest"/></param>
        /// <returns>DTO class <see cref="PlayGameRequest"/></returns>
        Task<Result<PlayGameResponse>> PlayGameAsync(PlayGameRequest request);
    }
}
