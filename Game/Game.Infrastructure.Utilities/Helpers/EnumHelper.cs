using Game.Infrastructure.Utilities.Enums.Rpsls;

namespace Game.Infrastructure.Utilities.Helpers
{
    public static class EnumHelper
    {
        /// <summary>
        /// Convert enum value of <see cref="GameResult"/> to custom text
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string GetNameOfGameResult(GameResult result)
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
