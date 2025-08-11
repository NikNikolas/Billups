using Game.Domain.DTO.Base;

namespace Game.Domain.DTO.GameRpsls.Requests
{
    /// <summary>
    /// Request on endpoint 'game/play' 
    /// </summary>
    public class PlayGameRequest : IRequest
    {
        /// <summary>
        /// Player chosen choice for game
        /// </summary>
        public int Player { get; set; }
    }
}
