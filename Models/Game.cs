using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GWT_ConsoleApp.Services;

namespace GWT_ConsoleApp.Models
{
    public class Game
    {
        private readonly IWikipediaService _wikipedia;
        private readonly IWikimediaService _wikimedia;

        private Article? _article;

        public Game(IWikipediaService wikipedia, IWikimediaService wikimedia)
        {
            Console.WriteLine("Initializing game...");
            _wikipedia = wikipedia;
            _wikimedia = wikimedia;
        }

        public async Task StartAsync(string title = "cat")
        {
            Article[]  mostPopularTitles = await _wikimedia.GetRandomMostPopularTitlesAsync();
            var article = await _wikipedia.GetArticleAsync(title);
            Console.WriteLine(article);
        }


    }
}