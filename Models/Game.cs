using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GWT_ConsoleApp.Services;
using GWT_ConsoleApp.Helpers;
using GWT_ConsoleApp.Models.Commands;

namespace GWT_ConsoleApp.Models
{
    public class Game
    {
        private readonly IWikipediaService _wikipedia;
        private readonly IWikimediaService _wikimedia;
        private readonly CommandRouter _commandRouter;
        public Article? Article { get; private set; }
        public Game(IWikipediaService wikipedia, IWikimediaService wikimedia)
        {
            _wikipedia = wikipedia;
            _wikimedia = wikimedia;

            var commands = new ICommand[] 
            {
                new ExitCommand(),
                new RestartCommand(),
                new StatisticsCommand(),
                new RevealCommand()
            };

            commands = commands.Append(new HelpCommand(commands)).ToArray();
            
            _commandRouter = new CommandRouter(commands);
        }
        public void DisplayArticle()
        {
            if (Article == null)
            {
                Console.WriteLine("No article loaded.");
                return;
            }

            Console.WriteLine($"Title: {Article.EncryptedTitle} \n");
            Console.WriteLine($"Content: {Article.EncryptedContent} \n");
        }
        public void Exit()
        {
            Environment.Exit(0);
        }

        public async Task StartAsync()
        {
            //string[]  mostPopularTitles = await _wikimedia.GetRandomMostPopularTitlesAsync();
            Article = await _wikipedia.GetArticleAsync(await _wikimedia.GetRandomTitleAsync());

            Console.WriteLine("Initializing game \n");
            DisplayArticle();
            
            while (1 == 1)
            {
                Console.WriteLine("Enter a guess (or '!exit' to quit, !help for help):");

                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Please enter a valid guess.");
                    continue;
                }
                
                if (_commandRouter.TryExecute(input, this))
                    continue;
                
                if (Article.TriedWords.Contains(input, StringComparer.OrdinalIgnoreCase))
                {
                    Console.WriteLine("You've already tried that word. Try something else!");
                    continue;
                }

                if (Article.GuessWord(input))
                {
                    if (Article.IsArticleGuessed())
                    {
                        ConsoleEx.ClearScreen();
                        Console.WriteLine("Congratulations! You've guessed the title!");
                        DisplayArticle();
                        return;
                    }

                    ConsoleEx.ClearScreen();
                    Console.WriteLine("Congratulations! You've guessed the word!");
                    DisplayArticle();
                }
                else
                {
                    Console.WriteLine("Wrong guess. Try again!");
                }
            }
        }
    }
}