using GWT_ConsoleApp.Models;

namespace GWT_ConsoleApp.Services
{
    public interface IWikimediaService
    {
        Task<string[]> GetRandomMostPopularTitlesAsync(int rertiesLeft = 255);

        Task<string> GetRandomTitleAsync();
    }
}