using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Options;
using Game.Infrastructure.Utilities.Helpers;
using Game.Infrastructure.Utilities.Settings;
using System.Linq;

namespace GameAPI.ConfigureOptions
{
    /// <summary>
    /// PostConfigure CorsOptions
    /// </summary>
    /// <seealso cref="CorsOptions" />
    public class ConfigureCorsOptions : IConfigureOptions<CorsOptions>
    {
        /// <summary>
        /// The application settings
        /// </summary>
        private readonly IAppSettings _appSettings;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<ConfigureCorsOptions> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigureCorsOptions" /> class.
        /// </summary>
        /// <param name="appSettings">The application settings.</param>
        /// <param name="logger">The logger.</param>
        public ConfigureCorsOptions(IAppSettings appSettings, ILogger<ConfigureCorsOptions> logger)
        {
            _appSettings = appSettings;
            _logger = logger;
        }

        /// <summary>
        /// Configure allowed URLs, Methods and Headers
        /// </summary>
        /// <param name="options"></param>
        public void Configure(CorsOptions options)
        {
            options.AddPolicy(PolicyName.AllowOrigin, (policy) =>
            {
                if (_appSettings.EnabledCorsUris != null && _appSettings.EnabledCorsUris.Any())
                {
                    policy.WithOrigins(_appSettings.EnabledCorsUris);
                }
                else
                {
                    _logger.LogWarning("Cors Uri is not in app settings please add EnabledCorsUris in appSettings.json");
                }
                policy.AllowAnyMethod();
                policy.AllowAnyHeader();
            });
        }
    }
}
