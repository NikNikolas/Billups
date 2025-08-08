using Autofac;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Options;
using GameAPI.Settings.Abstractions;
using GameAPI.Settings;
using Game.Infrastructure.Utilities.Settings;
using GameAPI.ConfigureOptions;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.AspNetCore.Mvc;

namespace GameAPI.Modules
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Autofac.Module" />
    public class UsersMigrationModule : Module
    {
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
            RegisterSettings(builder);
            RegisterConfiguration(builder);
        }

        private static void RegisterSettings(ContainerBuilder builder)
        {
            builder.Register<AppSettings>(c =>
            {
                return c.Resolve<IOptionsSnapshot<AppSettings>>().Value;
            }).As<IAppSettings>().SingleInstance();

            builder.Register<ConnectionStrings>(c =>
            {
                return c.Resolve<IOptionsSnapshot<ConnectionStrings>>().Value;
            }).As<IConnectionStrings>().SingleInstance();

            builder.Register<SwaggerUISettings>(c =>
                {
                    return c.Resolve<IOptionsSnapshot<SwaggerUISettings>>().Value;
                }).As<ISwaggerUISettings>().SingleInstance();

            builder.Register<SwaggerSettings>(c =>
            { 
                return c.Resolve<IOptionsSnapshot<SwaggerSettings>>().Value;
            }).As<ISwaggerSettings>().SingleInstance();
        }

        private static void RegisterConfiguration(ContainerBuilder builder)
        {
            builder.RegisterType<ConfigureSwaggerUIOptions>().As<IConfigureOptions<SwaggerUIOptions>>();
            builder.RegisterType<ConfigureSwaggerGenOptions>().As<IConfigureOptions<SwaggerGenOptions>>();
            builder.RegisterType<ConfigureSwaggerOptions>().As<IConfigureOptions<SwaggerOptions>>();
            builder.RegisterType<ConfigureApiBehaviorOptions>().As<IConfigureOptions<ApiBehaviorOptions>>().InstancePerDependency();
            builder.RegisterType<ConfigureCorsOptions>().As<IConfigureOptions<CorsOptions>>().InstancePerDependency();
        }
    }
}
