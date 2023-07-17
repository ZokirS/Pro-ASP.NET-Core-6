namespace _13_URL_Routing.Platform
{
    public class Population
    {
        private RequestDelegate next;
        public Population() {}

        public Population(RequestDelegate requestDelegate)
            => next = requestDelegate;
        
        public async Task Invoke(HttpContext context)
        {
            string[] parts = context.Request.Path.ToString()
                .Split("/", StringSplitOptions.RemoveEmptyEntries);

            if(parts.Length ==2 && parts[0] == "population")
            {
                string city = parts[1];
                int? pop = null;
                switch(city.ToLower())
                {
                    case "london":
                        pop = 8_136_000;
                        break;
                    case "paris":
                        pop = 2_141_000;
                        break;
                    case "monaco":
                        pop = 89000;
                        break;
                }
                if (pop.HasValue)
                {
                    await context.Response.WriteAsync($"City: {city}, population: {pop}");
                    return;
                }
            }
            if(next != null)
            {
                await next(context);
            }
        }
    }
}
