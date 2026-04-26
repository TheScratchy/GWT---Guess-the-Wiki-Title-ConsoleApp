using GWT_ConsoleApp.Models;

namespace GWT_ConsoleApp.Services
{
    public interface IWikimediaService
    {
        Task<Article[]> GetRandomMostPopularTitlesAsync(int rertiesLeft = 255);
    }
}