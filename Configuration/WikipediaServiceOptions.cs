using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GWT_ConsoleApp.Configuration
{
    public class WikipediaServiceOptions
    {
        public string ExtractArticleUrl {get; set; } = string.Empty;
        public string BaseUrl {get; set; } = string.Empty;
        public string UserAgent {get; set; } = string.Empty;
        public int MinimumArticleWords {get; set; }
    }
}