using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            Func<string, string, List<string>, List<string>> filterNamesFunc = FilterNames();
            string command = Console.ReadLine();
            while (!command.Equals("Party!"))
            {
                string[] splitCommand = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string mainCommand = splitCommand[0];
                string subCommand = splitCommand[1];
                string commandParameter = splitCommand[2];

                if (mainCommand.Equals("Double"))
                {
                    List<string> filteredNames = filterNamesFunc(subCommand, commandParameter, names);

                    for (int i = 0; i < filteredNames.Count; i++)
                    {
                        string name = filteredNames[i];
                        if (names.Contains(name))
                        {
                            names.Insert(names.IndexOf(name), name);
                        }
                    }
                }
                else if (mainCommand.Equals("Remove"))
                {
                    List<string> filteredNames = filterNamesFunc(subCommand, commandParameter, names);

                    for (int i = 0; i < filteredNames.Count; i++)
                    {
                        names.RemoveAll(x => x.Equals(filteredNames[i]));
                    }
                }

                //Console.WriteLine(string.Join(", ", names));

                command = Console.ReadLine();
            }

            if (names.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", names)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static Func<string, string, List<string>, List<string>> FilterNames() => 
            (x, y, z) => x switch
            {
                "StartsWith" => z.Select(n => n).Where(n => n.StartsWith(y)).ToList(),
                "EndsWith" => z.Select(n => n).Where(n => n.EndsWith(y)).ToList(),
                "Length" => z.Select(n => n).Where(n => n.Length == int.Parse(y)).ToList(),
                _ => null
            };
        
    }
}