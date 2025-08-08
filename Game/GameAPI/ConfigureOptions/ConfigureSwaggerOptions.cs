using Microsoft.Extensions.Options;
using GameAPI.Settings.Abstractions;
using Swashbuckle.AspNetCore.Swagger;

namespace GameAPI.ConfigureOptions
{
    /// <summary>
    /// Configure SwaggerOptions
    /// </summary>
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerOptions>
    {
        /// <summary>
        /// The swagger settings
        /// </summary>
        private readonly ISwaggerSettings swaggerSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigureSwaggerOptions"/> class.
        /// </summary>
        /// <param name="swaggerSettings">The swagger settings.</param>
        public ConfigureSwaggerOptions(ISwaggerSettings swaggerSettings)
        {
            this.swaggerSettings = swaggerSettings;
        }

        /// <summary>
        /// Invoked to configure a TOptions instance.
        /// </summary>
        /// <param name="options">The options instance to configure.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Configure(SwaggerOptions options)
        {
            options.RouteTemplate = swaggerSettings.JsonRoute;
        }
    }
}
