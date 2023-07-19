namespace _13_URL_Routing.Platform
{
    public class Population
    {
        public static async Task Endpoint(HttpContext context)
        {
            string? city = context.Request.RouteValues["city"] as string ?? "london";
            int? pop = null;
            switch((city ?? "").ToLower())
            {
                case "london":
                    pop = 8_132_000;
                    break;
                case "paris":
                    pop = 4_000_000;
                    break;
                case "monaco":
                    pop = 39_000;
                    break;
            }
            if (pop.HasValue)
                await context.Response
                    .WriteAsync($"City: {city}, population: {pop}");
            else
                context.Response.StatusCode = StatusCodes.Status404NotFound;
            
        }
        
    }
}
