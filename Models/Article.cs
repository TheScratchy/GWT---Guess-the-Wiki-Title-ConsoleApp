using System;
using System.Collections.Generic;
using System.Linq;
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
        private string? _rawContent;
        private string _title;
        private string? _encryptedContent;

        public string? EncryptedContent {get {return  _encryptedContent;}}
        private ArticleOptions? _options;



        private string? EncryptContent(string? content)
        {
            if (content == null) return null;
            string encrypted = string.Empty;
            foreach (char c in content)
            {
                encrypted += char.IsLetter(c) || char.IsDigit(c) ? '▨' : c;
            }
            return encrypted;
        }

        /// <summary>
        /// Checks if the provided word is present in the article's raw content, ignoring case.
        /// If it is present, it updates the encrypted content to reveal the guessed word.
        /// </summary> 
        /// <param name="word">The word to guess</param>
        /// <returns>True if the word is present in the article content, false otherwise</returns>
        public bool GuessWord(string word)
        {
            if (_rawContent == null || _encryptedContent == null)
                throw new InvalidOperationException("Article content not initialized :(");
            
            int index = 0;
            bool found = false;
            while ((index = _rawContent.IndexOf(word, index, StringComparison.OrdinalIgnoreCase)) != -1)
            {
                _encryptedContent = _encryptedContent.Remove(index, word.Length).Insert(index, word);
                index += word.Length; // Move past the last found substring
                found = true;
            }                

            return found;
        }

        public Article(string title, string? content = null)
        {
            _title = title;
            _rawContent = content;
            _encryptedContent = EncryptContent(content);
        }
    }
}