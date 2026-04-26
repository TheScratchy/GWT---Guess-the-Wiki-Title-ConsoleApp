using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using GWT_ConsoleApp.Models;
using GWT_ConsoleApp.Models.Wikipedia;

namespace GWT_ConsoleApp.Services;
public class WikipediaService : IWikipediaService
{
    private readonly HttpClient _httpClient;

    public WikipediaService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ArticleDto?> GetArticleAsync(string title)
    {
        var url =
            $"https://en.wikipedia.org/w/api.php?action=query&format=json&prop=extracts&explaintext&titles={Uri.EscapeDataString(title)}";

        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
            return null;

        var data = await response.Content.ReadFromJsonAsync<WikipediaResponseDto>();

        if (data?.Query?.Pages == null || data.Query.Pages.Count == 0)
            return null;

        var page = data.Query.Pages.Values.FirstOrDefault();

        if (page == null)
            return null;

        return new ArticleDto
        {
            Title = page.Title,
            Content = page.Extract
        };
    }

    private async Task<List<string>> GetMostPopularTitles()
    {
        var randomDate = Helpers.RandomHelper.RandomDate(DateTime.Now.AddDays(-30), DateTime.Now);
        var url =
            $"https://en.wikipedia.org/w/api.php?action=query&format=json&list=mostviewed&mvlimit=100&mvdir=descending";

        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
            return new List<string>();

        var data = await response.Content.ReadFromJsonAsync<WikipediaMostViewedResponseDto>();

        if (data?.Query?.MostViewed == null || data.Query.MostViewed.Count == 0)
            return new List<string>();

        return data.Query.MostViewed.Select(mv => mv.Title).ToList();
    }
}