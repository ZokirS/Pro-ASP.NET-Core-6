namespace _17_Working_whth_Data.Platform.Services
{
    public class TypeBroker
    {
        private static IResponseFormatter formatter = new HtmlResponseFormatter();

        public static IResponseFormatter Formatter => formatter;
    }
}
