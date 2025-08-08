namespace GameAPI.Settings.Abstractions
{
    /// <summary>
    /// Application settings contains settings from appSettings.json
    /// </summary>
    public interface ISwaggerUISettings
    {
        /// <summary>
        /// Gets or sets the url.
        /// </summary>
        /// <value>
        /// The url.
        /// </value>
        public string Url { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
    }
}
