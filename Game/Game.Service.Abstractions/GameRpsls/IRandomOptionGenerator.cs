using Game.Infrastructure.Utilities.Enums.Rpsls;

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
        /// <returns>Enum value of <see cref="Choice"/></returns>
        Task<Choice> GenerateRandomOptionAsync();
    }
}
