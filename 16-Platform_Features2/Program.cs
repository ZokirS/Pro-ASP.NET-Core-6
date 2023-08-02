var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

app.MapFallback(async context =>
await context.Response.WriteAsync("Hello World!"));

app.Run();
