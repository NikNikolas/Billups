using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using GameAPI.Extensions;

namespace GameAPI.ConfigureOptions
{
    /// <summary>
    /// Configure <see cref="ApiBehaviorOptions"/>
    /// </summary>
    public class ConfigureApiBehaviorOptions : IConfigureOptions<ApiBehaviorOptions>
    {
        /// <summary>
        /// Invoked to configure a <see cref="ApiBehaviorOptions"/> instance.
        /// </summary>
        /// <param name="options">The options instance to configure.</param>
        public void Configure(ApiBehaviorOptions options)
        {
            options.InvalidModelStateResponseFactory = context =>
            {
                var errorMessages = context.GetErrorMessages();
                return new BadRequestObjectResult(errorMessages);
            };
        }
    }
}
