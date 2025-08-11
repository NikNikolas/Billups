using Autofac;
using Autofac.Extensions.DependencyInjection;
using Game.Service.Abstractions.Modules;
using GameAPI.Modules;
using GameAPI.Settings;

namespace GameAPI.Extensions
{
    /// <summary>
    /// Autofac builder extensions
    /// </summary>
    public static class ContainerBuilderExtensions
    {
        /// <summary>
        /// Autofac the builder.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configurations">The configurations.</param>
        /// <returns></returns>
        public static IContainer AutofacBuilder(this IServiceCollection services, IConfiguration configurations)
        {
            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterModule<GameModule>();
            var configurationSection = configurations.GetSection(typeof(AppSettings).Name);
            var appSettings = configurationSection.Get<AppSettings>();
            builder.RegisterModule(new ServiceModule(appSettings, configurations));
            return builder.Build();
        }
    }
}
