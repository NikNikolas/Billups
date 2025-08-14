using System.ComponentModel.DataAnnotations.Schema;
using Game.Domain.Data.Abstractions.Entities.Base;
using Game.Infrastructure.Utilities.Enums.Rpsls;

namespace Game.Domain.Data.Abstractions.Entities.GameRpsls
{
    /// <summary>
    /// Entity class that describes played games
    /// </summary>
    public class GameResultHistory : IEntity
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
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
        public GameResult Result { get; set; }
        /// <summary>
        /// Datetime when game was played in UTC time format
        /// </summary>
        public DateTime PlayedDateTime { get; set; }
    }
}
