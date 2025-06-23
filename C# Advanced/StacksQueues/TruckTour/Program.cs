using System;
using System.Collections.Generic;

namespace TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int pumpsCount = int.Parse(Console.ReadLine());
            Queue<string> pumpsData = new Queue<string>();

            for (int i = 0; i < pumpsCount; i++)
            {
                pumpsData.Enqueue(Console.ReadLine());
            }

            for (int i = 0; i < pumpsCount; i++)
            {
                int currentFuelTank = 0;
                bool isSuccessful = true;
                for (int j = 0; j < pumpsCount; j++)
                {
                    string currentPump = pumpsData.Dequeue();
                    int pumpFuel = int.Parse(currentPump.Split(" ")[0]);
                    int nextPumpDistance = int.Parse(currentPump.Split(" ")[1]);

                    pumpsData.Enqueue(currentPump);
                    currentFuelTank += (pumpFuel - nextPumpDistance);

                    if (currentFuelTank < 0)
                    {
                        isSuccessful = false;
                    }
                }

                pumpsData.Enqueue(pumpsData.Dequeue());

                if (isSuccessful)
                {
                    Console.WriteLine(i);
                    break;
                }
            }
        }
    }
}