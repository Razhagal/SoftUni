using System;
using System.Collections.Generic;
using System.Linq;

namespace PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int linesCount = int.Parse(Console.ReadLine());
            SortedSet<string> elementsSet = new SortedSet<string>();

            for (int i = 0; i < linesCount; i++)
            {
                string[] elementsInput = Console.ReadLine().Split();
                for (int j = 0; j < elementsInput.Length; j++)
                {
                    if (!elementsSet.Contains(elementsInput[j]))
                    {
                        elementsSet.Add(elementsInput[j]);
                    }
                }
            }

            foreach (var element in elementsSet)
            {
                Console.Write(element + " ");
            }
        }
    }
}
