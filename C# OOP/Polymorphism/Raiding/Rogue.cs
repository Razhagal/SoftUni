using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    internal class Rogue : BaseHero
    {
        private const int RogueDefaultPower = 80;

        public Rogue(string name)
            : base(name, RogueDefaultPower)
        { }

        public override string CastAbility()
        {
            return $"Rogue - {this.Name} hit for {this.Power} damage";
        }
    }
}
