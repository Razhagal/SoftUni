using System;
using System.Linq;

namespace SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> parser = n => int.Parse(n);
            Func<int[], int> countFunc = GetLength;
            Func<int[], int> sumFunc = GetSum;

            int[] inputArr = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(parser).ToArray();

            Console.WriteLine(countFunc(inputArr));
            Console.WriteLine(sumFunc(inputArr));
        }

        static int GetLength(int[] array)
        {
            return array.Length;
        }

        static int GetSum(int[] array)
        {
            return array.Sum();
        }
    }
}