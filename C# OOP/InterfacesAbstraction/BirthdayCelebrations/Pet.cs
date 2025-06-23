using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    internal class Pet : INamable, IBirthable
    {
        private string name;
        private string birthdate;

        public string Name { get { return this.name; } set { this.name = value; } }
        public string Birthdate { get { return this.birthdate; } set { this.birthdate = value; } }

        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }
    }
}
