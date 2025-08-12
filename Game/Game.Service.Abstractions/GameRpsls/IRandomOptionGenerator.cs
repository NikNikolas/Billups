using Game.Infrastructure.Utilities.Enums.Rpsls;
using Game.Infrastructure.Utilities.ErrorHandling;

namespace Game.Service.Abstractions.GameRpsls
{
    /// <summary>
    /// Interface for method definition related with choosing random game option
    /// </summary>
    public interface IRandomOptionGenerator
    {
        /// <summary>
        /// Return randomly chosen game option
        /// </summary>
        /// <returns>Enum value of <see cref="GameRpslsChoice"/></returns>
        Task<Result<GameRpslsChoice>> GenerateRandomOptionAsync();
    }
}
