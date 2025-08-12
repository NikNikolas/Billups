using Game.Infrastructure.Utilities.Settings.HttpClientSettings.Base;
using Microsoft.Extensions.Http;
using Microsoft.Extensions.Options;

namespace GameAPI.ConfigureOptions
{
    /// <summary>
    /// Configure named http client
    /// </summary>
    public class ConfigureNamedHttpClientOptions : IConfigureNamedOptions<HttpClientFactoryOptions>
    {
        private readonly IExternalApiSettings _apiSettings;

        /// <summary>
        /// Create an instance
        /// </summary>
        /// <param name="apiSettings">Settings read from appSettings.json</param>
        /// <exception cref="ArgumentNullException"></exception>
        public ConfigureNamedHttpClientOptions(IExternalApiSettings apiSettings)
        {
            _apiSettings = apiSettings ?? throw new ArgumentNullException(nameof(apiSettings));
        }

        /// <summary>
        /// Default configure method
        /// </summary>
        /// <param name="options"></param>
        public void Configure(HttpClientFactoryOptions options)
        {

        }

        /// <summary>
        /// Configure custom named http client
        /// </summary>
        /// <param name="name"></param>
        /// <param name="options"></param>
        public void Configure(string? name, HttpClientFactoryOptions options)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            var concreteSettings = _apiSettings.GetCustomSettings(name);

            options.HttpClientActions.Add(action =>
            {
                action.BaseAddress = new Uri(concreteSettings.Host);
                action.Timeout = TimeSpan.FromSeconds(concreteSettings.TimeoutInSeconds);

                if (concreteSettings.MandatoryHeaders != null && concreteSettings.MandatoryHeaders.Any())
                {
                    foreach (var header in concreteSettings.MandatoryHeaders)
                    {
                        action.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }
            }
            );
        }
    }
}
