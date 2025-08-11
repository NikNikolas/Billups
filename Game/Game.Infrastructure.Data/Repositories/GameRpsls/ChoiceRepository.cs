using Game.Domain.Data.Abstractions.Entities.GameRpsls;
using Game.Domain.Data.Abstractions.Repositories.GameRpsls;
using Game.Infrastructure.Data.MoqLocalDb;

namespace Game.Infrastructure.Data.Repositories.GameRpsls
{
    /// <summary>
    /// Repository for entity of type <see cref="Choice"/>
    /// </summary>
    public class ChoiceRepository : IChoiceRepository
    {
        /// <summary>
        /// Returns collection of all entities with type <see cref="Choice"/>
        /// </summary>
        /// <returns><see cref="IEnumerable{Choice}"/></returns>
        public Task<IEnumerable<Choice>> GetAllAsync()
        {
            return Task.FromResult(LocalDb.Current.Choices);
        }
        /// <summary>
        /// Returns entity of type <see cref="Choice"/> by Id
        /// </summary>
        /// <param name="id">Unique identifier of entity <see cref="Choice"/> used as filter</param>
        /// <returns>Instance of class <see cref="Choice"/></returns>
        public Task<Choice> GetByIdAsync(int id)
        {
            var choice = LocalDb.Current.Choices.FirstOrDefault(c => c.Id == id);

            return Task.FromResult(choice);
        }
    }
}
