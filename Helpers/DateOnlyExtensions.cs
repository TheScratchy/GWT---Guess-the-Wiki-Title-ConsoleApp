using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GWT_ConsoleApp.Helpers
{
    public static class DateOnlyExtensions
    {
        public static string InsertIntoString(this DateOnly date, string input, string placeholder = "{Date}")
        {
            return input.Replace(placeholder, "{year}/{month}/{day}", StringComparison.OrdinalIgnoreCase)
                        .Replace("{year}", date.Year.ToString(), StringComparison.OrdinalIgnoreCase)
                        .Replace("{month}", date.Month.ToString("D2"), StringComparison.OrdinalIgnoreCase)
                        .Replace("{day}", date.Day.ToString("D2"), StringComparison.OrdinalIgnoreCase);
        }
    }
}