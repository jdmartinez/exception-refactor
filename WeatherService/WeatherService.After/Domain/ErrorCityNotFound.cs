using WeatherService.After.Shared;

namespace WeatherService.After.Domain
{
    public record ErrorCityNotFound : Error
    {
        public ErrorCityNotFound() : base(404, "City not found")
        { }
    }
}
