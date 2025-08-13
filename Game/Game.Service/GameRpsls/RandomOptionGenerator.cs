using Game.Domain.DTO.GameRpsls.InternalModels;
using Game.Infrastructure.Utilities.Enums.Rpsls;
using Game.Infrastructure.Utilities.ErrorHandling;
using Game.Infrastructure.Utilities.ErrorHandling.ConcreteErrors.GameRpsls;
using Game.Infrastructure.Utilities.Helpers;
using Game.Infrastructure.Utilities.Settings;
using Game.Service.Abstractions.GameRpsls;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Polly.RateLimiting;

namespace Game.Service.GameRpsls
{
    /// <summary>
    /// Class for generating random game choice
    /// </summary>
    internal class RandomOptionGenerator : IRandomOptionGenerator  //TODO refactor entiry class
    {
        /// <summary>
        /// Interface to Factory class for creating Http client
        /// </summary>
        private readonly IHttpClientFactory _factory;
        /// <summary>
        /// Interface to settings read from appSettings.json
        /// </summary>
        private readonly IExternalApiUrls _externalApiUrls;
        /// <summary>
        /// Logger
        /// </summary>
        private readonly ILogger<RandomOptionGenerator> _logger;
        /// <summary>
        /// Named http client
        /// </summary>
        private const string HttpClientCodeChallenge = "CodeChallenge";

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factory"></param>
        /// <param name="externalApiUrls"></param>
        /// <param name="logger"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public RandomOptionGenerator(IHttpClientFactory factory, IExternalApiUrls externalApiUrls, ILogger<RandomOptionGenerator> logger)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
            _externalApiUrls = externalApiUrls ?? throw new ArgumentNullException(nameof(externalApiUrls));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Return randomly chosen game option
        /// </summary>
        /// <returns>Enum value of <see cref="GameRpslsChoice"/></returns>
        public async Task<Result<GameRpslsChoice>> GenerateRandomOptionAsync()
        {
            _logger.LogInformation(LogMessageBuilder.GetStartedMethodMessage());

            var relativeUrlPath = _externalApiUrls.UrlRandomNumberGenerator;
            
            //TODO check settings while starting app
            //if (string.IsNullOrEmpty(relativeUrlPath))
            //{
            //    throw new Exception("URL configuration for random number generator endpoint is not set in appSettings.json.");
            //}

            double random = 0;

            string responseMessage;
            int responseStatusCode;
            try
            {
                using var client = _factory.CreateClient(HttpClientCodeChallenge);
                {
                    var response = await client.GetAsync(relativeUrlPath);
                    response.EnsureSuccessStatusCode();

                    responseMessage = await response.Content.ReadAsStringAsync();
                    responseStatusCode = (int)response.StatusCode;
                }
                _logger.LogInformation(LogMessageBuilder.GetHttpRequestSucceededMessage(responseStatusCode,responseMessage));

                var randomNumberExternal = JsonConvert.DeserializeObject<RandomNumberResponse>(responseMessage);

                if (randomNumberExternal == null || randomNumberExternal.Random_number > 100 ||
                    randomNumberExternal.Random_number < 0)
                {
                    var result =
                        Result.Failure<GameRpslsChoice>(RandomNumberGeneratorErrors.RandomNumberInvalidValue());
                    _logger.LogError(LogMessageBuilder.GetErrorMessage(result.Error.Message));
                    return result;
                }

                random = Math.Ceiling((double)randomNumberExternal.Random_number / 20);
            }
            catch (TaskCanceledException te)
            {
                var result = Result.Failure<GameRpslsChoice>(RandomNumberGeneratorErrors.RandomNumberServiceTimeout());
                _logger.LogError(result.Error.Message);
                return result;
            }
            catch (RateLimiterRejectedException rateLimiterException)
            {
                var result = Result.Failure<GameRpslsChoice>(RandomNumberGeneratorErrors.RandomNumberToManyRequests());
                _logger.LogError(LogMessageBuilder.GetErrorMessage(result.Error.Message));
                return result;
            }
            catch (Exception e)
            {
                var result = Result.Failure<GameRpslsChoice>(RandomNumberGeneratorErrors.RandomNumberServiceError());
                _logger.LogError(LogMessageBuilder.GetErrorMessage($"{result.Error.Message}. Exception: {e.Message}"));
                return result;
            }

            _logger.LogInformation(LogMessageBuilder.GetFinishedMethodMessage());

            return Result.Success((GameRpslsChoice)random);
        }
    }
}
