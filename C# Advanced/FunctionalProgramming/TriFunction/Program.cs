using System;
using System.Linq;

namespace TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int charSum = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Func<string, int, bool> checkStringSum = (x, y) => x.Sum(z => z) >= y;
            Func<string, Func<string, int, bool>, bool> findFirstElementFunc = (x, y) => y(x, charSum);

            Console.WriteLine(names.First(x => findFirstElementFunc(x, checkStringSum)));
        }
    }
}