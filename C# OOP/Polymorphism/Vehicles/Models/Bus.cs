using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    internal class Bus : Vehicle
    {
        private const double NonEmptyBusFuelIncrease = 1.4;
        private const double EmptyBusFuelIncrease = 0;

        private double currentFuelIncrease;

        public Bus(double initialFuel, double consumption, double tankCap)
            : base(initialFuel, consumption, tankCap)
        {
            this.currentFuelIncrease = NonEmptyBusFuelIncrease;
        }

        public override void Drive(double distance)
        {
            double fuelRequired = distance * (this.FuelConsumption + currentFuelIncrease);
            if (this.FuelQuantity >= fuelRequired)
            {
                Console.WriteLine($"Bus travelled {distance} km");
                this.FuelQuantity -= fuelRequired;
            }
            else
            {
                Console.WriteLine("Bus needs refueling");
            }
        }

        public void DriveEmpty(double distance)
        {
            this.currentFuelIncrease = EmptyBusFuelIncrease;
            this.Drive(distance);

            currentFuelIncrease = NonEmptyBusFuelIncrease;
        }

        public override void Refuel(double amount)
        {
            base.Refuel(amount);
        }
    }
}
