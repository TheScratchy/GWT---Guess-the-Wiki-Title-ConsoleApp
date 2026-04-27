using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GWT_ConsoleApp.Helpers
{
    public static class StringExtensions
    {
        public static int[] GetAllIndexes(this string str, string substring, StringComparison comparisonType = StringComparison.OrdinalIgnoreCase)
        {
            List<int> indexes = new List<int>();
            int index = 0;

            while ((index = str.IndexOf(substring, index, comparisonType)) != -1)
            {
                indexes.Add(index);
                index += substring.Length; // Move past the last found substring
            }

            return indexes.ToArray();
        }
    }
}