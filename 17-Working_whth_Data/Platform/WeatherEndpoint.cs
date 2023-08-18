using _17_Working_whth_Data.Platform.Services;

namespace _14_Dependency_Injection.Platform
{
    public class WeatherEndpoint
    {
        //private readonly IResponseFormatter _responseFormatter;

        //public WeatherEndpoint(IResponseFormatter responseFormatter)
        //    => _responseFormatter = responseFormatter;
        

        public async Task Endpoint(HttpContext context, IResponseFormatter formatter)
        {
            await formatter.Format(context, "Endpoint Class: dasda");
        }
    }
}
