namespace _14_Dependency_Injection.Platform.Services
{
    public class TypeBroker
    {
        private static IResponseFormatter formatter = new HtmlResponseFormatter();

        public static IResponseFormatter Formatter => formatter;
    }
}
