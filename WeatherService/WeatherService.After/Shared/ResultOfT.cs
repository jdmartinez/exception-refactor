namespace WeatherService.After.Shared
{
    public class Result<T> : IResult<T>
    {
        public T Value { get; } = default!;

        public bool IsSuccess { get; }

        public bool IsFailure => !IsSuccess;

        public Error Error { get; } = Error.None;

        public Result(T value)
        {
            IsSuccess = true;
            Value = value;
        }

        public Result(Error error)
        {
            IsSuccess = false;
            Error = error;
        }

        public static implicit operator T(Result<T> result) => result.Value;

        public static implicit operator Result<T>(T value) => new(value);

        public static implicit operator Result<T>(Error error) => new(error);

        public static Result<T> Success(T  value) => new(value);

        public static Result<T> Failure(Error error) => new(error);

        public TReturn Match<TReturn>(Func<Error, TReturn> onFailure, Func<T, TReturn> onSuccess)
            => IsSuccess ? onSuccess(Value) : onFailure(Error);
    }
}
