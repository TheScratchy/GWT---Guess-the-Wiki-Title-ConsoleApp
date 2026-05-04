using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GWT_ConsoleApp.Models.Commands
{
    public class RevealCommand : ICommand
    {
        public string Name => "!reveal";
        public string Description => "Reveals a random word of the article";

        public void Execute(Game game, string args)
        {
            game.Article?.RevealRandomWord();
            game.DisplayArticle();
        }    
    }
}