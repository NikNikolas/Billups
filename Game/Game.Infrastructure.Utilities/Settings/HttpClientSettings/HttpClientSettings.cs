using Game.Infrastructure.Utilities.Settings.HttpClientSettings.Base;

namespace Game.Infrastructure.Utilities.Settings.HttpClientSettings
{
    /// <summary>
    /// Settings for http client configuration
    /// </summary>
    public class HttpClientSettings : IHttpClientSettings
    {
        /// <summary>
        /// Unique Http client name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// URL to external API
        /// </summary>
        public string Host { get; set; }
        /// <summary>
        /// Timeout for http request
        /// </summary>
        public int TimeoutInSeconds { get; set; }
        /// <summary>
        /// Headers that every request must contain
        /// </summary>
        public Header[] MandatoryHeaders { get; set; }
    }
}
