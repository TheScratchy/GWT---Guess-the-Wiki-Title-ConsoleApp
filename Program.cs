
using Microsoft.Extensions.DependencyInjection;
using GWT_ConsoleApp.Services;
using GWT_ConsoleApp.Models;
using GWT_ConsoleApp.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

var host = Host.CreateDefaultBuilder(args)
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