using _14_Dependency_Injection.Platform.Services;

namespace _14_Dependency_Injection.Platform
{
    public class WeatherEndpoint
    {
        private readonly IResponseFormatter _responseFormatter;

        public WeatherEndpoint(IResponseFormatter responseFormatter)
            => _responseFormatter = responseFormatter;
        

        public async Task Endpoint(HttpContext context)
        {
            await _responseFormatter.Format(context, "Endpoint Class: dasda");
        }
    }
}
