using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    public class CustomTuple<TFirst, TSecond>
    {
        public TFirst Item1 { get; set; }
        public TSecond Item2 { get; set; }
    }
}
