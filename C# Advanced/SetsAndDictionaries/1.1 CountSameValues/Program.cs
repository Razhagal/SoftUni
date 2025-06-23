using System;
using System.Collections.Generic;

namespace _1._1_CountSameValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> valuesDict = new Dictionary<string, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!valuesDict.ContainsKey(input[i]))
                {
                    valuesDict.Add(input[i], 0);
                }

                valuesDict[input[i]]++;
            }

            foreach (var pair in valuesDict)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value} times");
            }
        }
    }
}
