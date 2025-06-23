using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    internal interface IRebel : IPerson
    {
        string Group { get; set; }
    }
}
