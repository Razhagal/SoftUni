using System;

namespace PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxLength = int.Parse(Console.ReadLine());
            string[] inputNames = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Func<string, int, bool> filter = FilterFunc();
            Action<string> printer = (x) => Console.WriteLine(x);

            for (int i = 0; i < inputNames.Length; i++)
            {
                if (filter(inputNames[i], maxLength))
                {
                    printer(inputNames[i]);
                }
            }
        }

        private static Func<string, int, bool> FilterFunc()
        {
            return (x, y) => x.Length <= y;
        }
    }
}