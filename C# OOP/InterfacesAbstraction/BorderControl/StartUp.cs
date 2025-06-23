using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> identifiableEntities = new List<IIdentifiable>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input.Equals("End"))
                {
                    break;
                }

                string[] splitInput = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                IIdentifiable entity;
                if (splitInput.Length == 3)
                {
                    entity = new Citizen(splitInput[0], int.Parse(splitInput[1]), splitInput[2]);
                }
                else
                {
                    entity = new Robot(splitInput[0], splitInput[1]);
                }

                identifiableEntities.Add(entity);
            }

            string fakeIdEnd = Console.ReadLine();
            var results = identifiableEntities.Where(x => x.Id.EndsWith(fakeIdEnd));

            foreach (var entity in results)
            {
                Console.WriteLine(entity.Id);
            }
        }
    }
}
