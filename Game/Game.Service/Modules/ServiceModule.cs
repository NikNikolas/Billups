using Autofac;
using AutoMapper;
using Game.Service.Abstractions.GameRpsls;
using Game.Service.Abstractions.Validators;
using Game.Service.GameRpsls;
using Game.Service.Mapper;
using Game.Service.Validators;

namespace Game.Service.Modules
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="Autofac.Module" />
    public class ServiceModule : Module
    {
        /// <summary>
        /// Override to add registrations to the container.
        /// </summary>
        /// <param name="builder">The builder through which components can be registered.</param>
        /// <remarks>
        /// Note that the ContainerBuilder parameter is unique to this module.
        /// </remarks>
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            RegisterAutoMapper(builder);
            builder.RegisterType<RandomOptionGenerator>().As<IRandomOptionGenerator>();
            builder.RegisterType<GameRpslsValidator>().As<IGameRpslsValidator>();
            builder.RegisterType<GameCalculatorService>().As<IGameCalculatorService>();
            builder.RegisterType<GameService>().As<IGameService>();
        }

        public static void RegisterAutoMapper(ContainerBuilder builder)
        {
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfiler()));
            var mapper = mapperConfiguration.CreateMapper();
            builder.Register(c => mapper).As<IMapper>().SingleInstance();
        }
    }
}
