using Microsoft.Extensions.Options;
using GameAPI.Settings.Abstractions;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace GameAPI.ConfigureOptions
{
    /// <summary>
    /// Configure SwaggerUI options
    /// </summary>
    public class ConfigureSwaggerUIOptions : IConfigureOptions<SwaggerUIOptions>
    {
        private readonly ISwaggerUISettings swaggerUISettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigureSwaggerUIOptions"/> class.
        /// </summary>
        /// <param name="swaggerUISettings"></param>
        public ConfigureSwaggerUIOptions(ISwaggerUISettings swaggerUISettings)
        {
            this.swaggerUISettings = swaggerUISettings;
        }

        /// <summary>
        /// The Swagger UI options settings.
        /// </summary>
        /// <param name="options"></param>
        public void Configure(SwaggerUIOptions options)
        {
            options.SwaggerEndpoint(swaggerUISettings.Url, swaggerUISettings.Name);
        }
    }
}