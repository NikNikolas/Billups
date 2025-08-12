namespace Game.Infrastructure.Utilities.Settings.HttpClientSettings.Base
{
    /// <summary>
    /// Contains collection of httpClientSettings for external APIs
    /// </summary>
    public interface IExternalApiSettings
    {
        /// <summary>
        /// List of http client settings for external APIs
        /// </summary>
        public List<HttpClientSettings> ApiSettings { get; set; }
        /// <summary>
        /// Return API Settings for Ltm Backend
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        HttpClientSettings GetCustomSettings(string name);
    }
}
