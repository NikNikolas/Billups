using Game.Domain.Data.Abstractions.Entities.Base;

namespace Game.Domain.Data.Abstractions.Entities.GameRpsls
{
    /// <summary>
    /// Entity of type <see cref="Choice"/>
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
