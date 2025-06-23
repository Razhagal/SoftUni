using System;
using System.Collections.Generic;
using System.Linq;

namespace FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int lowRange = range[0];
            int highRange = range[1];

            string filterType = Console.ReadLine();
            Func<int, bool> filterFunc = NumberFilter(filterType);

            PrintNumbers(lowRange, highRange, filterFunc, (x) => { Console.Write($"{x} "); });
        }

        private static Func<int, bool> NumberFilter(string filterType)
        {
            switch (filterType.ToLower())
            {
                case "even": return x => x % 2 == 0;
                case "odd": return x => x % 2 != 0;
                default: return null;
            }
        }

        private static void PrintNumbers(int lowRange, int highRange, Func<int, bool> filter, Action<int> printer)
        {
            for (int i = lowRange; i <= highRange; i++)
            {
                if (filter(i))
                {
                    printer(i);
                }
            }
        }
    }
}