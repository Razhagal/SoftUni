using System;
using System.Linq;

namespace AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<decimal, decimal> addVATFunc = x => x * 1.2m;
            decimal[] numbers = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).Select(addVATFunc).ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"{numbers[i]:f2}");
            }
        }
    }
}