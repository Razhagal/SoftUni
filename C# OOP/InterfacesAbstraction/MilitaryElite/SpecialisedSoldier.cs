using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    internal abstract class SpecialisedSoldier : Soldier, IRewardable, ICorps
    {
        private decimal salary;
        private string corps;

        public decimal Salary { get { return this.salary; } set { this.salary = value; } }
        public string Corps { get { return this.corps; } set { this.corps = value; } }

        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
            this.Corps = corps;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"{base.ToString()} Salary: {this.Salary:F2}");
            builder.AppendLine($"Corps: {this.Corps}");
            return builder.ToString().Trim();
        }
    }
}
