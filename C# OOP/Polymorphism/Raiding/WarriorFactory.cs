using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    internal class WarriorFactory : HeroFactory
    {
        public WarriorFactory()
        { }

        public override BaseHero GetHero(string name)
        {
            return new Warrior(name);
        }
    }
}
