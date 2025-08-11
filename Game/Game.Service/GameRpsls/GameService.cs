using Game.Domain.Data.Abstractions.Repositories.GameRpsls;
using AutoMapper;
using Game.Domain.DTO.GameRpsls.InternalModels;
using Game.Service.Abstractions.GameRpsls;
using Game.Service.Abstractions.Validators;
using Game.Infrastructure.Utilities.Enums.Rpsls;
using Game.Domain.DTO.GameRpsls.Requests;
using Game.Domain.DTO.GameRpsls.Responses;

namespace Game.Service.GameRpsls
{
    /// <summary>
    /// Contains logic related with Game. Implementation of interface <see cref="IGameService"/>
    /// </summary>
    public class GameService : IGameService
    {
        /// <summary>
        /// Property for accessing implementation of interface <see cref="IChoiceRepository"/>
        /// </summary>
        private readonly IChoiceRepository _choiceRepository;
        /// <summary>
        /// Property for accessing implementation of interface <see cref="IRandomOptionGenerator"/>
        /// </summary>
        private readonly IRandomOptionGenerator _randomOptionGenerator;
        /// <summary>
        /// Property for accessing implementation of interface <see cref="IGameRpslsValidator"/>
        /// </summary>
        private readonly IGameRpslsValidator _gameRpslsValidator;
        /// <summary>
        /// Property for accessing implementation of interface <see cref="IGameCalculatorService"/>
        /// </summary>
        private readonly IGameCalculatorService _gameCalculatorService;
        /// <summary>
        /// Property for accessing implementation of interface <see cref="IMapper"/> for mapping object
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Create an instance of class <see cref="GameService"/>.
        /// </summary>
        /// <param name="choiceRepository">Implementation of interface <see cref="IChoiceRepository"/></param>
        /// <param name="randomOptionGenerator">Implementation of interface <see cref="IRandomOptionGenerator"/></param>
        /// <param name="gameRpslsValidator">Implementation of interface <see cref="IGameRpslsValidator"/></param>
        /// <param name="gameCalculatorService">Implementation of interface <see cref="IGameCalculatorService"/></param>
        /// <param name="mapper">Implementation of interface <see cref="IMapper"/></param>
        /// <exception cref="ArgumentNullException"></exception>
        public GameService(IChoiceRepository choiceRepository, IRandomOptionGenerator randomOptionGenerator, IGameRpslsValidator gameRpslsValidator,
            IGameCalculatorService gameCalculatorService, IMapper mapper)
        {
            _choiceRepository = choiceRepository ?? throw new ArgumentNullException(nameof(choiceRepository));
            _randomOptionGenerator = randomOptionGenerator ?? throw new ArgumentNullException(nameof(randomOptionGenerator));
            _gameRpslsValidator = gameRpslsValidator ?? throw new ArgumentNullException(nameof(gameRpslsValidator));
            _gameCalculatorService = gameCalculatorService ?? throw new ArgumentNullException(nameof(gameCalculatorService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Returns collection of DTO response classes of type <see cref="GetChoiceResponse"/> asynchronously
        /// </summary>
        /// <returns>IEnumerable of class <see cref="GetChoiceResponse"/></returns>
        public async Task<IEnumerable<GetChoiceResponse>> GetAllChoicesAsync()
        {
            var choices = await _choiceRepository.GetAllAsync();

            var choicesResponses = _mapper.Map<IEnumerable<GetChoiceResponse>>(choices);

            return choicesResponses;
        }

        /// <summary>
        /// Returns DTO response class of type <see cref="GetChoiceResponse"/> asynchronously
        /// </summary>
        /// <returns>DTO class <see cref="GetChoiceResponse"/></returns>
        public async Task<GetChoiceResponse> GetCustomChoiceAsync()
        {
            Choice randomChoice = await _randomOptionGenerator.GenerateRandomOptionAsync();

            var choice = await _choiceRepository.GetByIdAsync((int)randomChoice);

            var response = _mapper.Map<GetChoiceResponse>(choice);

            return response;
        }
        /// <summary>
        /// Calculate result of submitted users choice with random computer choice and return game result asynchronously
        /// </summary>
        /// <param name="request">DTO class <see cref="PlayGameRequest"/></param>
        /// <returns>DTO class <see cref="PlayGameRequest"/></returns>
        public async Task<PlayGameResponse> PlayGameAsync(PlayGameRequest request)
        {
            var response = new PlayGameResponse();

            _gameRpslsValidator.ValidatePlayGameRequest(request);

            var computerChoice = await _randomOptionGenerator.GenerateRandomOptionAsync();

            GameCalculationRequest calculationRequest = new GameCalculationRequest
            {
                PlayerChoice = (Choice)request.Player,
                ComputerChoice = computerChoice
            };

            var gameResult = _gameCalculatorService.Calculate(calculationRequest);

            response.Player = request.Player;
            response.Computer = (int)computerChoice;
            response.Results = GetNameOfGameResult(gameResult);

            return response;
        }

        private string GetNameOfGameResult(GameResult result)
        {
            switch (result)
            {
                case GameResult.Lose:
                    return "Lose";
                case GameResult.Win:
                    return "Win";
                case
                    GameResult.Tie:
                    return "Tie";
                default:
                    throw new Exception($"Invalid value of {nameof(GameResult)}");
            }
            
        }
    }
}
