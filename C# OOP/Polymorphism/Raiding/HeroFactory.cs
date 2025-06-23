using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    internal abstract class HeroFactory
    {
        public abstract BaseHero GetHero(string name);
    }
}
