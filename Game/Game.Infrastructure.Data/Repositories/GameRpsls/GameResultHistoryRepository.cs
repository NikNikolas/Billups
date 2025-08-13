using Game.Domain.Data.Abstractions.Repositories.GameRpsls;
using Game.Domain.Data.Abstractions.Entities.GameRpsls;
using Game.Domain.Data.Abstractions.Model;
using Game.Infrastructure.Data.MoqLocalDb;

namespace Game.Infrastructure.Data.Repositories.GameRpsls
{
    /// <summary>
    /// Repository class for entity <see cref="GameResultHistory"/>
    /// </summary>
    internal class GameResultHistoryRepository : IGameResultHistoryRepository
    {
        /// <summary>
        /// Saves new record of entity type <see cref="GameResultHistory"/> in db asynchronous
        /// </summary>
        /// <param name="newRecord">Entity of type <see cref="GameResultHistory"/> that should be saved</param>
        /// <returns></returns>
        public Task SaveAsync(GameResultHistory newRecord)
        {
            LocalDb.Current.GameResultHistories.Add(newRecord);

            return Task.CompletedTask;
        }

        /// <summary>
        /// Return collection of history object by filters
        /// </summary>
        /// <param name="request">Object of type <see cref="GetAllHistoryModel"/> for filtering data</param>
        /// <returns>IEnumerable of <see cref="GameResultHistory"/></returns>
        public Task<IEnumerable<GameResultHistory>> GetAllAsync(GetAllHistoryModel request)
        {
            var histories = LocalDb.Current.GameResultHistories.OrderBy(h => h.PlayedDateTime)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize);

            return Task.FromResult(histories);
        }
    }
}
