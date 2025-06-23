using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private Dictionary<string, Car> parkedCars;
        private int capacity;

        public Parking(int capacity)
        {
            this.Capacity = capacity;
            this.parkedCars = new Dictionary<string, Car>();
        }

        public int Capacity
        {
            get { return this.capacity; }
            private set { this.capacity = value; }
        }

        public int Count { get { return this.parkedCars.Count; } }

        public string AddCar(Car car)
        {
            if (this.parkedCars.ContainsKey(car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            else if (this.parkedCars.Count >= this.capacity)
            {
                return "Parking is full!";
            }

            this.parkedCars.Add(car.RegistrationNumber, car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string carRegistrationNum)
        {
            if (!this.parkedCars.ContainsKey(carRegistrationNum))
            {
                return "Car with that registration number, doesn't exist!";
            }

            this.parkedCars.Remove(carRegistrationNum);
            return $"Successfully removed {carRegistrationNum}";
        }

        public Car GetCar(string carRegistrationNum)
        {
            // TODO: What if no such car is parked?
            return this.parkedCars[carRegistrationNum];
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            registrationNumbers.ForEach(x => this.parkedCars.Remove(x));
        }
    }
}