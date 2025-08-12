using Game.Infrastructure.Utilities.Settings;

namespace GameAPI.Settings
{
    /// <summary>
    /// Contains external api urls read from appSettings.json
    /// </summary>
    public class ExternalApiUrls : IExternalApiUrls
    {
        /// <summary>
        /// Relative URL to endpoint for generating random number
        /// </summary>
        public string UrlRandomNumberGenerator { get; set; }
    }
}
