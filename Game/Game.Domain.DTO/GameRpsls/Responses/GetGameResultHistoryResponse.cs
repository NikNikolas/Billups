using Game.Domain.DTO.Base;
using Game.Infrastructure.Utilities.Enums.Rpsls;

namespace Game.Domain.DTO.GameRpsls.Responses
{
    /// <summary>
    /// Request class for return all game result history record
    /// </summary>
    public class GetGameResultHistoryResponse : IResponse
    {
        /// <summary>
        /// Game option chosen by user
        /// </summary>
        public GameRpslsChoice PlayerChoice { get; set; }
        /// <summary>
        /// Game option randomly chosen by computer
        /// </summary>
        public GameRpslsChoice ComputerChoice { get; set; }
        /// <summary>
        /// Result of game
        /// </summary>
        public string Result { get; set; }
        /// <summary>
        /// Datetime when game was played in UTC time format
        /// </summary>
        public DateTime PlayedDateTime { get; set; }
    }
}
