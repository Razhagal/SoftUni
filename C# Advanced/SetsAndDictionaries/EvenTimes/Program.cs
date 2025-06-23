using System;
using System.Collections.Generic;

namespace EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputLines = int.Parse(Console.ReadLine());
            Dictionary<int, int> numbersCount = new Dictionary<int, int>();

            for (int i = 0; i < inputLines; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (!numbersCount.ContainsKey(number))
                {
                    numbersCount.Add(number, 0);
                }

                numbersCount[number]++;
            }

            foreach (var number in numbersCount)
            {
                if (number.Value % 2 == 0)
                {
                    Console.WriteLine(number.Key);
                    break;
                }
            }
        }
    }
}
