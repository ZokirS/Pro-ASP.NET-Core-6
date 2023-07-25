using _14_Dependency_Injection.Platform.Services;

namespace _14_Dependency_Injection.Platform
{
    public class WeatherMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private IResponseFormatter _formatter;

        public WeatherMiddleware(RequestDelegate request, IResponseFormatter formatter)
        {
            _requestDelegate = request;
            _formatter = formatter;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path == "/middleware/class")
                await _formatter.Format(context,"Middleware class: It's rainig in London");
            else
                await _requestDelegate(context);
        }
    }
}
