using System;
using Vehicles.Models;

namespace Vehicles
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] truckInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] busInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Vehicle car = new Car(double.Parse(carInput[1]), double.Parse(carInput[2]), double.Parse(carInput[3]));
            Vehicle truck = new Truck(double.Parse(truckInput[1]), double.Parse(truckInput[2]), double.Parse(truckInput[3]));
            Vehicle bus = new Bus(double.Parse(busInput[1]), double.Parse(busInput[2]), double.Parse(busInput[3]));

            int inputsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputsCount; i++)
            {
                string[] splitInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = splitInput[0];
                string vehicle = splitInput[1];
                double amount = double.Parse(splitInput[2]);

                Vehicle currentVehicle = null;
                if (command.Equals("Drive"))
                {
                    if (vehicle.Equals("Car"))
                    {
                        currentVehicle = car;
                    }
                    else if (vehicle.Equals("Truck"))
                    {
                        currentVehicle = truck;
                    }
                    else if (vehicle.Equals("Bus"))
                    {
                        currentVehicle = bus;
                    }

                    currentVehicle.Drive(amount);
                }
                else if (command.Equals("Refuel"))
                {
                    if (vehicle.Equals("Car"))
                    {
                        currentVehicle = car;
                    }
                    else if (vehicle.Equals("Truck"))
                    {
                        currentVehicle = truck;
                    }
                    else if (vehicle.Equals("Bus"))
                    {
                        currentVehicle = bus;
                    }

                    currentVehicle.Refuel(amount);
                }
                else if (command.Equals("DriveEmpty"))
                {
                    ((Bus)bus).DriveEmpty(amount);
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");
        }
    }
}