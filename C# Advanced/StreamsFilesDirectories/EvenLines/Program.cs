using System;
using System.IO;
using System.Text.RegularExpressions;

namespace EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regPattern = new Regex("(?:[-,.!?])", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);

            using (StreamReader reader = new StreamReader("../../../text.txt"))
            {
                int lineIndex = 0;
                string line = reader.ReadLine();
                while (line != null)
                {
                    if (lineIndex % 2 == 0)
                    {
                        string[] splitLine = regPattern.Replace(line, "@").Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        for (int i = splitLine.Length - 1; i >= 0; i--)
                        {
                            Console.Write(splitLine[i] + " ");
                        }

                        Console.WriteLine();
                    }

                    lineIndex++;
                    line = reader.ReadLine();
                }
            }
        }
    }
}