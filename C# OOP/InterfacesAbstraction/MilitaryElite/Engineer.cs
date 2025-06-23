using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    internal class Engineer : SpecialisedSoldier, IRepairer
    {
        private List<Repair> repairsDone;

        public List<Repair> Repairs { get { return this.repairsDone; } private set { this.repairsDone = value; } }

        public Engineer(string id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Repairs = new List<Repair>();
        }

        public void AddRepair(Repair repair)
        {
            this.Repairs.Add(repair);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(base.ToString());
            builder.AppendLine("Repairs:");
            for (int i = 0; i < this.repairsDone.Count; i++)
            {
                builder.AppendLine("  " + this.repairsDone[i].ToString());
            }

            return builder.ToString().TrimEnd();
        }
    }
}