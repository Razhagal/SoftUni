using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    internal class PaladinFactory : HeroFactory
    {
        public PaladinFactory()
        { }

        public override BaseHero GetHero(string name)
        {
            return new Paladin(name);
        }
    }
}
