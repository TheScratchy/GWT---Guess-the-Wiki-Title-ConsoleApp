using GWT_ConsoleApp.Configuration;
using System.Net.Http.Json;
using GWT_ConsoleApp.Models.Wikimedia;
using Microsoft.Extensions.Configuration;
using GWT_ConsoleApp.Helpers;
using GWT_ConsoleApp.Models;

namespace GWT_ConsoleApp.Services
{
    public class WikimediaService : IWikimediaService
    {
        private readonly HttpClient _httpClient;
        private readonly WikimediaServiceOptions _options;

        public WikimediaService(HttpClient httpClient)
        {
            _httpClient = httpClient;

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            _options = new WikimediaServiceOptions();
            
            configuration.GetSection("WikimediaService").Bind(_options);

            if (_options == null)
                throw new InvalidOperationException("WikimediaServiceOptions is not configured.");

            ConfigureHttpClient();
        }

        private void ConfigureHttpClient()
        {
            _httpClient.BaseAddress = new Uri(_options.BaseUrl);
            _httpClient.DefaultRequestHeaders.UserAgent.Clear();
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(_options.UserAgent);
        }
        /// <summary>
        /// Provides a list of random most popular article titles from Wikipedia for a random date. 
        /// Retries with different dates if the API returns 404 Not Found, up to a maximum number of retries (default is 255).
        /// </summary>
        /// <param name="rertiesLeft">Number of retries left (0 means no retries)</param>
        /// <returns>List of articles</returns>
        public async Task<string[]> GetRandomMostPopularTitlesAsync(int rertiesLeft = 255 )
        {
            if (rertiesLeft <= 0)
                return new string[0];

            rertiesLeft--;
    
            var randomDate = RandomHelper.RandomDate();
            var url = randomDate.InsertIntoString(_options.MostViewedArticlesUrl);
            //"https://wikimedia.org/api/rest_v1/metrics/pageviews/top/en.wikipedia/all-access/2015/07/01";

            var response = await _httpClient.GetAsync(url);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return await GetRandomMostPopularTitlesAsync(rertiesLeft);

            var data = await response.Content.ReadFromJsonAsync<WikimediaResponseDto>();

            if (data?.Items == null || data.Items.Length == 0)
                return await GetRandomMostPopularTitlesAsync(rertiesLeft);

            string[] articleTitles = data?.Items?
                                        .Where(item => !_options.BannedWords.Any(bannedWord =>
                                            item.Article.Article.Contains(bannedWord, StringComparison.OrdinalIgnoreCase)))
                                        .Select(item => item.Article.Article).ToArray();
            if (articleTitles == null || articleTitles.Length == 0)
                return await GetRandomMostPopularTitlesAsync(rertiesLeft);
            
            return articleTitles;
        }

        public async Task<string> GetRandomTitleAsync()
        {
            string[] articleTitles = await GetRandomMostPopularTitlesAsync();
            return articleTitles[RandomHelper.RandomInt(articleTitles.Length)];
        }
    }
}