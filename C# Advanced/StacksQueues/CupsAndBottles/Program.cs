using System;
using System.Collections.Generic;
using System.Linq;

namespace CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cupsQueue = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            Stack<int> bottlesStack = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());

            int totalWastedWater = 0;
            int currentCupValueLeft = 0;
            while (true)
            {
                if (currentCupValueLeft <= 0)
                {
                    currentCupValueLeft = cupsQueue.Peek();
                }
                
                int currentBottle = bottlesStack.Pop();
                if (currentBottle >= currentCupValueLeft)
                {
                    totalWastedWater += currentBottle - currentCupValueLeft;
                    currentCupValueLeft = 0;
                    cupsQueue.Dequeue();
                }
                else
                {
                    currentCupValueLeft -= currentBottle;
                }

                if (cupsQueue.Count == 0 || bottlesStack.Count == 0)
                {
                    break;
                }
            }

            if (cupsQueue.Count == 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottlesStack)}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(" ", cupsQueue)}");
            }

            Console.WriteLine($"Wasted litters of water: {totalWastedWater}");
        }
    }
}
