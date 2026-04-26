using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GWT_ConsoleApp.Services;

namespace GWT_ConsoleApp.Models
{
    public class Game
    {
        private readonly IWikipediaService _wiki;

        private Article? _article;

        public Game(IWikipediaService wiki)
        {
            _wiki = wiki;
        }

        public async Task Run(string title = "cat")
        {
            var article = await _wiki.GetArticleAsync(title);
            Console.WriteLine(article);
        }


    }
}