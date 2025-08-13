using Game.Domain.DTO.GameRpsls.InternalModels;
using Game.Infrastructure.Utilities.Enums.Rpsls;
using Game.Infrastructure.Utilities.Helpers;
using Game.Service.Abstractions.GameRpsls;
using Game.Service.Abstractions.Validators;
using Microsoft.Extensions.Logging;

namespace Game.Service.GameRpsls
{
    /// <summary>
    /// Class for methods related with RPSLS game result calculation
    /// </summary>
    public class GameCalculatorService : IGameCalculatorService
    {
        /// <summary>
        /// Property for accessing implementation of interface <see cref="IGameRpslsValidator"/>
        /// </summary>
        private readonly IGameRpslsValidator _gameValidator;
        private readonly ILogger<GameCalculatorService> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="gameValidator">Implementation of interface <see cref="IGameRpslsValidator"/></param>
        /// <param name="logger">Logger</param>
        /// <exception cref="ArgumentNullException"></exception>
        public GameCalculatorService(IGameRpslsValidator gameValidator, ILogger<GameCalculatorService> logger)
        {
            _gameValidator = gameValidator ?? throw new ArgumentNullException(nameof(gameValidator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Dictionary where the key represents choice and the value represents list of choices 'weaker' then the choice from the key
        /// </summary>
        private static readonly Dictionary<GameRpslsChoice, IEnumerable<GameRpslsChoice>> DominatesChoices =
            new Dictionary<GameRpslsChoice, IEnumerable<GameRpslsChoice>>
            {
                { GameRpslsChoice.Rock, new List<GameRpslsChoice>(){GameRpslsChoice.Lizard, GameRpslsChoice.Scissors}},
                { GameRpslsChoice.Paper, new List<GameRpslsChoice>(){GameRpslsChoice.Rock, GameRpslsChoice.Spock}},
                { GameRpslsChoice.Scissors, new List<GameRpslsChoice>(){GameRpslsChoice.Paper, GameRpslsChoice.Lizard}},
                { GameRpslsChoice.Lizard, new List<GameRpslsChoice>(){GameRpslsChoice.Paper, GameRpslsChoice.Spock}},
                { GameRpslsChoice.Spock, new List<GameRpslsChoice>(){GameRpslsChoice.Scissors, GameRpslsChoice.Rock}},
            };
        /// <summary>
        /// Calculate game result from player perspective.
        /// </summary>
        /// <param name="request">Model class of type <see cref="GameCalculationRequest"/></param>
        /// <returns>Enum value of <see cref="GameResult"/></returns>
        public GameResult Calculate(GameCalculationRequest request)
        {
            _logger.LogInformation(LogMessageBuilder.GetStartedMethodMessage(
                $"{nameof(request.PlayerChoice)}:{request.PlayerChoice} and {nameof(request.ComputerChoice)}:{request.ComputerChoice}"));

            _gameValidator.ValidateGameCalculatorRequest(request);

            //If both player and computer chose the same option the game result will be 'Tie'
            if (request.PlayerChoice == request.ComputerChoice)
            {
                _logger.LogInformation(LogMessageBuilder.GetFinishedMethodMessage($"{nameof(GameResult)}:{GameResult.Tie}"));
                return GameResult.Tie;
            }

            //Get list of game choices that are 'weaker' then the chosen player choice
            //If a computer choice is in that list then player is winner and the calculation result in Win.
            //Otherwise the winner is computer and the result is Lose
            IEnumerable<GameRpslsChoice> dominatedChoicesForUserChoice = new List<GameRpslsChoice>();
            DominatesChoices.TryGetValue(request.PlayerChoice, out dominatedChoicesForUserChoice);

            bool isInDominatesList = dominatedChoicesForUserChoice.Contains(request.ComputerChoice);

            if (isInDominatesList)
            {
                _logger.LogInformation(LogMessageBuilder.GetFinishedMethodMessage($"{nameof(GameResult)}:{GameResult.Win}"));
                return GameResult.Win;
            }

            _logger.LogInformation(LogMessageBuilder.GetFinishedMethodMessage($"{nameof(GameResult)}:{GameResult.Lose}"));
            return GameResult.Lose;
        }
    }
}
