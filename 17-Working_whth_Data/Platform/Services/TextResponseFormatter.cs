namespace _14_Dependency_Injection.Platform.Services
{
    public class TextResponseFormatter : IResponseFormatter
    {
        private int responseCount = 0;
        private static TextResponseFormatter? shared;
        public async Task Format(HttpContext context, string content)
        {
            await context.Response
                .WriteAsync($"Response {++responseCount}: \n{content}");
        }

        public static IResponseFormatter Singleton
        {
            get
            {
                if (shared == null)
                    shared = new TextResponseFormatter();
                return shared;
            }
        }
    }
}
