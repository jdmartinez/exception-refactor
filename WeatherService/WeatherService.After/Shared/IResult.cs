namespace WeatherService.After.Shared
{
    public interface IResult
    {
        bool IsSuccess { get; }

        bool IsFailure { get; }

        Error Error { get; }
    }

    public interface IResult<T> : IResult
    {
        T Value { get; }
    }
}
