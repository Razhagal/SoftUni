using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Seat : ICar
    {
        private string model;
        private string color;

        public string Model { get { return this.model; } set { this.model = value; } }
        public string Color { get { return this.color; } set { this.color = value; } }

        public Seat(string model, string color)
        {
            this.Model = model;
            this.Color = color;
        }

        public void Start()
        {
            Console.WriteLine("Engine start");
        }

        public void Stop()
        {
            Console.WriteLine("Breaaak!");
        }

        public override string ToString()
        {
            return $"{this.Color} {this.GetType().Name} {this.Model}";
        }
    }
}
