using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    internal class Car : Vehicle
    {
        private const double SeasonalFuelIncrease = 0.9;

        public Car(double initialFuel, double consumption, double tankCap)
            : base(initialFuel, consumption, tankCap, SeasonalFuelIncrease)
        { }

        public override void Drive(double distance)
        {
            double fuelRequired = distance * (this.FuelConsumption + this.SeasonalFuelConsumptionAdditive);
            if (this.FuelQuantity >= fuelRequired)
            {
                Console.WriteLine($"Car travelled {distance} km");
                this.FuelQuantity -= fuelRequired;
            }
            else
            {
                Console.WriteLine("Car needs refueling");
            }
        }

        public override void Refuel(double amount)
        {
            base.Refuel(amount);
        }
    }
}
