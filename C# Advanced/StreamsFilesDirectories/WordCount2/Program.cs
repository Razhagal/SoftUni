using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordCount2
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();

            using (StreamReader reader = File.OpenText("../../../words.txt"))
            {
                string wordsLine = reader.ReadLine();
                while (wordsLine != null)
                {
                    string[] wordsSplit = wordsLine.Split();
                    for (int i = 0; i < wordsSplit.Length; i++)
                    {
                        if (!wordsCount.ContainsKey(wordsSplit[i]))
                        {
                            wordsCount.Add(wordsSplit[i], 0);
                        }
                    }

                    wordsLine = reader.ReadLine();
                }
            }

            Regex r = new Regex("(?:[^a-zA-Z0-9'])", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
            using (StreamReader reader = File.OpenText("../../../text.txt"))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    string[] lineWords = r.Replace(line, " ").Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < lineWords.Length; i++)
                    {
                        foreach (var dictWord in wordsCount.Keys)
                        {
                            if (dictWord.ToLower().Equals(lineWords[i].ToLower()))
                            {
                                wordsCount[dictWord]++;
                            }
                        }
                    }

                    line = reader.ReadLine();
                }
            }

            using (StreamWriter writer = File.CreateText("../../../actualResult.txt"))
            {
                foreach (var word in wordsCount)
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }

            //wordsCount = wordsCount.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            List<string> sortedDictKeys = wordsCount.OrderByDescending(x => x.Value).Select(x => x.Key).ToList();

            using (StreamReader reader = File.OpenText("../../../expectedResult.txt"))
            {
                int index = 0;
                string expectedLine = reader.ReadLine();
                while (expectedLine != null)
                {
                    if (index < sortedDictKeys.Count)
                    {
                        string[] splitExpected = expectedLine.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                        string expectedWord = splitExpected[0];
                        int expectedCount = int.Parse(splitExpected[1]);
                        Console.WriteLine($"Word: {sortedDictKeys[index]} - {wordsCount[sortedDictKeys[index]]}   Expected: {expectedWord} - {expectedCount}");
                        Console.WriteLine($"Result: {sortedDictKeys[index].Equals(expectedWord) && wordsCount[sortedDictKeys[index]] == expectedCount}");
                    }
                    else
                    {
                        Console.WriteLine("Missing words...");
                        break;
                    }

                    index++;
                    expectedLine = reader.ReadLine();
                }
            }
        }
    }
}