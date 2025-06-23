using System;
using System.Collections.Generic;

namespace BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int n = int.Parse(input[0]);
            int s = int.Parse(input[1]);
            int x = int.Parse(input[2]);

            string[] numbers = Console.ReadLine().Split();
            Stack<string> numbersStack = new Stack<string>(numbers);

            for (int i = 0; i < s; i++)
            {
                numbersStack.Pop();
            }

            if (numbersStack.Count == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                int smallestNumber = int.Parse(numbersStack.Peek());
                while (numbersStack.Count > 0)
                {
                    int currentNumber = int.Parse(numbersStack.Pop());
                    if (currentNumber == x)
                    {
                        Console.WriteLine("true");
                        return;
                    }
                    else if (currentNumber < smallestNumber)
                    {
                        smallestNumber = currentNumber;
                    }
                }

                Console.WriteLine(smallestNumber);
            }
        }
    }
}
