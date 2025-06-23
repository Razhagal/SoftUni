using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    public class Car
    {
        public Car(string carMake, string carModel, int carHorsePower, string carRegistrationNumber)
        {
            this.Make = carMake;
            this.Model = carModel;
            this.HorsePower = carHorsePower;
            this.RegistrationNumber = carRegistrationNumber;
        }

        public string Make { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
        public string RegistrationNumber { get; set; }

        public override string ToString()
        {
            return $"Make: {this.Make}{Environment.NewLine}Model: {this.Model}{Environment.NewLine}HorsePower: {this.HorsePower}{Environment.NewLine}RegistrationNumber: {this.RegistrationNumber}";
        }
    }
}