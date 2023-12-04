using System.Net;
using WeatherService.After.Domain;
using WeatherService.After.Shared;

namespace WeatherService.Before.Application
{
    public class OpenWeatherMapService : IWeatherService
    {
        private const string ApiKey = "8af92e53ff88b48f1db0b455fbea99b4";

        private readonly IHttpClientFactory _httpClientFactory = default!;
        private readonly ILogger<OpenWeatherMapService> _logger = default!;

        public OpenWeatherMapService(IHttpClientFactory httpClientFactory, ILogger<OpenWeatherMapService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<Result<WeatherData>> GetWeatherData(string city)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={ApiKey}&units=metric";

                var response = await client.GetAsync(url);

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return new ErrorCityNotFound();
                }

                var weather = await response.Content.ReadFromJsonAsync<OpenWeatherMapResponse>();

                return new WeatherData(weather!.Main.Temp, weather.Main.FeelsLike);
            }
            catch
            {
                throw;
            }
        }

    }
}
