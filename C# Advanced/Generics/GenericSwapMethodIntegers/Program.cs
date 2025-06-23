using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodIntegers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int inputLines = int.Parse(Console.ReadLine());
            List<int> stringsList = new List<int>();

            for (int i = 0; i < inputLines; i++)
            {
                stringsList.Add(int.Parse(Console.ReadLine()));
            }

            int[] indexes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            SwapElements(stringsList, indexes[0], indexes[1]);

            stringsList.ForEach(x => Console.WriteLine($"{x.GetType()}: {x}"));
        }

        public static void SwapElements<T>(List<T> elements, int firstIndex, int secondIndex)
        {
            T temp = elements[firstIndex];
            elements[firstIndex] = elements[secondIndex];
            elements[secondIndex] = temp;
        }
    }
}