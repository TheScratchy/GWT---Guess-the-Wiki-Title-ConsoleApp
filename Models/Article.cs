using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GWT_ConsoleApp.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;

namespace GWT_ConsoleApp.Models
{
    public class Article
    {
        private string _rawContent = string.Empty;
        private string _rawTitle;
        private string _encryptedContent = string.Empty;
        private string _encryptedTitle;
        private Dictionary<string, List<int>> _wordContentIndex = new();
        private Dictionary<string, List<int>> _wordTitleIndex = new();
        public string EncryptedContent {get {return  _encryptedContent;}}
        public string? EncryptedTitle {get {return  _encryptedTitle;}}


        public bool IsArticleGuessed()
        {
            return _encryptedTitle == _rawTitle;
        }
        private void EncryptArticleContent()
        {
            if (_rawContent == string.Empty) return;

            var matchesContent = Regex.Matches(_rawContent, @"\b[\p{L}\p{Nd}]+\b");

            var chars = _rawContent.ToCharArray();

            foreach (Match match in matchesContent)
            {
                string word = match.Value.ToLowerInvariant();
                int index = match.Index;

                if (!_wordContentIndex.TryGetValue(word, out var list))
                {
                    list = new List<int>();
                    _wordContentIndex[word] = list;
                }

                list.Add(index);

                for (int i = 0; i < match.Length; i++)
                    chars[match.Index + i] = '▨';
            }

             _encryptedContent = new string(chars);
        }

        private void EncryptArticleTitle()
        {
            if (_rawTitle == string.Empty) return;

            var matchesTitle = Regex.Matches(_rawTitle, @"\b[\p{L}\p{Nd}]+\b");

            var chars = _rawTitle.ToCharArray();

            foreach (Match match in matchesTitle)
            {
                string word = match.Value.ToLowerInvariant();
                int index = match.Index;

                if (!_wordTitleIndex.TryGetValue(word, out var list))
                {
                    list = new List<int>();
                    _wordTitleIndex[word] = list;
                }

                list.Add(index);

                for (int i = 0; i < match.Length; i++)
                    chars[match.Index + i] = '▨';
            }

             _encryptedTitle = new string(chars);
        }


        /// <summary>
        /// Checks if the provided word is present in the article's raw content, ignoring case.
        /// If it is present, it updates the encrypted content to reveal the guessed word.
        /// </summary> 
        /// <param name="word">The word to guess</param>
        /// <returns>True if the word is present in the article content, false otherwise</returns>
        public bool GuessWord(string word)
        {
            word = word.ToLowerInvariant();

            bool foundInContent  = _wordContentIndex.TryGetValue(word, out var positionsContent);
            bool foundInTitle = _wordTitleIndex.TryGetValue(word, out var positionsTitle);

            if (!foundInContent && !foundInTitle)
                return false;

            var charsContent = _encryptedContent.ToCharArray();
            var charsTitle = _encryptedTitle.ToCharArray();

            if (positionsContent != null)
            {
                foreach (var index in positionsContent)
                {
                    for (int i = 0; i < word.Length; i++)
                        charsContent[index + i] = _rawContent[index + i];
                }
            }

            if (positionsTitle != null)
            {
                foreach (var index in positionsTitle)
                {
                    for (int i = 0; i < word.Length; i++)
                        charsTitle[index + i] = _rawTitle[index + i];
                }
            }

            _encryptedContent = new string(charsContent);
            _encryptedTitle = new string(charsTitle);

            return true;
        }

        public Article(string title, string? content = null)
        {
            _rawTitle = title;
            _rawContent = content ?? string.Empty;

            EncryptArticleContent();
            EncryptArticleTitle();
        }
    }
}