using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Interfaces;

namespace Vehicles.Models
{
    internal abstract class Vehicle : IDrivable, IRefuelable
    {
        private double tankCapacity;
        private double fuelQuantity;
        private double fuelConsumption;
        private double addedSeasonalFuelConsumption;

        public Vehicle(double initialFuel, double consumption, double tankCap, double seasonalFuelConsumptionIncrease = 0)
        {
            this.TankCapacity = tankCap;
            if (initialFuel <= this.tankCapacity)
            {
                this.FuelQuantity = initialFuel;
            }
            else
            {
                this.FuelQuantity = 0;
            }
            
            this.FuelConsumption = consumption;
            this.SeasonalFuelConsumptionAdditive = seasonalFuelConsumptionIncrease;
        }

        public double TankCapacity { get { return this.tankCapacity; } private set { this.tankCapacity = value; } }
        public double FuelQuantity { get { return this.fuelQuantity; } protected set { this.fuelQuantity = value; } }
        public double FuelConsumption { get { return this.fuelConsumption; } private set { this.fuelConsumption = value; } }
        public double SeasonalFuelConsumptionAdditive { get { return this.addedSeasonalFuelConsumption; } private set { this.addedSeasonalFuelConsumption = value; } }

        public abstract void Drive(double distance);

        public virtual void Refuel(double amount)
        {
            if (amount > 0)
            {
                double spaceLeftForFuel = this.tankCapacity - this.fuelQuantity;
                if (amount <= spaceLeftForFuel)
                {
                    this.FuelQuantity += amount;
                }
                else
                {
                    Console.WriteLine($"Cannot fit {amount} fuel in the tank");
                }
            }
            else
            {
                Console.WriteLine("Fuel must be a positive number");
            }
        }
    }
}