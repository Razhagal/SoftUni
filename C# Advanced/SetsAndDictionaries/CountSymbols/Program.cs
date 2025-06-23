using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<char, int> charsCount = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!charsCount.ContainsKey(input[i]))
                {
                    charsCount.Add(input[i], 0);
                }

                charsCount[input[i]]++;
            }

            charsCount = charsCount.OrderBy(v => v.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var symbol in charsCount)
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }
    }
}
