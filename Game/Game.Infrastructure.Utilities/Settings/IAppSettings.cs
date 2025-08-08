namespace Game.Infrastructure.Utilities.Settings
{
    /// <summary>
    /// Application settings contains settings from appSettings json
    /// </summary>
    public interface IAppSettings
    {
        /// <summary>
        /// Gets or sets the name of the data provider DLL.
        /// </summary>
        /// <value>
        /// The name of the data provider DLL.
        /// </value>
        /// {
        string DataProviderDllName { get; }

        /// <summary>
        /// Gets or sets the data provider DLL root.
        /// </summary>
        /// <value>
        /// The data provider DLL root.
        /// </value>
        string DataProviderDllRoot { get; }

        /// <summary>
        /// Gets or sets the name of the service DLL.
        /// </summary>
        /// <value>
        /// The name of the service DLL.
        /// </value>
        string ServiceDllName { get; }

        /// <summary>
        /// Gets or sets the service DLL root.
        /// </summary>
        /// <value>
        /// The service DLL root.
        /// </value>
        string ServiceDllRoot { get; }
        /// <summary>
        /// Gets or sets the enabled cors uris.
        /// </summary>
        /// <value>
        /// The enabled cors uris.
        /// </value>
        public string[] EnabledCorsUris { get; set; }
    }
}
