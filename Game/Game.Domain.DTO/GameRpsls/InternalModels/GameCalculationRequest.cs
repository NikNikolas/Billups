using Game.Domain.DTO.Base;
using Game.Infrastructure.Utilities.Enums.Rpsls;

namespace Game.Domain.DTO.GameRpsls.InternalModels
{
    /// <summary>
    /// Model class for game result calculation
    /// </summary>
    public class GameCalculationRequest : IModel
    {
        /// <summary>
        /// Game choice submitted by user
        /// </summary>
        public Choice PlayerChoice { get; set; }
        /// <summary>
        /// Game choice randomly chosen by computer
        /// </summary>
        public Choice ComputerChoice { get; set; }
    }
}
