namespace Game.Infrastructure.Utilities.Settings
{
    /// <summary>
    /// Connection string read from appSettings
    /// </summary>
    public interface IConnectionStrings
    {
        /// <summary>
        /// Gets or sets the offer database.
        /// </summary>
        /// <value>
        /// The offer database.
        /// </value>
        string IsBets { get; }
    }
}
