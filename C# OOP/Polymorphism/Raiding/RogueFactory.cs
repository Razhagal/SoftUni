using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    internal class RogueFactory : HeroFactory
    {
        public RogueFactory()
        { }

        public override BaseHero GetHero(string name)
        {
            return new Rogue(name);
        }
    }
}
