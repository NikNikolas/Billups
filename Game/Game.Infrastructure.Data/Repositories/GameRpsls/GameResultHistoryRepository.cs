using Game.Domain.Data.Abstractions.Repositories.GameRpsls;
using Game.Domain.Data.Abstractions.Entities.GameRpsls;
using Game.Infrastructure.Data.MoqLocalDb;

namespace Game.Infrastructure.Data.Repositories.GameRpsls
{
    internal class GameResultHistoryRepository : IGameResultHistoryRepository
    {
        public Task SaveAsync(GameResultHistory newRecord)
        {
            LocalDb.Current.GameResultHistories.Add(newRecord);

            return Task.CompletedTask;
        }
    }
}
