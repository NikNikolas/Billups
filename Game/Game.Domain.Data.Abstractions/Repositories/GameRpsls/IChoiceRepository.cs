using Game.Domain.Data.Abstractions.Entities.GameRpsls;

namespace Game.Domain.Data.Abstractions.Repositories.GameRpsls
{
    /// <summary>
    /// Interface for repository class of entity <see cref="Choice"/>
    /// </summary>
    public interface IChoiceRepository
    {
        /// <summary>
        /// Returns collection of all entities with type <see cref="Choice"/>
        /// </summary>
        /// <returns><see cref="IEnumerable{Choice}"/></returns>
        Task<IEnumerable<Choice>> GetAllAsync();
        /// <summary>
        /// Returns entity of type <see cref="Choice"/> by Id
        /// </summary>
        /// <param name="id">Unique identifier of entity <see cref="Choice"/> used as filter</param>
        /// <returns>Instance of class <see cref="Choice"/></returns>
        Task<Choice> GetByIdAsync(int id);
    }
}
