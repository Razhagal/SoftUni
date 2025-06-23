using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int upperLimit = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            List<int> numbers = Enumerable.Range(1, upperLimit).ToList();
            Func<int, int, bool> checkIfDivisibleFunc = (x, y) => x % y != 0;
            Action<int> printer = (x) => Console.Write($"{x} ");

            for (int i = 0; i < numbers.Count; i++)
            {
                bool isDivisible = true;
                for (int j = 0; j < dividers.Length; j++)
                {
                    if (checkIfDivisibleFunc(numbers[i], dividers[j]))
                    {
                        isDivisible = false;
                        break;
                    }
                }

                if (isDivisible)
                {
                    printer(numbers[i]);
                }
            }
        }
    }
}