using ExplicitInterfaces.Interfaces;
using ExplicitInterfaces.Models;
using System;

namespace ExplicitInterfaces
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            IResident resident;
            IPerson person;
            while (!input.Equals("End"))
            {
                string[] splitInput = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Citizen citizen = new Citizen(splitInput[0], splitInput[1], int.Parse(splitInput[2]));
                resident = citizen;
                person = citizen;

                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());

                input = Console.ReadLine();
            }
        }
    }
}
