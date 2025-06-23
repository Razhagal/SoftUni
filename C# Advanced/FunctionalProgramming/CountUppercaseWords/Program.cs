using System;
using System.Linq;

namespace CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> isUpperFunc = w => char.IsUpper(w[0]);
            string[] upperWords = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(w => w).Where(isUpperFunc).ToArray();

            for (int i = 0; i < upperWords.Length; i++)
            {
                Console.WriteLine(upperWords[i]);
            }
        }
    }
}