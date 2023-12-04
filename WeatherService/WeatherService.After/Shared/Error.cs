namespace WeatherService.After.Shared
{
    public record Error(int Code, string Message = "")
    {
        public static readonly Error None = new(200, string.Empty);
        
    }

}
