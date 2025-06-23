using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    internal class Truck : Vehicle
    {
        private const double SeasonalFuelIncrease = 1.6;

        public Truck(double initialFuel, double consumption, double tankCap)
            : base(initialFuel, consumption, tankCap, SeasonalFuelIncrease)
        { }

        public override void Drive(double distance)
        {
            double fuelRequired = distance * (this.FuelConsumption + this.SeasonalFuelConsumptionAdditive);
            if (this.FuelQuantity >= fuelRequired)
            {
                Console.WriteLine($"Truck travelled {distance} km");
                this.FuelQuantity -= fuelRequired;
            }
            else
            {
                Console.WriteLine("Truck needs refueling");
            }
        }

        public override void Refuel(double amount)
        {
            double spaceLeftForFuel = this.TankCapacity - this.FuelQuantity;
            if (amount > spaceLeftForFuel)
            {
                Console.WriteLine($"Cannot fit {amount} fuel in the tank");
            }
            else
            {
                base.Refuel(amount * 0.95);
            }
        }
    }
}
