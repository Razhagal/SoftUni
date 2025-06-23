using System;
using System.Collections.Generic;

namespace EqualityLogic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SortedSet<Person> sortedPeople = new SortedSet<Person>();
            HashSet<Person> hashedPeople = new HashSet<Person>();

            int inputCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputCount; i++)
            {
                string[] splitInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = splitInput[0];
                int age = int.Parse(splitInput[1]);

                Person person = new Person(name, age);
                sortedPeople.Add(person);
                hashedPeople.Add(person);
            }

            Console.WriteLine(sortedPeople.Count);
            Console.WriteLine(hashedPeople.Count);
        }
    }
}