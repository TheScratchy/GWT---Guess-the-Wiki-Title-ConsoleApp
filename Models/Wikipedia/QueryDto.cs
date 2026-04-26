using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GWT_ConsoleApp.Models.Wikipedia
{
    public class QueryDto
    {
        public Dictionary<string, PageDto> Pages { get; set; }
    }
}