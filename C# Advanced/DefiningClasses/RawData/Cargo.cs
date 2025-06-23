using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Cargo
    {
        public Cargo() { }

        public Cargo(string cargoType, int cargoWeight)
            : this()
        {
            this.Type = cargoType;
            this.Weight = cargoWeight;
        }

        public string Type { get; set; }
        public int Weight { get; set; }
    }
}
