using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    internal class LieutenantGeneral : Soldier, IRewardable, ILieutenantGeneral
    {
        private decimal salary;
        private Dictionary<string, Private> commandedPrivates;

        public decimal Salary { get { return this.salary; } set { this.salary = value; } }
        public Dictionary<string, Private> CommandedPrivates { get { return this.commandedPrivates; } private set { this.commandedPrivates = value; } }

        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
            this.CommandedPrivates = new Dictionary<string, Private>();
        }

        public void AddPrivate(Private privateSoldier)
        {
            this.CommandedPrivates.Add(privateSoldier.Id, privateSoldier);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"{base.ToString()} Salary: {this.Salary:F2}");
            builder.AppendLine("Privates:");
            foreach (Private privateSoldier in this.commandedPrivates.Values)
            {
                builder.AppendLine("  " + privateSoldier.ToString());
            }

            return builder.ToString().TrimEnd();
        }
    }
}
