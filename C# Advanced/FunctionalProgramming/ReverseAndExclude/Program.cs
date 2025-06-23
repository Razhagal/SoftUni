using System;
using System.Linq;

namespace ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int divider = int.Parse(Console.ReadLine());

            Array.Reverse(numbers);
            numbers = numbers.Select(x => x).Where(x => x % divider != 0).ToArray();

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}