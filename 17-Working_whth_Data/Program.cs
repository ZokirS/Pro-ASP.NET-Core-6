using _14_Dependency_Injection.Platform.Services;
using _17_Working_whth_Data.Platform;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
//builder.Services.AddDistributedMemoryCache(opts =>
//{
//    opts.SizeLimit = 200;
//});
builder.Services.AddDistributedSqlServerCache(opts =>
{
    opts.ConnectionString = builder.Configuration["ConnectionStrings:CacheConnection"];
    opts.SchemaName = "dbo";
    opts.TableName = "DataCache";
});

var app = builder.Build();

app.MapEndpoint<SumEndpoint>("/sum/{count:int=10}");
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
