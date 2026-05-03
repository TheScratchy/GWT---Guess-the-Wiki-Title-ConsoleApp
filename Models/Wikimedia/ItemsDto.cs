using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GWT_ConsoleApp.Models.Wikimedia
{
    public class ItemsDto
    {
        public ArticleDto[] Articles { get; set; } = Array.Empty<ArticleDto>();
    }
}