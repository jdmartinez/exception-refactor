using System.Runtime.CompilerServices;

namespace WeatherService.After.Shared
{
    public static class ResultExtensions
    {
        public static Microsoft.AspNetCore.Http.IResult ToHttpResult<T>(this IResult<T> result)
            => result.IsSuccess ? Results.Ok(result.Value) : Results.StatusCode(result.Error.Code);
    }
}
