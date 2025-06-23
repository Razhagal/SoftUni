using System;
using System.IO;
using System.Linq;

namespace LineNumbers2
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] nonAlphanumberiChars = new char[] { '.', ',', '-', '\'', '!', '?' };
            using (StreamReader reader = File.OpenText("../../../text.txt"))
            {
                using (StreamWriter writer = File.CreateText("../../../output.txt"))
                {
                    int lineIndex = 1;
                    string readLine = reader.ReadLine();
                    while (readLine != null)
                    {
                        int nonAlphanumericSymbolsCount = 0;
                        int alphanumericCharsCount = 0;

                        for (int i = 0; i < readLine.Length; i++)
                        {
                            if (nonAlphanumberiChars.Contains(readLine[i]))
                            {
                                nonAlphanumericSymbolsCount++;
                            }
                            else if (!readLine[i].Equals(' '))
                            {
                                alphanumericCharsCount++;
                            }
                        }

                        writer.WriteLine($"Line {lineIndex}: {readLine} ({alphanumericCharsCount})({nonAlphanumericSymbolsCount})");

                        lineIndex++;
                        readLine = reader.ReadLine();
                    }
                }
            }
        }
    }
}