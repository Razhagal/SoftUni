using System;
using System.Text.RegularExpressions;

namespace SeriesOfLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\w)\1{0,}";
            Regex rgx = new Regex(pattern);

            string testStr = "aaaaabbbbbcdddeeeedssaa";

            MatchCollection matches = rgx.Matches(testStr);
            Console.WriteLine(matches.Count);

            for (int i = 0; i < matches.Count; i++)
            {
                Console.Write(matches[i].Groups[1].Value);
            }
        }
    }
}