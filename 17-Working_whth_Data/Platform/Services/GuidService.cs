namespace _17_Working_whth_Data.Platform.Services
{
    public class GuidService : IResponseFormatter
    {
        private Guid guid = Guid.NewGuid();
        public async Task Format(HttpContext context, string content)
        {
            await context.Response.WriteAsync($"Guid: {guid}\n{content}");
        }
    }
}
