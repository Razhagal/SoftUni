using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public Car()
        {
            this.Weight = 0;
            this.Color = string.Empty;
        }

        public Car(string model, Engine engine)
            : this()
        {
            this.Model = model;
            this.Engine = engine;
        }

        public Car(string model, Engine engine, int weight)
            : this(model, engine)
        {
            this.Weight = weight;
        }

        public Car(string model, Engine engine, string color)
            : this(model, engine)
        {
            this.Color = color;
        }

        public Car(string model, Engine engine, int weight, string color)
            : this(model, engine, weight)
        {
            this.Color = color;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            string weightStr = this.Weight != 0 ? this.Weight.ToString() : "n/a";
            string colorStr = !string.IsNullOrEmpty(this.Color) ? this.Color : "n/a";

            return $"{this.Model}:\n{this.Engine.ToString()}\nWeight: {weightStr}\nColor: {colorStr}";
        }
    }
}