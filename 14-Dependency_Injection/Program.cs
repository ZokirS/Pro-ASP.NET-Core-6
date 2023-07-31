using _14_Dependency_Injection.Platform;
using _14_Dependency_Injection.Platform.Services;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IResponseFormatter, GuidService>();

//Using Service Factory Functions

IConfiguration config = builder.Configuration;

//builder.Services.AddScoped<IResponseFormatter>(serviceProvider =>
//{
//    string? typeName = config["services:IResponseFormatter"];
//    return (IResponseFormatter)ActivatorUtilities
//    .CreateInstance(serviceProvider, typeName == null
//    ? typeof(GuidService) : Type.GetType(typeName, true)!);
//});

//Creating Services with Multiple Implementations

builder.Services.AddScoped<IResponseFormatter, HtmlResponseFormatter>();
builder.Services.AddScoped<IResponseFormatter, GuidService>();
builder.Services.AddScoped<IResponseFormatter, TextResponseFormatter>();
var app = builder.Build();

//app.UseMiddleware<WeatherMiddleware>();

app.MapGet("single", async context =>
{
    IResponseFormatter formatter = context.RequestServices.GetService<IResponseFormatter>();
    await formatter.Format(context, "Single service");
});

app.MapGet("/", async context =>
{
    IResponseFormatter formatter = context.RequestServices.GetServices<IResponseFormatter>().Last(x => x.RichOutput);
    await formatter.Format(context, "Multiple format");
});
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

//app.MapGet("middleware/function", async (HttpContext context,
//    IResponseFormatter formatter) =>
//{
//    await formatter.Format(context, "Middleware function: rain in Chicago");
//});

//app.MapGet("endpoint/function", async (HttpContext context) =>
//{
//    IResponseFormatter formatter = context.RequestServices.GetService<IResponseFormatter>();
//    await formatter.Format(context, "Endpoint function: it's rainy in LA");
//});
//app.MapGet("endpoint/class", WeatherEndpoint.Endpoint);
//app.MapWeather("endpoint/class");
app.MapEndpoint<WeatherEndpoint>("endpoint/class");

//Creating Services with Multiple Implementations
app.Run();
