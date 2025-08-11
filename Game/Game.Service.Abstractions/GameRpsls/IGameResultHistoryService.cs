using Game.Domain.Data.Abstractions.Entities.GameRpsls;

namespace Game.Service.Abstractions.GameRpsls
{
    /// <summary>
    /// Interface for method definition related with operation with entity <see cref="GameResultHistory"/>
    /// </summary>
    public interface IGameResultHistoryService
    {
        /// <summary>
        /// Saves new record of entity type <see cref="GameResultHistory"/>
        /// </summary>
        /// <param name="newRecord">Instance of entity type <see cref="GameResultHistory"/> that should be saved</param>
        /// <returns></returns>
        Task SaveAsync(GameResultHistory newRecord);
    }
}
