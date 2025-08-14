using Game.Domain.Data.Abstractions.Repositories.GameRpsls;
using Game.Domain.Data.Abstractions.Entities.GameRpsls;
using Game.Domain.Data.Abstractions.Model;
using Microsoft.EntityFrameworkCore;
using Game.Infrastructure.Data.DataContext;

namespace Game.Infrastructure.Data.Repositories.GameRpsls
{
    /// <summary>
    /// Repository class for entity <see cref="GameResultHistory"/>
    /// </summary>
    internal class GameResultHistoryRepository : IGameResultHistoryRepository
    {


        /// <summary>
        /// Db context
        /// </summary>
        private readonly AppDbContext _context;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public GameResultHistoryRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        /// <summary>
        /// Saves new record of entity type <see cref="GameResultHistory"/> in db asynchronous
        /// </summary>
        /// <param name="newRecord">Entity of type <see cref="GameResultHistory"/> that should be saved</param>
        /// <returns></returns>
        public async Task SaveAsync(GameResultHistory newRecord)
        {
            await _context.GameResultHistories.AddAsync(newRecord);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Return collection of history object by filters
        /// </summary>
        /// <param name="request">Object of type <see cref="GetAllHistoryModel"/> for filtering data</param>
        /// <returns>IEnumerable of <see cref="GameResultHistory"/></returns>
        public async Task<IEnumerable<GameResultHistory>> GetAllAsync(GetAllHistoryModel request)
        {
            var histories = await _context.GameResultHistories.OrderBy(h => h.PlayedDateTime)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            return histories;
        }
    }
}
