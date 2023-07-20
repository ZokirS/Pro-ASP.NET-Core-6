namespace _14_Dependency_Injection.Platform.Services
{
    public interface IResponseFormatter
    {
        Task Format(HttpContext context, string content);
    }
}
