using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GWT_ConsoleApp.Models;

namespace GWT_ConsoleApp.Services
{
    public interface IWikipediaService
    {
        Task<Article?> GetArticleAsync(string title);
    }
}