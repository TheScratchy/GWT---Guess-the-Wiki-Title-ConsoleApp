
namespace GWT_ConsoleApp.Models.Commands
{
    public class StatisticsCommand : ICommand
    {
        public string Name => "!stats";
        public string Description => "Show game statistics";

        public void Execute(Game game, string args)
        {
            Console.WriteLine($"Number of guesses: {game.NoOfGuesses}");
            Console.WriteLine($"Tried words: {string.Join(", ", game.TriedWords)}");
        }
    }
}