using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int cartridgeSize = int.Parse(Console.ReadLine());
            Stack<int> bulletsStack = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            Queue<int> locksQueue = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            int rewardPayout = int.Parse(Console.ReadLine());

            int bulletsAvailable = bulletsStack.Count;
            int shotsFired = 0;
            while (true)
            {
                int bullet = bulletsStack.Pop();
                if (bullet <= locksQueue.Peek())
                {
                    Console.WriteLine("Bang!");
                    locksQueue.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                shotsFired++;
                if (shotsFired % cartridgeSize == 0 && bulletsStack.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                }

                if (bulletsStack.Count == 0 || locksQueue.Count == 0)
                {
                    break;
                }
            }

            if (locksQueue.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");
            }
            else
            {
                int moneyEarned = rewardPayout - (shotsFired * bulletPrice);
                Console.WriteLine($"{bulletsStack.Count} bullets left. Earned ${moneyEarned}");
            }
        }
    }
}
