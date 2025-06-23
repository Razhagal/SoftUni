using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    internal class Warrior : BaseHero
    {
        private const int WarriorDefaultPower = 100;

        public Warrior(string name)
            : base(name, WarriorDefaultPower)
        { }

        public override string CastAbility()
        {
            return $"Warrior - {this.Name} hit for {this.Power} damage";
        }
    }
}
