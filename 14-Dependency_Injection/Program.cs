using _14_Dependency_Injection.Platform;
using _14_Dependency_Injection.Platform.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton<IResponseFormatter, HtmlResponseFormatter>();
var app = builder.Build();

app.UseMiddleware<WeatherMiddleware>();
//IResponseFormatter formatter = new TextResponseFormatter();
//app.MapGet("middleware/function", async (context) =>
//{
//    await formatter.Format(context, "Middleware endpoint: It is raining in Chicago");
//});
//app.MapGet("endpoint/class", WeatherEndpoint.Endpoint);

//app.MapGet("endpoint/function", async (context) =>
//{
//    await context.Response.WriteAsync("Endpoint function: It is sunny in LA");
//});


//Singleton
//app.MapGet("middleware/function", async (context) => {
//    await TextResponseFormatter.Singleton.Format(context,
//    "Middleware Function: It is snowing in Chicago");
//});
//app.MapGet("endpoint/class", WeatherEndpoint.Endpoint);
//app.MapGet("endpoint/function", async context => {
//    await TextResponseFormatter.Singleton.Format(context,
//    "Endpoint Function: It is sunny in LA");
//});

//app.MapGet("middleware/function", async (context) =>
//{
//    await TypeBroker.Formatter.Format(context, "Middleware function: rain in Chicago");
//});

//app.MapGet("endpoint/function", async (context) =>
//{
//    await TypeBroker.Formatter.Format(context, "Endpoint function: rain in Chicago");
//});

//Using Dependency Injection

app.MapGet("middleware/function", async (HttpContext context,
    IResponseFormatter formatter) =>
{
    await formatter.Format(context, "Middleware function: rain in Chicago");
});

app.MapGet("endpoint/function", async (HttpContext context,
    IResponseFormatter formatter) =>
{
    await formatter.Format(context, "Endpoint function: rain in Chicago");
});
//app.MapGet("endpoint/class", WeatherEndpoint.Endpoint);
//app.MapWeather("endpoint/class");
app.MapWeather<WeatherEndpoint>("endpoint/class");
app.Run();
