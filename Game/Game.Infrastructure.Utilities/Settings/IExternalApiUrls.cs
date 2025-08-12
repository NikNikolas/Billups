namespace Game.Infrastructure.Utilities.Settings
{
    /// <summary>
    /// Interface to class that contains external api urls read from appSettings.json
    /// </summary>
    public interface IExternalApiUrls
    {
        /// <summary>
        /// Relative URL to endpoint for generating random number
        /// </summary>
        public string UrlRandomNumberGenerator { get; set; }
    }
}
