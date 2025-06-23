using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    internal class Paladin : BaseHero
    {
        private const int PaladinDefaultPower = 100;

        public Paladin(string name)
            : base(name, PaladinDefaultPower)
        { }

        public override string CastAbility()
        {
            return $"Paladin - {this.Name} healed for {this.Power}";
        }
    }
}
