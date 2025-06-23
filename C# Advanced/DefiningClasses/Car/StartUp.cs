using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Tire[]> tireSets = new List<Tire[]>();
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            string tireSetInput = Console.ReadLine();
            while (!tireSetInput.Equals("No more tires"))
            {
                string[] splitTiresData = tireSetInput.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Tire[] tireSet = new Tire[4];
                tireSet[0] = new Tire(int.Parse(splitTiresData[0]), double.Parse(splitTiresData[1]));
                tireSet[1] = new Tire(int.Parse(splitTiresData[2]), double.Parse(splitTiresData[3]));
                tireSet[2] = new Tire(int.Parse(splitTiresData[4]), double.Parse(splitTiresData[5]));
                tireSet[3] = new Tire(int.Parse(splitTiresData[6]), double.Parse(splitTiresData[7]));

                tireSets.Add(tireSet);

                tireSetInput = Console.ReadLine();
            }

            string engineInput = Console.ReadLine();
            while (!engineInput.Equals("Engines done"))
            {
                string[] splitEngineData = engineInput.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                engines.Add(new Engine(int.Parse(splitEngineData[0]), double.Parse(splitEngineData[1])));

                engineInput = Console.ReadLine();
            }

            string carInput = Console.ReadLine();
            while (!carInput.Equals("Show special"))
            {
                string[] splitCarInfo = carInput.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string carMake = splitCarInfo[0];
                string carModel = splitCarInfo[1];
                int carYear = int.Parse(splitCarInfo[2]);
                double carFuelQuantity = double.Parse(splitCarInfo[3]);
                double carFuelConsumption = double.Parse(splitCarInfo[4]);
                Engine carEngine = engines[int.Parse(splitCarInfo[5])];
                Tire[] carTiresSet = tireSets[int.Parse(splitCarInfo[6])];

                Car car = new Car(carMake, carModel, carYear, carFuelQuantity, carFuelConsumption, carEngine, carTiresSet);
                cars.Add(car);

                carInput = Console.ReadLine();
            }

            List<Car> filteredCars = cars
                .Where(x => x.Year >= 2017)
                .Where(x => x.Engine.HorsePower > 330)
                .Where(x => x.Tires.Sum(z => z.Pressure) >= 9d && x.Tires.Sum(z => z.Pressure) <= 10d)
                .ToList();

            // 20km drive distance
            filteredCars.ForEach(x => x.Drive(20d));
            foreach (var car in filteredCars)
            {
                Console.WriteLine($"Make: {car.Make}");
                Console.WriteLine($"Model: {car.Model}");
                Console.WriteLine($"Year: {car.Year}");
                Console.WriteLine($"HorsePowers: {car.Engine.HorsePower}");
                Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");
            }
        }
    }
}