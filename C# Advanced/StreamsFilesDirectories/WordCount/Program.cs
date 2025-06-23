using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();

            using (StreamReader reader = new StreamReader("../../../words.txt"))
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
            using (StreamReader reader = new StreamReader("../../../text.txt"))
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

            wordsCount = wordsCount.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            using (StreamWriter writer = new StreamWriter("../../../Output.txt"))
            {
                foreach (var word in wordsCount)
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}