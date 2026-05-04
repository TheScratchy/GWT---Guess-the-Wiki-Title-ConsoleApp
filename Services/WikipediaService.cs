using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text.Json;
using GWT_ConsoleApp.Models;
using GWT_ConsoleApp.Models.Wikipedia;
using GWT_ConsoleApp.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace GWT_ConsoleApp.Services;
public class WikipediaService : IWikipediaService
{
    private readonly HttpClient _httpClient;
    private readonly WikipediaServiceOptions _options;
    private readonly ILogger<IWikimediaService> _logger;

    public WikipediaService(HttpClient httpClient, ILogger<IWikimediaService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
        
        var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

        _options = new WikipediaServiceOptions();

        configuration.GetSection("WikipediaService").Bind(_options);


        ConfigureHttpClient();
    }

    private void ConfigureHttpClient()
    {
        _httpClient.BaseAddress = new Uri(_options.BaseUrl);

        _httpClient.DefaultRequestHeaders.UserAgent.Clear();
        _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(_options.UserAgent);
    }

    public async Task<Article?> GetArticleAsync(string title)
    {
        var response = await _httpClient.GetAsync(_options.ExtractArticleUrl.Replace("{title}", Uri.EscapeDataString(title)));

        if (!response.IsSuccessStatusCode)
            return null;

        var data = await response.Content.ReadFromJsonAsync<WikipediaResponseDto>();

        if (data?.Query?.Pages == null || data.Query.Pages.Count == 0)
            return null;

        var page = data.Query.Pages.Values.FirstOrDefault();

        if (page == null || page.Extract == null)
            return null;

        return page.Extract.Split(' ').Length >= _options.MinimumArticleWords
                ? new Article(page.Title, page.Extract)
                : null;
    }
}