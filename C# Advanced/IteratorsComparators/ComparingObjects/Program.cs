using System;
using System.Collections.Generic;
using System.Linq;

namespace ComparingObjects
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string input = Console.ReadLine();
            while (!input.Equals("END"))
            {
                string[] splitInput = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = splitInput[0];
                int age = int.Parse(splitInput[1]);
                string town = splitInput[2];

                Person person = new Person(name, age, town);
                people.Add(person);

                input = Console.ReadLine();
            }

            int personIndex = int.Parse(Console.ReadLine());

            int matchesCount = people.Where(x => x.CompareTo(people[personIndex - 1]) == 0).Count();
            if (matchesCount == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{matchesCount} {people.Count - matchesCount} {people.Count}");
            }
        }
    }
}