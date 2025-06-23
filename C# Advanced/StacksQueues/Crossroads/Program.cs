using System;
using System.Collections.Generic;

namespace Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenTime = int.Parse(Console.ReadLine());
            int freeWindowTime = int.Parse(Console.ReadLine());
            int totalTime = greenTime + freeWindowTime;
            Queue<string> carsQueue = new Queue<string>();
            Stack<char> currentCarStack = new Stack<char>();

            int totalCarsPassed = 0;
            string command = Console.ReadLine();
            while (!command.Equals("END"))
            {
                if (command.Equals("green"))
                {
                    if (carsQueue.Count > 0)
                    {
                        string currentCar = carsQueue.Dequeue();
                        PutCarInStack(currentCar, ref currentCarStack);
                        totalCarsPassed++;
                        for (int i = 1; i <= totalTime; i++)
                        {
                            if (currentCarStack.Count == 0)
                            {
                                if (i <= greenTime)
                                {
                                    if (carsQueue.Count == 0)
                                    {
                                        break;
                                    }

                                    currentCar = carsQueue.Dequeue();
                                    PutCarInStack(currentCar, ref currentCarStack);
                                    totalCarsPassed++;
                                }
                                else
                                {
                                    break;
                                }
                            }

                            currentCarStack.Pop();
                        }

                        if (currentCarStack.Count > 0)
                        {
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{currentCar} was hit at {currentCarStack.Pop()}.");
                            return;
                        }
                    }
                }
                else
                {
                    // Its a car
                    carsQueue.Enqueue(command);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{totalCarsPassed} total cars passed the crossroads.");
        }

        private static void PutCarInStack(string car, ref Stack<char> carStack)
        {
            for (int i = car.Length - 1; i >= 0; i--)
            {
                carStack.Push(car[i]);
            }
        }
    }
}
