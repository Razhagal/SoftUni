using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public interface IPerson : INamable
    {
        int Age { get; set; }
    }
}
