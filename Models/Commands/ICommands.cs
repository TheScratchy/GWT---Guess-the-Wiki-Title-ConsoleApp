namespace GWT_ConsoleApp.Models.Commands
{
    public interface ICommand
    {
        string Name { get; }
        string Description { get; }
        void Execute(Game game, string args);
    }
}