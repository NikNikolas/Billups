using System.Reflection;
using Autofac;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Game.Domain.Data.Abstractions.Modules;
using Game.Infrastructure.Utilities.Settings;


namespace Game.Service.Abstractions.Modules
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="Autofac.Module" />
    public class ServiceModule : Autofac.Module
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
        /// Initializes a new instance of the <see cref="ServiceModule"/> class.
        /// </summary>
        /// <param name="appSettings">The application settings.</param>
        /// <param name="configuration">The configuration.</param>
        public ServiceModule(IAppSettings appSettings, IConfiguration configuration)
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
            if (appSettings?.ServiceDllRoot == null || string.IsNullOrWhiteSpace(appSettings?.ServiceDllName))
            {
                throw new ArgumentNullException(nameof(appSettings), "Service layer DLL settings are not provided!");
            }
            base.Load(builder);
            builder.RegisterModule(new DataModule(this.appSettings, this.configuration));
            var contentRootKey = configuration?.GetValue<string>(WebHostDefaults.ContentRootKey);
            if (!string.IsNullOrEmpty(contentRootKey))
            {
                string serviceDllRoot = Path.Combine(contentRootKey, appSettings.ServiceDllRoot);
                var assembly = Assembly.UnsafeLoadFrom(Path.Combine(serviceDllRoot, appSettings.ServiceDllName));
                builder.RegisterAssemblyModules(assembly.GetTypes().First(t => t.BaseType == typeof(Autofac.Module)), assembly);
            }
            else
            {
                throw new ArgumentException("Root of service .dll not exist!");
            }
        }
    }
}
