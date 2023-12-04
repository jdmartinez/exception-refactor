using System.Text.Json.Serialization;

namespace WeatherService.Before.Application
{
    public class MainWeatherData
    {
        public float Temp { get; set; }

        [JsonPropertyName("feels_like")]
        public float FeelsLike { get; set; }
    }

    public class OpenWeatherMapResponse
    {
        public MainWeatherData Main { get; set; } = default!;
    }
}
