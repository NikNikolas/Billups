using Autofac;
using Game.Domain.Data.Abstractions.Repositories.GameRpsls;
using Game.Infrastructure.Data.DataContext;
using Game.Infrastructure.Data.Repositories.GameRpsls;
using Microsoft.EntityFrameworkCore;

namespace Game.Infrastructure.Data.Modules
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="Autofac.Module" />
    public class DataModule : Module
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
            RegisterRepository(builder);
            RegisterInMemoryEFDatabase(builder);
        }

        /// <summary>
        /// Registers the repository.
        /// </summary>
        /// <param name="builder">The builder.</param>
        private static void RegisterRepository(ContainerBuilder builder)
        {
            builder.RegisterType<ChoiceRepository>().As<IChoiceRepository>();
            builder.RegisterType<GameResultHistoryRepository>().As<IGameResultHistoryRepository>();
        }

        /// <summary>
        /// Registers entity framework inMemory database
        /// </summary>
        /// <param name="builder">The builder.</param>
        private static void RegisterInMemoryEFDatabase(ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                var opt = new DbContextOptionsBuilder<AppDbContext>();
                opt.UseInMemoryDatabase("LocalDb");

                var dbContext = new AppDbContext(opt.Options);

                dbContext.Database.EnsureCreated();
                return dbContext;
            }).AsSelf().InstancePerLifetimeScope();
        }
    }
}
