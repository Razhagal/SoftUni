using System;
using System.Collections.Generic;

namespace BasicQueueOperations
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
            Queue<string> numbersQueue = new Queue<string>(numbers);

            for (int i = 0; i < s; i++)
            {
                numbersQueue.Dequeue();
            }

            if (numbersQueue.Count == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                int smallestNumber = int.Parse(numbersQueue.Peek());
                while (numbersQueue.Count > 0)
                {
                    int currentNumber = int.Parse(numbersQueue.Dequeue());
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
