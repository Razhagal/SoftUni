using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Car> carsDict = new Dictionary<string, Car>();
            int carsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsCount; i++)
            {
                string[] splitCarData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Car car = new Car(splitCarData[0], double.Parse(splitCarData[1]), double.Parse(splitCarData[2]));

                carsDict.Add(car.Model, car);
            }

            string command = Console.ReadLine();
            while (!command.Equals("End"))
            {
                string[] splitCommand = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (splitCommand[0].Equals("Drive"))
                {
                    string carModel = splitCommand[1];
                    double distanceToTravel = double.Parse(splitCommand[2]);
                    carsDict[carModel].Drive(distanceToTravel);
                }

                command = Console.ReadLine();
            }

            foreach (var car in carsDict.Values)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}