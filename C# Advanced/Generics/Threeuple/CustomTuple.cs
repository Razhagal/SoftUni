using System;
using System.Collections.Generic;
using System.Text;

namespace Threeuple
{
    public class CustomTuple<TFirst, TSecond, TThird>
    {
        public TFirst Item1 { get; set; }
        public TSecond Item2 { get; set; }
        public TThird Item3 { get; set; }
    }
}
