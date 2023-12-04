namespace WeatherService.Before.Domain
{
    public class CityNotFoundException : Exception
    {
        public CityNotFoundException() : base()
        { }

        public CityNotFoundException(string? message) : base(message)
        { }

        public CityNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        { }
    }
}
