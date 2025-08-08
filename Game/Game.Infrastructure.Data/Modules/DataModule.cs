using Autofac;

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
        }

        /// <summary>
        /// Registers the repository.
        /// </summary>
        /// <param name="builder">The builder.</param>
        private static void RegisterRepository(ContainerBuilder builder)
        {
        }
    }
}
