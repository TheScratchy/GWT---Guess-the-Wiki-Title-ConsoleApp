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
            //string[]  mostPopularTitles = await _wikimedia.GetRandomMostPopularTitlesAsync();
            Article article = await _wikipedia.GetArticleAsync(await _wikimedia.GetRandomTitleAsync());
            Console.WriteLine("Initializing game...");
            Console.WriteLine($"New Article: ");
            Console.WriteLine($"{article.EncryptedContent}");
            while (1 == 1)
            {
                Console.WriteLine("Enter a guess (or '!exit' to quit):");
                string guess = Console.ReadLine();
                switch (guess)
                {
                    case null:
                        Console.WriteLine("Invalid input. Please enter a valid guess.");
                        continue;
                    case "!exit":
                        Console.WriteLine("Thanks for playing! Goodbye!");
                        return;
                    case var g when g.StartsWith('!'):
                        Console.WriteLine("Unknown command. Try again.");
                        continue;
                    default:
                        if (article.GuessWord(guess))
                        {
                            Console.WriteLine("Congratulations! You've guessed the word!");
                            Console.WriteLine($"{article.EncryptedContent}");
                        }
                        else
                        {
                            Console.WriteLine("Wrong guess. Try again!");
                        }
                        break;
                }

                
            }
        }


    }
}