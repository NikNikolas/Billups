using Game.Domain.DTO.GameRpsls.InternalModels;
using Game.Infrastructure.Utilities.Enums.Rpsls;
using Game.Service.GameRpsls;
using Game.Service.Validators;
using Microsoft.Extensions.Logging;
using Moq;

namespace Game.Service.Test
{
    public class GameCalculatorServiceTest
    {
        [Theory]
        [InlineData(GameRpslsChoice.Paper, GameRpslsChoice.Rock, GameResult.Win)]
        [InlineData(GameRpslsChoice.Paper, GameRpslsChoice.Spock, GameResult.Win)]
        [InlineData(GameRpslsChoice.Paper, GameRpslsChoice.Lizard, GameResult.Lose)]
        [InlineData(GameRpslsChoice.Paper, GameRpslsChoice.Scissors, GameResult.Lose)]
        [InlineData(GameRpslsChoice.Paper, GameRpslsChoice.Paper, GameResult.Tie)]
        [InlineData(GameRpslsChoice.Rock, GameRpslsChoice.Paper, GameResult.Lose)]
        [InlineData(GameRpslsChoice.Rock, GameRpslsChoice.Spock, GameResult.Lose)]
        [InlineData(GameRpslsChoice.Rock, GameRpslsChoice.Lizard, GameResult.Win)]
        [InlineData(GameRpslsChoice.Rock, GameRpslsChoice.Scissors, GameResult.Win)]
        [InlineData(GameRpslsChoice.Rock, GameRpslsChoice.Rock, GameResult.Tie)]
        [InlineData(GameRpslsChoice.Lizard, GameRpslsChoice.Spock, GameResult.Win)]
        [InlineData(GameRpslsChoice.Lizard, GameRpslsChoice.Paper, GameResult.Win)]
        [InlineData(GameRpslsChoice.Lizard, GameRpslsChoice.Rock, GameResult.Lose)]
        [InlineData(GameRpslsChoice.Lizard, GameRpslsChoice.Scissors, GameResult.Lose)]
        [InlineData(GameRpslsChoice.Lizard, GameRpslsChoice.Lizard, GameResult.Tie)]
        [InlineData(GameRpslsChoice.Spock, GameRpslsChoice.Scissors, GameResult.Win)]
        [InlineData(GameRpslsChoice.Spock, GameRpslsChoice.Rock, GameResult.Win)]
        [InlineData(GameRpslsChoice.Spock, GameRpslsChoice.Lizard, GameResult.Lose)]
        [InlineData(GameRpslsChoice.Spock, GameRpslsChoice.Paper, GameResult.Lose)]
        [InlineData(GameRpslsChoice.Spock, GameRpslsChoice.Spock, GameResult.Tie)]
        [InlineData(GameRpslsChoice.Scissors, GameRpslsChoice.Paper, GameResult.Win)]
        [InlineData(GameRpslsChoice.Scissors, GameRpslsChoice.Lizard, GameResult.Win)]
        [InlineData(GameRpslsChoice.Scissors, GameRpslsChoice.Spock, GameResult.Lose)]
        [InlineData(GameRpslsChoice.Scissors, GameRpslsChoice.Rock, GameResult.Lose)]
        [InlineData(GameRpslsChoice.Scissors, GameRpslsChoice.Scissors, GameResult.Tie)]
        public void CalculateResult_ShouldReturnCorrectResult(GameRpslsChoice playerChoice, GameRpslsChoice computerChoice, GameResult expectedResult)
        {
            //Arrange
            var loggerMock = new Mock<ILogger<GameCalculatorService>>();
            var loggerValidatorMock = new Mock<ILogger<GameRpslsValidator>>();
            var validationServiceMock = new Mock<GameRpslsValidator>(loggerValidatorMock.Object);

            GameCalculatorService service = new GameCalculatorService(validationServiceMock.Object, loggerMock.Object);
            var request = new GameCalculationRequest()
            {
                ComputerChoice = computerChoice,
                PlayerChoice = playerChoice
            };

            //Act
            var result = service.Calculate(request);

            //Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
