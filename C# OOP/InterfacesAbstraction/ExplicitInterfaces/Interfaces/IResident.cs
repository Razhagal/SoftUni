using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitInterfaces.Interfaces
{
    internal interface IResident
    {
        string Name { get; set; }
        string Country { get; set; }
        string GetName();
    }
}
