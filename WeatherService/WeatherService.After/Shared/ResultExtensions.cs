namespace WeatherService.After.Shared
{
    public static class ResultExtensions
    {
        public static Microsoft.AspNetCore.Http.IResult ToHttpResult<T>(this Result<T> result)
            => result.Match(
                    onFailure: error => Results.StatusCode(error.Code),
                    onSuccess: Results.Ok);
    }
}
