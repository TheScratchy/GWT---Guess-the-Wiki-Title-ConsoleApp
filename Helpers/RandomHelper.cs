using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GWT_ConsoleApp.Helpers
{
    public class RandomHelper
    {
        private static readonly Random _random = new Random();

        public static DateTime RandomDate(DateTime from, DateTime to)
        {
            var range = (to - from).Days;
            return from.Date.AddDays(_random.Next(range + 1));
        }
    }
}