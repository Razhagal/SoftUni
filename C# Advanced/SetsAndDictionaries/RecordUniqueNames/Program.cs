using System;
using System.Collections.Generic;

namespace RecordUniqueNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            HashSet<string> namesSet = new HashSet<string>();

            for (int i = 0; i < count; i++)
            {
                string name = Console.ReadLine();
                namesSet.Add(name);
            }

            foreach (var name in namesSet)
            {
                Console.WriteLine(name);
            }
        }
    }
}
