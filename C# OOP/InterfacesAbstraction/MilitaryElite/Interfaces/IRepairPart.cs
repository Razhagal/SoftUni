using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Interfaces
{
    internal interface IRepairPart
    {
        string PartName { get; set; }
        int HoursWorked { get; set; }
    }
}
