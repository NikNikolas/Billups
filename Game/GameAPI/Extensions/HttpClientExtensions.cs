using GameAPI.Settings.Resilience;
using System.Threading.RateLimiting;
using Microsoft.Extensions.Http.Resilience;
using Polly;
using Polly.Timeout;
using Game.Infrastructure.Utilities.Settings.HttpClientSettings.Base;
using GameAPI.Settings;

namespace GameAPI.Extensions
{
    /// <summary>
    /// Register HttpClient with Polly 
    /// </summary>
    public static class HttpClientExtensions
    {
        private const string NamedHttpClient = "CodeChallenge";

        public static void AddInternalMigrationHttpClient(this IServiceCollection services,
            Microsoft.Extensions.Configuration.IConfiguration configurations)
        {
            ResilienceStrategySettings resilienceSettings = new ResilienceStrategySettings();
            configurations.GetSection(typeof(ResilienceStrategySettings).Name).Bind(resilienceSettings);

            IExternalApiSettings httpSettings = new ExternalApiSettings();
            configurations.GetSection(typeof(ExternalApiSettings).Name).Bind(httpSettings);
            
            

            var concreteSettings = httpSettings.GetCustomSettings(NamedHttpClient);

            if (!resilienceSettings.UseStandardStrategy)
            {
                services.AddHttpClient(NamedHttpClient, client =>
                {
                    client.BaseAddress = new Uri(concreteSettings.Host);
                    client.Timeout = TimeSpan.FromSeconds(concreteSettings.TimeoutInSeconds);

                    if (concreteSettings.MandatoryHeaders != null && concreteSettings.MandatoryHeaders.Any())
                    {
                        foreach (var header in concreteSettings.MandatoryHeaders)
                        {
                            client.DefaultRequestHeaders.Add(header.Key, header.Value);
                        }
                    }
                });
            }
            else
            {
                var rateLimiter = new FixedWindowRateLimiter(
                    new FixedWindowRateLimiterOptions
                    {
                        PermitLimit = resilienceSettings.RateLimiter.PermitLimit,
                        QueueLimit = resilienceSettings.RateLimiter.QueueLimit,
                        Window = TimeSpan.FromSeconds(resilienceSettings.RateLimiter.PeriodInSeconds)
                    });

                services.AddHttpClient(NamedHttpClient, client =>
                    {
                        client.BaseAddress = new Uri(concreteSettings.Host);
                        client.Timeout = TimeSpan.FromSeconds(concreteSettings.TimeoutInSeconds);

                        if (concreteSettings.MandatoryHeaders != null && concreteSettings.MandatoryHeaders.Any())
                        {
                            foreach (var header in concreteSettings.MandatoryHeaders)
                            {
                                client.DefaultRequestHeaders.Add(header.Key, header.Value);
                            }
                        }
                    })
                    .AddStandardResilienceHandler(options =>
                    {

                        options.RateLimiter = new HttpRateLimiterStrategyOptions
                        {
                            RateLimiter = args => rateLimiter.AcquireAsync(cancellationToken: args.Context.CancellationToken)
                        };

                        options.AttemptTimeout.Timeout = TimeSpan.FromSeconds(resilienceSettings.AttemptTimoutInSeconds); //default: 10
                        options.TotalRequestTimeout.Timeout = TimeSpan.FromSeconds(resilienceSettings.TotalTimoutInSeconds); //default: 30

                        options.CircuitBreaker.SamplingDuration = TimeSpan.FromSeconds(resilienceSettings.CircuitBreaker.SamplingDurationInSeconds); //default: 30
                        options.CircuitBreaker.FailureRatio = resilienceSettings.CircuitBreaker.FailureRatio; //default: 0.1
                        options.CircuitBreaker.MinimumThroughput = resilienceSettings.CircuitBreaker.MinimumThroughput; //default: 100
                        options.CircuitBreaker.BreakDuration = TimeSpan.FromSeconds(resilienceSettings.CircuitBreaker.BreakDurationInSeconds); //default: 5
                        options.CircuitBreaker.ShouldHandle = new PredicateBuilder<HttpResponseMessage>()
                            .Handle<HttpRequestException>() // Includes any HttpRequestException
                            .Handle<TimeoutRejectedException>() // Includes any HttpRequestException
                            .HandleResult(response => !response.IsSuccessStatusCode); // Includes non-successful responses

                        options.Retry.DisableForUnsafeHttpMethods();
                        options.Retry.MaxRetryAttempts = resilienceSettings.Retry.MaxRetryAttempts; //default: 3
                        options.Retry.Delay = TimeSpan.FromSeconds(resilienceSettings.Retry.DelayInSeconds); //default: 2
                        options.Retry.BackoffType = DelayBackoffType.Constant; //default: Exponential
                        options.Retry.UseJitter = resilienceSettings.Retry.UseJitter; //default: true
                        options.Retry.ShouldHandle = new PredicateBuilder<HttpResponseMessage>() // Defines exceptions to trigger retries
                                .Handle<HttpRequestException>() // Includes any HttpRequestException
                                .Handle<TimeoutRejectedException>() // Includes any HttpRequestException
                                .HandleResult(response => !response.IsSuccessStatusCode); // Includes non-successful responses
                    });
            }
        }
    }
}
