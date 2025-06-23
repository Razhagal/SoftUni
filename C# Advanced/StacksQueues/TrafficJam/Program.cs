using System;
using System.Collections.Generic;

namespace SoftUniExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();

            int totalCarsPassed = 0;
            string input = Console.ReadLine();
            while (!input.Equals("end"))
            {
                if (input.Equals("green"))
                {
                    for (int i = 0; i < number; i++)
                    {
                        if (cars.Count > 0)
                        {
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                            totalCarsPassed++;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{totalCarsPassed} cars passed the crossroads.");
        }
    }
}