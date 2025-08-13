namespace GameAPI.Settings.Resilience
{
    /// <summary>
    /// Resilience strategy configuration
    /// </summary>
    public class ResilienceStrategySettings
    {
        /// <summary>
        /// Should Resilience strategy by applied
        /// </summary>
        public bool UseStandardStrategy { get; set; }
        /// <summary>
        /// Configuration for <see cref="RateLimiter"/>
        /// </summary>
        public RateLimiter RateLimiter { get; set; }
        /// <summary>
        /// Maximum duration of each request
        /// </summary>
        public int AttemptTimoutInSeconds { get; set; }
        /// <summary>
        /// Maximum duration of all requests (with retry)
        /// </summary>
        public int TotalTimoutInSeconds { get; set; }
        /// <summary>
        /// Configuration for <see cref="CircuitBreaker"/>
        /// </summary>
        public CircuitBreaker CircuitBreaker { get; set; }
        /// <summary>
        /// Configuration for <see cref="Retry"/>
        /// </summary>
        public Retry Retry { get; set; }
    }
}
