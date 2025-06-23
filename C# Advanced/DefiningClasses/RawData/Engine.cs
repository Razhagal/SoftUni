using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Engine
    {
        public Engine() { }

        public Engine(int engineSpeed, int enginePower)
            : this()
        {
            this.Speed = engineSpeed;
            this.Power = enginePower;
        }

        public int Speed { get; set; }
        public int Power { get; set; }
    }
}
