using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    internal class Repair : IRepairPart
    {
        private string partName;
        private int hoursWorked;

        public string PartName { get { return this.partName; } set { partName = value; } }
        public int HoursWorked { get { return this.hoursWorked; } set { hoursWorked = value; } }

        public Repair(string partName, int hoursWorked)
        {
            this.PartName = partName;
            this.HoursWorked = hoursWorked;
        }

        public override string ToString()
        {
            return $"Part Name: {this.PartName} Hours Worked: {this.HoursWorked}";
        }
    }
}
