using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothesValues = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int rackCapacity = int.Parse(Console.ReadLine());

            Stack<int> clothesStack = new Stack<int>(clothesValues);

            int racksNeeded = 1;
            int currentRackWeigth = 0;
            while (clothesStack.Count > 0)
            {
                if (currentRackWeigth + clothesStack.Peek() > rackCapacity)
                {
                    racksNeeded++;
                    currentRackWeigth = 0;
                }
                else
                {
                    currentRackWeigth += clothesStack.Pop();
                }
            }

            Console.WriteLine(racksNeeded);
        }
    }
}
