namespace GameAPI.Settings.Abstractions
{
    /// <summary>
    /// Application settings contains settings from appSettings json
    /// </summary>
    public interface ISwaggerSettings
    {
        /// <summary>
        /// Gets or sets the JsonRoute.
        /// </summary>
        /// <value>
        /// The JsonRoute.
        /// </value>
        public string JsonRoute { get; set; }

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        /// <value>
        /// The Description.
        /// </value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the UIEndpoint.
        /// </summary>
        /// <value>
        /// The UIEndpoint.
        /// </value>
        public string UIEndpoint { get; set; }
    }
}
