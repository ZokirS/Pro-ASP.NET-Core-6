namespace _14_Dependency_Injection.Platform
{
    public class WeatherEndpoint
    {
        public static async Task Endpoint(HttpContext context)
        {
            await context.Response
                .WriteAsync("Endpoint class: It is cloudy in Milan");
        }
    }
}
