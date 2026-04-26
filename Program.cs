
using Microsoft.Extensions.DependencyInjection;
using GWT_ConsoleApp.Services;
using GWT_ConsoleApp.Models;

var services = new ServiceCollection();

services.AddHttpClient<IWikipediaService, WikipediaService>(client =>
{
    client.DefaultRequestHeaders.UserAgent.ParseAdd(
        "GWT_ConsoleApp/1.0 (learning project)"
    );
});

var provider = services.BuildServiceProvider();

// var wikiService = provider.GetRequiredService<IWikipediaService>();

// var article = await wikiService.GetArticleAsync("cat");



Console.WriteLine("Initializing game...");
Game game = new(provider.GetRequiredService<IWikipediaService>());

await game.Run();




//https://en.wikipedia.org/wiki/Special:Random
// https://en.wikipedia.org/api/rest_v1/page/summary/{title}