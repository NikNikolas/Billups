using Game.Domain.DTO.Base;

namespace Game.Domain.DTO.GameRpsls.InternalModels
{
    /// <summary>
    /// Response from third party service for generating random number
    /// </summary>
    public class RandomNumberResponse : IModel
    {
        /// <summary>
        /// Generated random number
        /// </summary>
        public int Random_number { get; set; }
    }
}
