using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace EqualityLogic
{
    public class Person : IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public int CompareTo(Person other)
        {
            int result = this.Name.CompareTo(other.Name);
            if (result == 0)
            {
                return this.Age.CompareTo(other.Age);
            }

            return result;
        }

        public override bool Equals(object obj)
        {
            Person other = (Person)obj;
            return this.Name.Equals(other.Name) && this.Age.Equals(other.Age);
        }

        public override int GetHashCode()
        {
            int hashCode = this.Name.GetHashCode(StringComparison.OrdinalIgnoreCase);
            hashCode += this.Age;

            return hashCode;
        }
    }
}