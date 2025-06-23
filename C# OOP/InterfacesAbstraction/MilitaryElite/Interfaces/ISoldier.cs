using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Interfaces
{
    internal interface ISoldier
    {
        string Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}
