namespace GameAPI.Extensions
{
    public static class HostEnvironmentExtensions
    {
        /// <summary>
        /// Determines whether this instance is dev.
        /// </summary>
        /// <param name="hostEnvironment">The host environment.</param>
        /// <returns>
        ///   <c>true</c> if the specified host environment is dev; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">hostEnvironment</exception>
        public static bool IsDev(this IHostEnvironment hostEnvironment)
        {
            if (hostEnvironment == null)
            {
                throw new ArgumentNullException(nameof(hostEnvironment));
            }

            return hostEnvironment.IsEnvironment("Dev");
        }
    }
}
