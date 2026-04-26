using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GWT_ConsoleApp.Configuration
{
    public class ArticleOptions
    {
        public int MinimumArticleWords { get; set; }
        public string RandomArticleUrl { get; set; } = string.Empty;
    }
}