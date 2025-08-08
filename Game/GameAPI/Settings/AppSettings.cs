using Game.Infrastructure.Utilities.Settings;

namespace GameAPI.Settings
{

    /// <summary>
    /// Settings from appSettings.json
    /// </summary>
    internal class AppSettings : IAppSettings
    {
        /// <summary>
        /// Gets or sets the name of the data provider DLL.
        /// </summary>
        /// <value>
        /// The name of the data provider DLL.
        /// </value>
        /// {
        public string DataProviderDllName { get; set; }

        /// <summary>
        /// Gets or sets the data provider DLL root.
        /// </summary>
        /// <value>
        /// The data provider DLL root.
        /// </value>
        public string DataProviderDllRoot { get; set; }

        /// <summary>
        /// Gets or sets the name of the service DLL.
        /// </summary>
        /// <value>
        /// The name of the service DLL.
        /// </value>
        public string ServiceDllName { get; set; }

        /// <summary>
        /// Gets or sets the service DLL root.
        /// </summary>
        /// <value>
        /// The service DLL root.
        /// </value>
        public string ServiceDllRoot { get; set; }

        /// <summary>
        /// Gets or sets the enabled cors uris.
        /// </summary>
        /// <value>
        /// The enabled cors uris.
        /// </value>
        public string[] EnabledCorsUris { get; set; }
    }
}