namespace GameAPI.Settings.Resilience
{
    /// <summary>
    /// Settings for Retry resilience strategy configuration
    /// </summary>
    public class Retry
    {
        /// <summary>
        /// Maximum number of retries requests
        /// </summary>
        public int MaxRetryAttempts { get; set; }
        /// <summary>
        /// Delay for the next retry attempt
        /// </summary>
        public int DelayInSeconds { get; set; }
        /// <summary>
        /// Use random function for delaying next request
        /// </summary>
        public bool UseJitter { get; set; }
    }
}
