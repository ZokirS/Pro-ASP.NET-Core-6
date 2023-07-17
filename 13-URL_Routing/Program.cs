using _13_URL_Routing.Platform;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

//app.UseMiddleware<Population>();
//app.UseMiddleware<Capital>();


app.MapGet("{first}/{second}/{third}", async context =>
{
    await context.Response.WriteAsync("Request was routed\n");
    foreach (var kvp in context.Request.RouteValues)
        await context.Response.WriteAsync($"{kvp.Key}: {kvp.Value}\n");
});

    app.MapGet("routing", async context =>
    {
        await context.Response.WriteAsync("URL was redirected");
    });
    app.MapGet("capital/uk", new Capital().Invoke);
    app.MapGet("population/paris", new Population().Invoke);


/*app.Run(async (context) =>
{
    await context.Response.WriteAsync("Terminal Middleware Reached");
});
*/
app.Run();
