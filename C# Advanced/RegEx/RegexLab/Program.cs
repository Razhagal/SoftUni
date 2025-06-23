using System;
using System.IO;
using System.Text.RegularExpressions;

namespace RegexLab
{
    public class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([A-Z][a-zA-Z+#]*_[A-Z][a-z]{2}_\d{4})\s+([A-Z][a-z]{0,3}\d{2}_\d{2,4})\s+(\d+)";
            Regex rgx = new Regex(pattern);
            string[] allInputLines = File.ReadAllLines("../../../newData.txt");

            for (int i = 0; i < allInputLines.Length; i++)
            {
                if (!string.IsNullOrEmpty(allInputLines[i]) && rgx.IsMatch(allInputLines[i]))
                {
                    Match currentMatch = rgx.Match(allInputLines[i]);
                    string courseName = currentMatch.Groups[1].Value;
                    string userName = currentMatch.Groups[2].Value;
                    bool hasParsedScore = int.TryParse(currentMatch.Groups[3].Value, out int studentScore);

                    if (hasParsedScore && studentScore >= 0 && studentScore <= 100)
                    {
                        // Do stuff...
                    }
                }
            }

        }
    }
}