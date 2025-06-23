using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    internal class DruidFactory : HeroFactory
    {
        public DruidFactory()
        { }

        public override BaseHero GetHero(string name)
        {
            return new Druid(name);
        }
    }
}
