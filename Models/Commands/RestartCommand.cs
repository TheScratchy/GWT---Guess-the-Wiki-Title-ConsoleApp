using System;
using System.Collections.Generic;

namespace GWT_ConsoleApp.Models.Commands
{
    public class RestartCommand : ICommand
    {
            public string Name => "!Restart";
        public string Description => "Restarts the game";

        public void Execute(Game game, string args)
        {
            game.StartAsync();
        }
    }
}