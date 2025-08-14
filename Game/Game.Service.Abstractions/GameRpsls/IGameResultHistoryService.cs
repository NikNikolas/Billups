using Game.Domain.Data.Abstractions.Entities.GameRpsls;
using Game.Domain.Data.Abstractions.Model;
using Game.Domain.DTO.GameRpsls.Requests;
using Game.Domain.DTO.GameRpsls.Responses;

namespace Game.Service.Abstractions.GameRpsls
{
    /// <summary>
    /// Interface for method definition related with operation with entity <see cref="GameResultHistory"/>
    /// </summary>
    public interface IGameResultHistoryService
    {
        /// <summary>
        /// Saves new record of played Game Result
        /// </summary>
        /// <param name="newRecord">Instance of entity type <see cref="GameResultHistory"/> that should be saved</param>
        /// <returns></returns>
        Task SaveAsync(GameResultHistory newRecord);

        /// <summary>
        /// Return collection of played game results
        /// </summary>
        /// <param name="filterRequest">Instance of model class <see cref="GetAllHistoryModel"/> used for filtering</param>
        /// <returns>IEnumerable of <see cref="GetGameResultHistoryResponse"/></returns>
        Task<IEnumerable<GetGameResultHistoryResponse>> GetAllAsync(GetAllHistoryRequest filterRequest);
    }
}
