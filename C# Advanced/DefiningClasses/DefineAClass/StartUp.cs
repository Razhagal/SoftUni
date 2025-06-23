using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //int peopleCount = int.Parse(Console.ReadLine());

            //Family family = new Family();
            //for (int i = 0; i < peopleCount; i++)
            //{
            //    string[] personData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            //    family.AddMember(new Person(personData[0], int.Parse(personData[1])));
            //}

            //Person oldest = family.GetOldestMember();
            //Console.WriteLine($"{oldest.Name} {oldest.Age}");

            int peopleCount = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < peopleCount; i++)
            {
                string[] personData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                people.Add(new Person(personData[0], int.Parse(personData[1])));
            }

            List<Person> peopleFilteredByAge = people.Where(x => x.Age > 30).OrderBy(x => x.Name).ToList();
            for (int i = 0; i < peopleFilteredByAge.Count; i++)
            {
                Console.WriteLine($"{peopleFilteredByAge[i].Name} - {peopleFilteredByAge[i].Age}");
            }
        }
    }
}