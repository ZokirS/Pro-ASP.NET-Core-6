namespace _13_URL_Routing.Platform
{
    public class Capital
    {
    //    private RequestDelegate next;

    //    public Capital(){}

    //    public Capital(RequestDelegate request)
    //        => next = request;

        public static async Task Endpoint(HttpContext context)
        {
            string? capital = null;
            string? country = context.Request.RouteValues["country"] as string;
            switch((country ?? "").ToLower())
            {
                case "uk":
                    capital = "london";
                    break;
                case "france":
                    capital = "paris";
                    break;
                case "monaco":
                    LinkGenerator? linkGenerator =
                        context.RequestServices.GetService<LinkGenerator>();
                    string? url = linkGenerator?.GetPathByRouteValues(context,
                        "population", new { city = country });
                    if (url != null) 
                        context.Response.Redirect(url);
                    return;
            }
            if (capital != null)
                await context.Response.WriteAsync($"{capital} is capital of {country}");
            else
                context.Response.StatusCode = StatusCodes.Status404NotFound;
        }
    }
}
