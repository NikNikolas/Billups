namespace Game.Domain.DTO.GameRpsls.Responses
{
    /// <summary>
    /// Response for endpoint game/choice. Used as collection in response for endpoint game/choices
    /// </summary>
    public class GetChoiceResponse
    {
        /// <summary>
        /// Unique identifier of choice
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Description of choice
        /// </summary>
        public string Name { get; set; }
    }
}
