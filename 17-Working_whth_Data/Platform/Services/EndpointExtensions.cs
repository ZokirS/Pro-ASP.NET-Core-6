using System.Reflection;

namespace _17_Working_whth_Data.Platform.Services
{
    public static class EndpointExtensions
    {
        public static void MapEndpoint<T>(this IEndpointRouteBuilder app, string path, string methodName = "Endpoint")
        {
            MethodInfo? methodInfo = typeof(T).GetMethod(methodName);
            if (methodInfo == null || methodInfo.ReturnType != typeof(Task))
                throw new Exception("Method cannot be used");

            T endpointInstance = ActivatorUtilities.CreateInstance<T>(app.ServiceProvider);

            ParameterInfo[] parameters = methodInfo!.GetParameters();

            app.MapGet(path, context =>
            {
                T endpointInstance =
                ActivatorUtilities.CreateInstance<T>(context.RequestServices);
                return (Task)methodInfo.Invoke(endpointInstance!,
                    parameters.Select(p => p.ParameterType == typeof(HttpContext)
                    ? context
                    : context.RequestServices.GetService(p.ParameterType)).ToArray())!;
            });
        }
    }
}
