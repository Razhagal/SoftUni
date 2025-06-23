using System;
using System.Collections.Generic;
using System.IO;

namespace MergeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> firstWords = new List<string>();
            using (StreamReader reader = new StreamReader("../../../FileOne.txt"))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    firstWords.Add(line);
                    line = reader.ReadLine();
                }
            }

            List<string> secondWords = new List<string>();
            using (StreamReader reader = new StreamReader("../../../FileTwo.txt"))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    secondWords.Add(line);
                    line = reader.ReadLine();
                }
            }

            using (StreamWriter writer = new StreamWriter("../../../Output.txt"))
            {
                int biggerSize = Math.Max(firstWords.Count, secondWords.Count);
                for (int i = 0; i < biggerSize; i++)
                {
                    if (i < firstWords.Count)
                    {
                        writer.WriteLine(firstWords[i]);
                    }

                    if (i < secondWords.Count)
                    {
                        writer.WriteLine(secondWords[i]);
                    }
                }
            }
        }
    }
}