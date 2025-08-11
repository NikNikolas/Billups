using Game.Domain.Data.Abstractions.Entities.Base;

namespace Game.Domain.Data.Abstractions.Entities.GameRpsls
{
    /// <summary>
    /// Entity class that describes options to chose in RPSLS game
    /// </summary>
    public class Choice : IEntity
    {
        /// <summary>
        /// Unique identifier of entity
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Description of entity
        /// </summary>
        public string Name { get; set; }
    }
}
