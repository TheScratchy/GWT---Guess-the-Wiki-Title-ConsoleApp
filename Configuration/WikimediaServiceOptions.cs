using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GWT_ConsoleApp.Configuration
{
    public class WikimediaServiceOptions
    {
        public string?  BaseUrl {get; set; }
        public string? UserAgent {get; set; }
        public string? MostViewedArticlesUrl {get; set; }
        public string[]? BannedWords { get; set; }
    }
}