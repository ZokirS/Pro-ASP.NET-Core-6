using _14_Dependency_Injection.Platform.Services;

namespace _14_Dependency_Injection.Platform
{
    public class WeatherMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
       // private IResponseFormatter _formatter;

        public WeatherMiddleware(RequestDelegate request)
        {
            _requestDelegate = request;
        }

        public async Task Invoke(HttpContext context, IResponseFormatter formatter1,
            IResponseFormatter formatter2, IResponseFormatter formatter3)
        {
            if (context.Request.Path == "/middleware/class")
            {
                await formatter1.Format(context, string.Empty);
                await formatter2.Format(context, string.Empty);
                await formatter3.Format(context, string.Empty);
            }
            else
                await _requestDelegate(context);
        }
    }
}
