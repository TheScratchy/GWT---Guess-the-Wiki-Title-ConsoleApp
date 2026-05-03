namespace GWT_ConsoleApp.Models.Commands
{
    public class CommandRouter
    {
        private readonly Dictionary<string, ICommand> _commands;

        public CommandRouter(IEnumerable<ICommand> commands)
        {
            _commands = commands.ToDictionary(c => c.Name, StringComparer.OrdinalIgnoreCase);
        }

        public bool TryExecute(string input, Game game)
        {
            if (!input.StartsWith('!'))
                return false;

            var parts = input.Split(' ', 2);
            var commandName = parts[0];
            var args = parts.Length > 1 ? parts[1] : "";

            if (_commands.TryGetValue(commandName, out var command))
            {
                command.Execute(game, args);
            }
            else
            {
                Console.WriteLine("Unknown command. Try !help");
            }

            return true;
        }
    }
}