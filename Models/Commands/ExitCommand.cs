
namespace GWT_ConsoleApp.Models.Commands
{
    public class ExitCommand : ICommand
    {
        public string Name => "!exit";
        public string Description => "Exit the game";

        public void Execute(Game game, string args)
        {
            game.Exit();
        }
    }
}