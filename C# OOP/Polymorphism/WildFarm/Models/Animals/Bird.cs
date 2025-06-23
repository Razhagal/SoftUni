using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animals
{
    internal abstract class Bird : Animal
    {
        private double wingSize;

        public Bird(string name, double weight, double wingSize)
            : base(name, weight)
        {
            WingSize = wingSize;
        }

        public double WingSize { get { return wingSize; } set { wingSize = value; } }
    }
}
