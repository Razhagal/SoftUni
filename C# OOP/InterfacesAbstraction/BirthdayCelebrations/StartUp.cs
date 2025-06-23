using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebrations
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthable> birthableEntities = new List<IBirthable>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input.Equals("End"))
                {
                    break;
                }

                string[] splitInput = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                IBirthable entity;
                if (splitInput[0].Equals("Citizen"))
                {
                    entity = new Citizen(splitInput[1], int.Parse(splitInput[2]), splitInput[3], splitInput[4]);
                }
                else if (splitInput[0].Equals("Pet"))
                {
                    entity = new Pet(splitInput[1], splitInput[2]);
                }
                else
                {
                    continue;
                }

                birthableEntities.Add(entity);
            }

            string birthYear = Console.ReadLine();
            var results = birthableEntities.Where(x => x.Birthdate.EndsWith(birthYear));
            foreach (var entity in results)
            {
                Console.WriteLine(entity.Birthdate);
            }
        }
    }
}