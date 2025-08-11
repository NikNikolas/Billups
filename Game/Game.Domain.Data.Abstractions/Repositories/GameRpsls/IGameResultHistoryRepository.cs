using Game.Domain.Data.Abstractions.Entities.GameRpsls;

namespace Game.Domain.Data.Abstractions.Repositories.GameRpsls
{
    /// <summary>
    /// Interface to repository class of entity <see cref="GameResultHistory"/>
    /// </summary>
    public interface IGameResultHistoryRepository
    {
        /// <summary>
        /// Saves new record of entity type <see cref="GameResultHistory"/> in db asynchronous
        /// </summary>
        /// <param name="newRecord">Entity of type <see cref="GameResultHistory"/> that should be saved</param>
        /// <returns></returns>
        Task SaveAsync(GameResultHistory newRecord);
    }
}
