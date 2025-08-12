using System.Net.Http.Headers;
using Game.Domain.DTO.GameRpsls.InternalModels;
using Game.Infrastructure.Utilities.Enums.Rpsls;
using Game.Infrastructure.Utilities.Settings;
using Game.Service.Abstractions.GameRpsls;
using Newtonsoft.Json;

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
        /// Named http client
        /// </summary>
        private const string HttpClientCodeChallenge = "CodeChallenge";

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factory"></param>
        /// <param name="externalApiUrls"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public RandomOptionGenerator(IHttpClientFactory factory, IExternalApiUrls externalApiUrls)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
            _externalApiUrls = externalApiUrls ?? throw new ArgumentNullException(nameof(externalApiUrls));
        }

        /// <summary>
        /// Return randomly chosen game option
        /// </summary>
        /// <returns>Enum value of <see cref="GameRpslsChoice"/></returns>
        public async Task<GameRpslsChoice> GenerateRandomOptionAsync()
        {
            var relativeUrlPath = _externalApiUrls.UrlRandomNumberGenerator;

            if (string.IsNullOrEmpty(relativeUrlPath))
            {
                throw new Exception("URL configuration for random number generator endpoint is not set in appSettings.json.");
            }

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

                var randomNumberExternal = JsonConvert.DeserializeObject<RandomNumberResponse>(responseMessage);

                if (randomNumberExternal == null || randomNumberExternal.Random_number > 100 ||
                    randomNumberExternal.Random_number < 0)
                {
                    throw new Exception("Invalid response from external service for generating random number");
                }

                random = Math.Ceiling((double)randomNumberExternal.Random_number / 20);
            }
            catch (TaskCanceledException te)
            {
                //TODO
            }
            catch (Exception e)
            {
                //TODO
            }

            return (GameRpslsChoice)random;
        }
    }
}
