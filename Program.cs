
using Microsoft.Extensions.DependencyInjection;
using GWT_ConsoleApp.Services;
using GWT_ConsoleApp.Models;
using GWT_ConsoleApp.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureLogging(logging =>
    {
        logging.ClearProviders();
        logging.AddConsole();

        logging.SetMinimumLevel(LogLevel.Warning);

        logging.AddFilter("System.Net.Http.HttpClient", LogLevel.None);
        logging.AddFilter("Microsoft.Extensions.Http", LogLevel.None);
        logging.AddFilter("Microsoft.Hosting.Lifetime", LogLevel.None);
    })
    .ConfigureServices((context, services) =>
    {
        IConfiguration config = context.Configuration;

        services.Configure<WikipediaServiceOptions>(
            config.GetSection("WikipediaApi"));

        services.AddHttpClient<IWikipediaService, WikipediaService>();
        services.AddHttpClient<IWikimediaService, WikimediaService>();

        services.AddSingleton<Game>();
    })
    .Build();

var game = host.Services.GetRequiredService<Game>();
await game.StartAsync();

//https://en.wikipedia.org/wiki/Special:Random
// https://en.wikipedia.org/api/rest_v1/page/summary/{title}