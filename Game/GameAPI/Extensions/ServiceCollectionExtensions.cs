using GameAPI.Settings;

namespace GameAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the configuration.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configurations">The configurations.</param>
        public static void AddConfiguration(this IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configurations)
        {
            var apiSettings = configurations.GetSection(typeof(AppSettings).Name);
            services.Configure<AppSettings>(apiSettings).AddScoped<AppSettings>();

            var connectionStringSettings = configurations.GetSection(typeof(ConnectionStrings).Name);
            services.Configure<ConnectionStrings>(connectionStringSettings).AddScoped<ConnectionStrings>();

            var swaggerUISettings = configurations.GetSection(typeof(SwaggerUISettings).Name);
            services.Configure<SwaggerUISettings>(swaggerUISettings).AddScoped<SwaggerUISettings>();

            var swaggerSettings = configurations.GetSection(typeof(SwaggerSettings).Name);
            services.Configure<SwaggerSettings>(swaggerSettings).AddScoped<SwaggerSettings>();
        }
    }
}
