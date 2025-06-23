using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    internal class Spy : Soldier, ISpy
    {
        private int codeNumber;

        public int CodeNumber { get { return this.codeNumber; } set { this.codeNumber = value; } }

        public Spy(string id, string firstName, string lastName, int codeNumber)
            : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"{base.ToString()}");
            builder.AppendLine($"Code Number: {this.CodeNumber}");
            return builder.ToString().Trim();
        }
    }
}
