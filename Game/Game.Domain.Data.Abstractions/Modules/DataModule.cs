using System.Reflection;
using Microsoft.Extensions.Configuration;
using Autofac;
using Microsoft.AspNetCore.Hosting;
using Game.Infrastructure.Utilities.Settings;

namespace Game.Domain.Data.Abstractions.Modules
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="Autofac.Module" />
    public class DataModule : Autofac.Module
    {
        /// <summary>
        /// The application settings
        /// </summary>
        private readonly IAppSettings appSettings;

        /// <summary>
        /// The application configuration
        /// </summary>
        private readonly IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataModule"/> class.
        /// </summary>
        /// <param name="appSettings">The application settings.</param>
        /// <param name="configuration">The application configuration.</param>
        public DataModule(IAppSettings appSettings, IConfiguration configuration)
        {
            this.appSettings = appSettings;
            this.configuration = configuration;
        }

        /// <summary>
        /// Override to add registrations to the container.
        /// </summary>
        /// <param name="builder">The builder through which components can be
        /// registered.</param>
        /// <remarks>
        /// Note that the ContainerBuilder parameter is unique to this module.
        /// </remarks>
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            string databaseProviderDllRoot = Path.Combine(configuration.GetValue<string>(WebHostDefaults.ContentRootKey), appSettings.DataProviderDllRoot);
            var assembly = Assembly.UnsafeLoadFrom(Path.Combine(databaseProviderDllRoot, appSettings.DataProviderDllName));
            builder.RegisterAssemblyModules(assembly.GetTypes().First(t => t.BaseType == typeof(Autofac.Module)), assembly);
        }
    }
}
