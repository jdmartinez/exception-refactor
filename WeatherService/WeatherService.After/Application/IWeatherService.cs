using WeatherService.After.Shared;

namespace WeatherService.Before.Application
{
    public interface IWeatherService
    {
        Task<Result<WeatherData>> GetWeatherData(string city);
    }
}
