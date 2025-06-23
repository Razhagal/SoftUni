using System;
using System.Linq;

namespace CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Func<int[], int> getMinFunc = (x) =>
            {
                return x.Min();
            };

            Console.WriteLine(getMinFunc(numbers));
        }
    }
}