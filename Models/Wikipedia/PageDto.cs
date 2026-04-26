using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GWT_ConsoleApp.Models.Wikipedia
{
    public class PageDto
    {
        public int Pageid { get; set; }
        public string Title { get; set; }
        public string Extract { get; set; }
    }
}