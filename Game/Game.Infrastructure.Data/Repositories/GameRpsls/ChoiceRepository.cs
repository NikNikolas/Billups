using Game.Domain.Data.Abstractions.Entities.GameRpsls;
using Game.Domain.Data.Abstractions.Repositories.GameRpsls;
using Game.Infrastructure.Data.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Game.Infrastructure.Data.Repositories.GameRpsls
{
    /// <summary>
    /// Repository for entity of type <see cref="Choice"/>
    /// </summary>
    public class ChoiceRepository : IChoiceRepository
    {
        private readonly AppDbContext _context;

        public ChoiceRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Returns collection of all entities with type <see cref="Choice"/>
        /// </summary>
        /// <returns><see cref="IEnumerable{Choice}"/></returns>
        public async Task<IEnumerable<Choice>> GetAllAsync()
        {
            return await _context.Choices.ToListAsync();
        }
        /// <summary>
        /// Returns entity of type <see cref="Choice"/> by Id
        /// </summary>
        /// <param name="id">Unique identifier of entity <see cref="Choice"/> used as filter</param>
        /// <returns>Instance of class <see cref="Choice"/></returns>
        public async Task<Choice> GetByIdAsync(int id)
        {
            return await _context.Choices.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
