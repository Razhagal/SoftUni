using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    internal abstract class BaseHero
    {
        private string name;
        private int power;

        public BaseHero(string name, int power)
        {
            this.Name = name;
            this.Power = power;
        }

        public string Name { get { return this.name; } set { this.name = value; } }
        public int Power { get { return this.power; } set { this.power = value; } }

        public abstract string CastAbility();
    }
}
