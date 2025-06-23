using System;
using System.Collections.Generic;
using System.Linq;

namespace AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            Func<string, Func<int, int>> operation = GetAction();

            string command = Console.ReadLine();
            while (!command.Equals("end"))
            {
                if (command.Equals("print"))
                {
                    Console.WriteLine(string.Join(" ", numbers));
                }
                else
                {
                    numbers = numbers.Select(operation(command)).ToList();
                }

                command = Console.ReadLine();
            }
        }

        private static Func<string, Func<int, int>> GetAction()
        {
            return (x) =>
            {
                return x switch
                {
                    "add" => c => c += 1,
                    "multiply" => c => c *= 2,
                    "subtract" => c => c -= 1,
                    _ => null,
                };
            };
        }
    }
}