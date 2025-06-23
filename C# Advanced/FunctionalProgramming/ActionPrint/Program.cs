using System;
using System.Linq;

namespace ActionPrint
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
                    Console.WriteLine(x[i]);
                }
            };

            printer(names);
        }
    }
}