using _14_Dependency_Injection.Platform.Services;

namespace _14_Dependency_Injection.Platform
{
    public class WeatherEndpoint
    {
        public static async Task Endpoint(HttpContext context)
        {
            IResponseFormatter formatter =
                context.RequestServices.GetRequiredService<IResponseFormatter>();
            await formatter.Format(context, "Endpoint Class: dasda");
        }
    }
}
