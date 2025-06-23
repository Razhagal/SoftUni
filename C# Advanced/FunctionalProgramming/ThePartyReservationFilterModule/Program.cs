using System;
using System.Collections.Generic;
using System.Linq;

namespace ThePartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> peopleNames = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            HashSet<string> filters = new HashSet<string>();

            string command = Console.ReadLine();
            while (!command.Equals("Print"))
            {
                int commandPartSeparatorIndex = command.IndexOf(';');
                string commandPart = command.Substring(0, commandPartSeparatorIndex);
                string filterWithParam = command.Substring(commandPartSeparatorIndex + 1, command.Length - commandPartSeparatorIndex - 1);
                if (commandPart.Equals("Add filter"))
                {
                    filters.Add(filterWithParam);
                }
                else if (commandPart.Equals("Remove filter"))
                {
                    filters.Remove(filterWithParam);
                }

                command = Console.ReadLine();
            }

            Func<string, string, string, bool> matchRemoveNamesFunc = MatchFilter();
            foreach (var filterWithParam in filters)
            {
                string[] splitFilter = filterWithParam.Split(";", StringSplitOptions.RemoveEmptyEntries);
                string filterType = splitFilter[0];
                string filterParam = splitFilter[1];

                Predicate<string> matcher = x => matchRemoveNamesFunc(filterType, filterParam, x);
                peopleNames.RemoveAll(matcher);
            }

            Console.WriteLine(string.Join(" ", peopleNames));
        }

        private static Func<string, string, string, bool> MatchFilter() =>
            (x, y, z) => x switch
            {
                "Starts with" => z.StartsWith(y),
                "Ends with" => z.EndsWith(y),
                "Length" => z.Length == int.Parse(y),
                "Contains" => z.Contains(y),
                _ => false
            };
    }
}