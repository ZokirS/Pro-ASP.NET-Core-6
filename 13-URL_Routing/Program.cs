using _13_URL_Routing.Platform;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//Creating Custom Constraints
builder.Services.Configure<RouteOptions>(opts =>
{
    opts.ConstraintMap.Add("countryName",
        typeof(CountryRouteConstraint));
});
var app = builder.Build();

//app.UseMiddleware<Population>();
//app.UseMiddleware<Capital>();

//more segments
//app.MapGet("{first}/{second}/{*catchall}", async context =>
//{
//    await context.Response.WriteAsync("Request was routed\n");
//    foreach (var kvp in context.Request.RouteValues)
//        await context.Response.WriteAsync($"{kvp.Key}: {kvp.Value}\n");
//});

//Accessing the Endpoint in a Middleware Component
app.Use(async (context, next) =>
{
    Endpoint? end = context.GetEndpoint();
    if (end != null)
        await context.Response
        .WriteAsync($"{end.DisplayName} Seleted\n");
    else
        await context.Response.WriteAsync("No endpoint selected\n");
    await next();
});

//Ambiguous Match Exception
app.Map("{number:int}", async context =>
{
    await context.Response.WriteAsync("Routed to the int endpoint");
}).WithDisplayName("With Int endpoint").Add(b => ((RouteEndpointBuilder)b).Order = 1);
app.Map("{number:double}", async context =>
{
    await context.Response
    .WriteAsync("Routed to the double endpoint");
}).WithDisplayName("With Double endpoint").Add(b => ((RouteEndpointBuilder)b).Order = 2);


//Creating Custom Constraints
app.MapGet("capital/{country:countryName}", Capital.Endpoint);

//segments constraints
app.MapGet("{first:int}/{second:bool}", async context =>
{
    await context.Response.WriteAsync("Request was routed\n");
    foreach (var kvp in context.Request.RouteValues)
        await context.Response.WriteAsync($"{kvp.Key}: {kvp.Value}\n");
});

app.MapGet("routing", async context =>
    {
        await context.Response.WriteAsync("URL was redirected");
    });
    //app.MapGet("capital/{country=France}", Capital.Endpoint);
    app.MapGet("size/{city?}", Population.Endpoint)
    .WithMetadata(new RouteNameMetadata("population"));



/*app.Run(async (context) =>
{
    await context.Response.WriteAsync("Terminal Middleware Reached");
});
*/
//Defining Fallback Routes
app.MapFallback(async context => {
    await context.Response.WriteAsync("Routed to fallback endpoint");
});
app.Run();
