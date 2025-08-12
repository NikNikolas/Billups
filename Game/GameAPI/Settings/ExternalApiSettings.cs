using Game.Infrastructure.Utilities.Settings.HttpClientSettings.Base;
using Game.Infrastructure.Utilities.Settings.HttpClientSettings;

namespace GameAPI.Settings
{
    /// <summary>
    /// Contains collection of httpClientSettings for external APIs
    /// </summary>
    public class ExternalApiSettings : IExternalApiSettings
    {
        /// <summary>
        /// List of http client settings for external APIs
        /// </summary>
        public List<HttpClientSettings> ApiSettings { get; set; }
        /// <summary>
        /// Return single settings by client name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public HttpClientSettings GetCustomSettings(string name)
        {
            if (ApiSettings == null)
            {
                throw new ArgumentNullException($"{nameof(HttpClientSettings)} are not properly configured in appSettings.json");
            }

            switch (name)
            {
                case "CodeChallenge":
                    return ApiSettings.FirstOrDefault(s => s.Name == "CodeChallenge");
                default:
                    return null;
            }
        }
    }
}
