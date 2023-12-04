namespace WeatherService.Before.Application
{
    public interface IWeatherService
    {
        Task<WeatherData?> GetWeatherData(string city);
    }
}
