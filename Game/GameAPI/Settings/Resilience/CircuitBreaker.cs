namespace GameAPI.Settings.Resilience
{
    /// <summary>
    /// Settings for circuit breaker resilience strategy configuration
    /// </summary>
    public class CircuitBreaker
    {
        /// <summary>
        /// Period for request analyze related with CircuitBreaker activation logic
        /// </summary>
        public int SamplingDurationInSeconds { get; set; }
        /// <summary>
        /// Percentage of requests that should fail to active CircuitBreaker. 0.1 => 10%
        /// </summary>
        public double FailureRatio { get; set; }
        /// <summary>
        /// Minimum requests for Circuit Breaker activation
        /// </summary>
        public int MinimumThroughput { get; set; }
        /// <summary>
        /// Pause from sending new requests in seconds
        /// </summary>
        public int BreakDurationInSeconds { get; set; }
    }
}
