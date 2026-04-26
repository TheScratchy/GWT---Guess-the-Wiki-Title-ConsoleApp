using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GWT_ConsoleApp.Configuration
{
    public class WikipediaServiceOptions
    {
        public string? ExtractArticleUrl {get; set; }
        public string? BaseUrl {get; set; }
        public string? UserAgent {get; set; }
    }
}