using System;
using System.Collections.Generic;
using System.Linq;

namespace FilterByAge
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int inputCount = int.Parse(Console.ReadLine());
            Person[] persons = new Person[inputCount];
            for (int i = 0; i < inputCount; i++)
            {
                string[] splitInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

                persons[i] = new Person();
                persons[i].Name = splitInput[0];
                persons[i].Age = int.Parse(splitInput[1]);
            }

            string ageFilterType = Console.ReadLine();
            int ageFilter = int.Parse(Console.ReadLine());
            string nameAgeFilter = Console.ReadLine();

            Func<int, bool> ageTesterFunc = FilterByAge(ageFilterType, ageFilter);
            Action<Person> printer = CreatePrintFormat(nameAgeFilter);

            PrintFilteredPeople(persons, ageTesterFunc, printer);
        }

        private static Func<int, bool> FilterByAge(string filterType, int age)
        {
            switch (filterType)
            {
                case "younger": return x => x < age;
                case "older": return x => x >= age;
                default: return null;
            }
        }

        private static Action<Person> CreatePrintFormat(string format)
        {
            switch (format)
            {
                case "name": return x => Console.WriteLine($"{x.Name}");
                case "age": return x => Console.WriteLine($"{x.Age}");
                case "name age": return x => Console.WriteLine($"{x.Name} - {x.Age}");
                default: return null;
            }
        }

        private static void PrintFilteredPeople(Person[] people, Func<int, bool> filter, Action<Person> printer)
        {
            foreach (var person in people)
            {
                if (filter(person.Age))
                {
                    printer(person);
                }
            }
        }
    }
}