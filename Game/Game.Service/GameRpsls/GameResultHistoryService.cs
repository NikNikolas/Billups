using AutoMapper;
using Game.Service.Abstractions.GameRpsls;
using Game.Domain.Data.Abstractions.Entities.GameRpsls;
using Game.Domain.Data.Abstractions.Model;
using Game.Domain.Data.Abstractions.Repositories.GameRpsls;
using Game.Service.Abstractions.Validators;
using Game.Domain.DTO.GameRpsls.Requests;
using Game.Domain.DTO.GameRpsls.Responses;

namespace Game.Service.GameRpsls
{
    /// <summary>
    /// Service class with methods related with operation of entity <see cref="GameResultHistory"/>
    /// </summary>
    internal class GameResultHistoryService : IGameResultHistoryService
    {
        private readonly IGameResultHistoryRepository _repository;
        private readonly IGameRpslsValidator _validator;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository">Implementation of interface <see cref="IGameResultHistoryRepository"/></param>
        /// <param name="validator">Implementation of interface <see cref="IGameRpslsValidator"/></param>
        /// <param name="mapper"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public GameResultHistoryService(IGameResultHistoryRepository repository, IGameRpslsValidator validator, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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
        /// <summary>
        /// Return collection of played game results
        /// </summary>
        /// <param name="filterRequest">Instance of model class <see cref="GetAllHistoryRequest"/> used for filtering</param>
        /// <returns>IEnumerable of <see cref="GetGameResultHistoryResponse"/></returns>
        public async Task<IEnumerable<GetGameResultHistoryResponse>> GetAllAsync(GetAllHistoryRequest filterRequest)
        {
            var request = _mapper.Map<GetAllHistoryModel>(filterRequest);

            var histories = await _repository.GetAllAsync(request);

            var response = _mapper.Map<IEnumerable<GetGameResultHistoryResponse>>(histories);

            return response;
        }
    }
}
