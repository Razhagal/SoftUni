using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalOrders = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Queue<int> ordersQueue = new Queue<int>();

            int highestOrder = orders[0];
            for (int i = 0; i < orders.Length; i++)
            {
                ordersQueue.Enqueue(orders[i]);
                if (orders[i] > highestOrder)
                {
                    highestOrder = orders[i];
                }
            }

            Console.WriteLine(highestOrder);

            while (ordersQueue.Any())
            {   
                if (totalOrders - ordersQueue.Peek() >= 0)
                {
                    totalOrders -= ordersQueue.Dequeue();
                }
                else
                {
                    Console.WriteLine("Orders left: " + string.Join(" ", ordersQueue));
                    return;
                }
            }

            Console.WriteLine("Orders complete");
        }
    }
}