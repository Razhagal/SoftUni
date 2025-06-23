using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    internal class Druid : BaseHero
    {
        private const int DruidDefaultPower = 80;

        public Druid(string name)
            : base(name, DruidDefaultPower)
        { }

        public override string CastAbility()
        {
            return $"Druid - {this.Name} healed for {this.Power}";
        }
    }
}
