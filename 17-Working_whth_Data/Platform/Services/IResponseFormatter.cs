namespace _17_Working_whth_Data.Platform.Services
{
    public interface IResponseFormatter
    {
        Task Format(HttpContext context, string content);

        public bool RichOutput => false;
    }
}
