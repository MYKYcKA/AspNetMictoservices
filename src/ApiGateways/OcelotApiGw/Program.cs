using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureAppConfiguration(appConfig =>
{
    appConfig.AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.json", true, true);
});

builder.Host.ConfigureLogging(logging =>
{
    logging.AddConfiguration(builder.Configuration.GetSection("Logging"));
    logging.AddConsole();
    logging.AddDebug();
});

builder.Services.AddOcelot().AddCacheManager(settings => settings.WithDictionaryHandle()); ;

var app = builder.Build();

app.UseOcelot();

app.Run();
