using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GWT_ConsoleApp.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;

namespace GWT_ConsoleApp.Models
{
    public class Article
    {
        private string? _rawContent;
        private string? _title;
        private string? _encryptedContent;

        public string EncryptedContent {get {return  _encryptedContent;}}
        private ArticleOptions _options;

        private bool CheckCandidateLength(string candidate)
        {
            return candidate.Split(' ').Length >= _options.MinimumArticleWords;
        }

        public string GetContent()
        {
            if (_title == null)
                throw new InvalidOperationException("Article title is not set.");
            return _rawContent ?? string.Empty;
        }

        public Article(string title, string content = "")
        {
            _title = title;
            _rawContent = content;
        }
    }
}