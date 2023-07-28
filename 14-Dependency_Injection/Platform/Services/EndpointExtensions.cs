using System.Reflection;

namespace _14_Dependency_Injection.Platform.Services
{
    public static class EndpointExtensions
    {
        public static void MapWeather<T>(this IEndpointRouteBuilder app, string path, string methodName = "Endpoint")
        {
            MethodInfo? methodInfo = typeof(T).GetMethod(methodName);
            if (methodInfo == null || methodInfo.ReturnType != typeof(Task))
                throw new Exception("Method cannot be used");

            T endpointInstance = ActivatorUtilities.CreateInstance<T>(app.ServiceProvider);
            app.MapGet(path, (RequestDelegate)
                methodInfo.CreateDelegate(typeof(RequestDelegate), endpointInstance));
        }
    }
}
