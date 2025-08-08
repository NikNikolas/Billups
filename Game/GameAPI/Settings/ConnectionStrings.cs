using Game.Infrastructure.Utilities.Settings;

namespace GameAPI.Settings
{
    /// <summary>
    ///
    /// </summary>
    internal class ConnectionStrings : IConnectionStrings
    {
        /// <summary>
        /// Gets or sets the offer database.
        /// </summary>
        /// <value>
        /// The offer database.
        /// </value>

        public string IsBets { get; set; } = null!;
    }
}
