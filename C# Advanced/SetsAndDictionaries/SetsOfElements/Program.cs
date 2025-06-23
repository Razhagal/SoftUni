using System;
using System.Linq;
using System.Collections.Generic;

namespace SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputSizes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int firstSetSize = inputSizes[0];
            int secondSetSize = inputSizes[1];
            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < firstSetSize; i++)
            {
                firstSet.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < secondSetSize; i++)
            {
                secondSet.Add(int.Parse(Console.ReadLine()));
            }

            firstSet.IntersectWith(secondSet);
            foreach (var number in firstSet)
            {
                Console.Write(number + " ");
            }
        }
    }
}
