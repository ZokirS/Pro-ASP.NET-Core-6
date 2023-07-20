namespace _14_Dependency_Injection.Platform
{
    public class WeatherMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public WeatherMiddleware(RequestDelegate request)
        {
            _requestDelegate = request;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path == "/middleware/class")
                await context.Response
                    .WriteAsync("Middleware class: It's rainig in London");
            else
                await _requestDelegate(context);
        }
    }
}
