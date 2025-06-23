using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public Car()
        {
            this.TravelledDistance = 0;
        }

        public Car(string model, double fuelAmount, double fuelCostPerKilometer)
            : this()
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelCostPerKilometer;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public void Drive(double distance)
        {
            double fuelToSpend = distance * this.FuelConsumptionPerKilometer;
            if (fuelToSpend <= this.FuelAmount)
            {
                this.FuelAmount -= fuelToSpend;
                this.TravelledDistance += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public override string ToString()
        {
            return $"{this.Model} {this.FuelAmount:f2} {this.TravelledDistance}";
        }
    }
}
