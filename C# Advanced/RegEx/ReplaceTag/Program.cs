using System;
using System.Text.RegularExpressions;

namespace ReplaceTag
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"<a(.*?)>(.*?)<\/a>";
            //string pattern2 = @"<a.*?href.*?=(.*)>(.*?)<\/a>";
            Regex rgx = new Regex(pattern);

            string input = "<ul> <li> <a href=\"http://softuni.bg\">SoftUni</a> </li> </ul>";

            Match match = rgx.Match(input);
            Console.WriteLine(match.Groups.Count);

            string newTag = $"[URL{match.Groups[1].Value}]{match.Groups[2].Value}[/URL]";
            string replacedTag = input.Replace(match.Groups[0].Value, newTag);

            Console.WriteLine(replacedTag);
        }
    }
}