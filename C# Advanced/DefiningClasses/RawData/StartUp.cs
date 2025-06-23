using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int carsAmount = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < carsAmount; i++)
            {
                string[] splitInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string carModel = splitInput[0];
                int carEngineSpeed = int.Parse(splitInput[1]);
                int carEnginePower = int.Parse(splitInput[2]);
                int carCargoWeight = int.Parse(splitInput[3]);
                string carCargoType = splitInput[4];

                double tire1Pressure = double.Parse(splitInput[5]);
                int tire1Age = int.Parse(splitInput[6]);
                double tire2Pressure = double.Parse(splitInput[7]);
                int tire2Age = int.Parse(splitInput[8]);
                double tire3Pressure = double.Parse(splitInput[9]);
                int tire3Age = int.Parse(splitInput[10]);
                double tire4Pressure = double.Parse(splitInput[11]);
                int tire4Age = int.Parse(splitInput[12]);

                Car car = new Car(carModel, carEngineSpeed, carEnginePower, carCargoWeight, carCargoType,
                    tire1Pressure, tire1Age, tire2Pressure, tire2Age, tire3Pressure, tire3Age, tire4Pressure, tire4Age);

                cars.Add(car);
            }

            string filterType = Console.ReadLine();
            List<Car> filteredCars = new List<Car>();
            Func<Car, bool> cargoTypeFilter = FilterByCargoType(filterType);
            if (filterType.Equals("fragile"))
            {
                filteredCars = cars.Where(cargoTypeFilter).Where(x => x.Tires.Any(t => t.Pressure < 1f)).ToList();
            }
            else if (filterType.Equals("flammable"))
            {
                filteredCars = cars.Where(cargoTypeFilter).Where(x => x.Engine.Power > 250).ToList();
            }

            for (int i = 0; i < filteredCars.Count; i++)
            {
                Console.WriteLine($"{filteredCars[i].Model}");
            }
        }

        private static Func<Car, bool> FilterByCargoType(string filter)
        {
            return x => x.Cargo.Type.Equals(filter);
        }
    }
}