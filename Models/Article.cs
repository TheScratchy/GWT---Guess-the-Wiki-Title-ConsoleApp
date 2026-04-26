using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GWT_ConsoleApp.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;

namespace GWT_ConsoleApp.Models
{
    public class Article
    {
        private string? _rawContent;
        private string? _title;
        private string? _changedContent;
        private ArticleOptions _options;

        private bool CheckCandidateLength(string candidate)
        {
            return candidate.Split(' ').Length >= _options.MinimumArticleWords;
        }

        // public string GetContent(string url)
        // {
        //     return _httpClient.GetFromJsonAsync<UserDto>(url);
        // }
        // private string GenerateNewContent()
        // {
        //     string candidate = _options.RandomArticleUrl;  
        // }

        public Article()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            configuration.GetSection("Article").Bind(_options);

            _options = new ArticleOptions();
        }
    }
}