using System;

namespace KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Action<string[]> printer = (x) =>
            {
                for (int i = 0; i < x.Length; i++)
                {
                    Console.WriteLine($"Sir {x[i]}");
                }
            };

            printer(names);
        }
    }
}