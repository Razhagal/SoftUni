using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            Dictionary<string, Engine> enginesDict = new Dictionary<string, Engine>();

            int enginesCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < enginesCount; i++)
            {
                string[] splitEngineData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Engine currentEngine;

                string engineModel = splitEngineData[0];
                int enginePower = int.Parse(splitEngineData[1]);
                if (splitEngineData.Length > 3)
                {
                    int engineDisplacement = int.Parse(splitEngineData[2]);
                    string engineEfficiency = splitEngineData[3];
                    currentEngine = new Engine(engineModel, enginePower, engineDisplacement, engineEfficiency);
                }
                else if (splitEngineData.Length > 2)
                {
                    if (int.TryParse(splitEngineData[2], out int engineDisplacement))
                    {
                        currentEngine = new Engine(engineModel, enginePower, engineDisplacement);
                    }
                    else
                    {
                        string engineEfficiency = splitEngineData[2];
                        currentEngine = new Engine(engineModel, enginePower, engineEfficiency);
                    }
                }
                else
                {
                    currentEngine = new Engine(engineModel, enginePower);
                }

                enginesDict.Add(currentEngine.Model, currentEngine);
            }

            int carsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < carsCount; i++)
            {
                string[] splitCarData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Car currentCar;

                string carModel = splitCarData[0];
                Engine carEngine = enginesDict[splitCarData[1]];
                if (splitCarData.Length > 3)
                {
                    int carWeight = int.Parse(splitCarData[2]);
                    string carColor = splitCarData[3];
                    currentCar = new Car(carModel, carEngine, carWeight, carColor);
                }
                else if (splitCarData.Length > 2)
                {
                    if (int.TryParse(splitCarData[2], out int carWeight))
                    {
                        currentCar = new Car(carModel, carEngine, carWeight);
                    }
                    else
                    {
                        string carColor = splitCarData[2];
                        currentCar = new Car(carModel, carEngine, carColor);
                    }
                }
                else
                {
                    currentCar = new Car(carModel, carEngine);
                }

                cars.Add(currentCar);
            }

            cars.ForEach(x => Console.WriteLine(x));
        }
    }
}