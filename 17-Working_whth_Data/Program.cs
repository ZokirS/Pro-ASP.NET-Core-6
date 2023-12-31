using _17_Working_whth_Data.Platform.Services;
using _17_Working_whth_Data.Platform;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDistributedSqlServerCache(opts => {
    opts.ConnectionString
    = builder.Configuration["ConnectionStrings:CacheConnection"];
    opts.SchemaName = "dbo";
    opts.TableName = "DataCache";
});

builder.Services.AddResponseCaching();
builder.Services.AddSingleton<IResponseFormatter, HtmlResponseFormatter>();
var app = builder.Build();
app.UseResponseCaching();
app.MapEndpoint<SumEndpoint>("/sum/{count:int=1000000000}");
app.MapGet("/", async context => {
    await context.Response.WriteAsync("Hello World!");
});
app.Run();
