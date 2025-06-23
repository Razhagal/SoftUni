using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Engine
    {
        public Engine()
        {
            this.Displacement = 0;
            this.Efficiency = string.Empty;
        }

        public Engine(string model, int power)
            : this()
        {
            this.Model = model;
            this.Power = power;
        }

        public Engine(string model, int power, int displacement)
            : this(model, power)
        {
            this.Displacement = displacement;
        }

        public Engine(string model, int power, string efficiency)
            : this(model, power)
        {
            this.Efficiency = efficiency;
        }

        public Engine(string model, int power, int displacement, string efficiency)
            : this(model, power, displacement)
        {
            this.Efficiency = efficiency;
        }

        public string Model { get; set; }
        public int Power { get; set; }
        public int Displacement { get; set; }
        public string Efficiency { get; set; }

        public override string ToString()
        {
            string displacementStr = this.Displacement != 0 ? this.Displacement.ToString() : "n/a";
            string efficiencyStr = !string.IsNullOrEmpty(this.Efficiency) ? this.Efficiency : "n/a";

            return $"{this.Model}:\nPower: {this.Power}\nDisplacement: {displacementStr}\nEfficiency: {efficiencyStr}";
        }
    }
}