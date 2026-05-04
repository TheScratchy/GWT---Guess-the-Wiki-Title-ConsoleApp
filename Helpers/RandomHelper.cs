using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GWT_ConsoleApp.Helpers
{
    public class RandomHelper
    {
        private static readonly Random _random = new Random();

        public static int RandomInt(int min = 0, int max = 255)
        {
            return _random.Next(min, max);
        }
        public static DateOnly RandomDate()
        {
            var from = new DateOnly(2015, 1, 1);
            var to = DateOnly.FromDateTime(DateTime.Now);
            var range = (to.ToDateTime(TimeOnly.MinValue) - from.ToDateTime(TimeOnly.MinValue)).Days;
            return from.AddDays(_random.Next(range + 1));
        }
    }
}