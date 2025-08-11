using Game.Service.Abstractions.GameRpsls;
using Game.Domain.Data.Abstractions.Entities.GameRpsls;
using Game.Domain.Data.Abstractions.Repositories.GameRpsls;
using Game.Service.Abstractions.Validators;

namespace Game.Service.GameRpsls
{
    /// <summary>
    /// Service class with methods related with operation of entity <see cref="GameResultHistory"/>
    /// </summary>
    internal class GameResultHistoryService : IGameResultHistoryService
    {
        private readonly IGameResultHistoryRepository _repository;
        private readonly IGameRpslsValidator _validator;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository">Implementation of interface <see cref="IGameResultHistoryRepository"/></param>
        /// <param name="validator">Implementation of interface <see cref="IGameRpslsValidator"/></param>
        /// <exception cref="ArgumentNullException"></exception>
        public GameResultHistoryService(IGameResultHistoryRepository repository, IGameRpslsValidator validator)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        /// <summary>
        /// Saves new record of entity type <see cref="GameResultHistory"/>
        /// </summary>
        /// <param name="newRecord">Instance of entity type <see cref="GameResultHistory"/> that should be saved</param>
        /// <returns></returns>
        public async Task SaveAsync(GameResultHistory newRecord)
        {
            _validator.ValidateGameResultHistory(newRecord);

            await _repository.SaveAsync(newRecord);
        }
    }
}
