using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public Car()
        {
            this.Tires = new Tire[4];
        }

        public Car(string carModel)
            : this()
        {
            this.Model = carModel;
        }

        public Car(string carModel, int engineSpeed, int enginePower, int cargoWeight, string cargoType)
            : this(carModel)
        {
            this.Engine = new Engine(engineSpeed, enginePower);
            this.Cargo = new Cargo(cargoType, cargoWeight);
        }

        public Car(string carModel, int engineSpeed, int enginePower, int cargoWeight, string cargoType,
            double tire1Pressure, int tire1Age, double tire2Pressure, int tire2Age, double tire3Pressure, int tire3Age, double tire4Pressure, int tire4Age)
            : this(carModel, engineSpeed, enginePower, cargoWeight, cargoType)
        {
            this.Tires[0] = new Tire(tire1Age, tire1Pressure);
            this.Tires[1] = new Tire(tire2Age, tire2Pressure);
            this.Tires[2] = new Tire(tire3Age, tire3Pressure);
            this.Tires[3] = new Tire(tire4Age, tire4Pressure);
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tire[] Tires { get; set; }
    }
}
