using _13_URL_Routing.Platform;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

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
    app.MapGet("capital/{country=France}", Capital.Endpoint);
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
