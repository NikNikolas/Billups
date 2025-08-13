namespace GameAPI.Settings.Resilience
{
    /// <summary>
    /// Settings for Rate limiter resilience strategy configuration
    /// </summary>
    public class RateLimiter
    {
        /// <summary>
        /// Maximum number of allowed request for specified period
        /// </summary>
        public int PermitLimit { get; set; }
        /// <summary>
        /// Maximum request number in queue for specified period
        /// </summary>
        public int QueueLimit { get; set; }
        /// <summary>
        /// Period for monitoring number of requests
        /// </summary>
        public int PeriodInSeconds { get; set; }
    }
}
