
namespace GWT_ConsoleApp.Models.Commands
{
    public class HelpCommand : ICommand
    {
        private readonly IEnumerable<ICommand> _commands;

        public HelpCommand(IEnumerable<ICommand> commands)
        {
            _commands = commands;
        }

        public string Name => "!help";
        public string Description => "Show available commands";

        public void Execute(Game game, string args)
        {
            foreach (var cmd in _commands)
                Console.WriteLine($"{cmd.Name} - {cmd.Description}");

            // self show to support easier creation - one enumerable in constructor without this command
            Console.WriteLine($"{this.Name} - {this.Description}");
        }
    }
}