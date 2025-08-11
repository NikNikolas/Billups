using Game.Infrastructure.Utilities.Enums.Rpsls;
using Game.Service.Abstractions.GameRpsls;

namespace Game.Service.GameRpsls
{
    internal class RandomOptionGenerator : IRandomOptionGenerator
    {
        /// <summary>
        /// Return randomly chosen game option
        /// </summary>
        /// <returns>Enum value of <see cref="GameRpslsChoice"/></returns>
        public async Task<GameRpslsChoice> GenerateRandomOptionAsync()
        {
            var random = new Random().Next(1,6);

            return (GameRpslsChoice)random;
        }
    }
}
