using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Array.Sort(numbers, new NumbersComparer());

            Console.WriteLine(string.Join(" ", numbers));
        }
    }

    public class NumbersComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            bool xIsEven = x % 2 == 0;
            bool yIsEven = y % 2 == 0;

            if ((xIsEven && yIsEven) || (!xIsEven && !yIsEven))
            {
                return x.CompareTo(y);
            }
            else
            {
                return xIsEven ? -1 : 1;
            }
        }
    }
}