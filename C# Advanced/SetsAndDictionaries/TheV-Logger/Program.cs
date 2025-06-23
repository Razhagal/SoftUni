using System;
using System.Collections.Generic;
using System.Linq;

namespace TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, SortedSet<string>> vloggersWithTheirFollowers = new Dictionary<string, SortedSet<string>>();
            Dictionary<string, SortedSet<string>> vloggersWithPeopleTheyFollow = new Dictionary<string, SortedSet<string>>();

            string command = Console.ReadLine();
            while (!command.Equals("Statistics"))
            {
                string[] splitCommand = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string vloggerName = splitCommand[0];
                string subCommand = splitCommand[1];
                if (subCommand.Equals("joined"))
                {
                    if (!vloggersWithTheirFollowers.ContainsKey(vloggerName))
                    {
                        vloggersWithTheirFollowers.Add(vloggerName, new SortedSet<string>());
                        vloggersWithPeopleTheyFollow.Add(vloggerName, new SortedSet<string>());
                    }
                }
                else if (subCommand.Equals("followed"))
                {
                    string followedVloggerName = splitCommand[2];
                    if (vloggersWithTheirFollowers.ContainsKey(vloggerName) && vloggersWithTheirFollowers.ContainsKey(followedVloggerName))
                    {
                        if (!vloggerName.Equals(followedVloggerName) && !vloggersWithPeopleTheyFollow[vloggerName].Contains(followedVloggerName))
                        {
                            vloggersWithPeopleTheyFollow[vloggerName].Add(followedVloggerName);
                            vloggersWithTheirFollowers[followedVloggerName].Add(vloggerName);
                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"The V-Logger has a total of {vloggersWithTheirFollowers.Count} vloggers in its logs.");

            vloggersWithTheirFollowers = vloggersWithTheirFollowers.OrderByDescending(x => x.Value.Count)
                .ThenBy(kvp => vloggersWithPeopleTheyFollow[kvp.Key].Count).ToDictionary(x => x.Key, x => x.Value);

            List<string> sortedVloggers = vloggersWithTheirFollowers.Keys.ToList();

            //for (int i = 0; i < sortedVloggers.Count - 1; i++)
            //{
            //    for (int j = i + 1; j < sortedVloggers.Count; j++)
            //    {
            //        if (vloggersWithTheirFollowers[sortedVloggers[i]].Count < vloggersWithTheirFollowers[sortedVloggers[j]].Count)
            //        {
            //            string tempVlogger = sortedVloggers[i];
            //            sortedVloggers[i] = sortedVloggers[j];
            //            sortedVloggers[j] = tempVlogger;
            //        }
            //    }
            //}

            //for (int i = 0; i < sortedVloggers.Count - 1; i++)
            //{
            //    for (int j = i + 1; j < sortedVloggers.Count; j++)
            //    {
            //        if (vloggersWithTheirFollowers[sortedVloggers[i]].Count == vloggersWithTheirFollowers[sortedVloggers[j]].Count)
            //        {
            //            if (vloggersWithPeopleTheyFollow[sortedVloggers[i]].Count > vloggersWithPeopleTheyFollow[sortedVloggers[j]].Count)
            //            {
            //                string tempVlogger = sortedVloggers[i];
            //                sortedVloggers[i] = sortedVloggers[j];
            //                sortedVloggers[j] = tempVlogger;
            //            }
            //        }
            //        else
            //        {
            //            break;
            //        }
            //    }
            //}

            for (int i = 0; i < sortedVloggers.Count; i++)
            {
                string vloggerName = sortedVloggers[i];
                Console.WriteLine($"{i + 1}. {vloggerName} : {vloggersWithTheirFollowers[vloggerName].Count} followers, {vloggersWithPeopleTheyFollow[vloggerName].Count} following");
                if (i == 0)
                {
                    foreach (var vlogger in vloggersWithTheirFollowers[vloggerName])
                    {
                        Console.WriteLine($"*  {vlogger}");
                    }
                }
            }

            //foreach (var vlogger in vloggersWithTheirFollowers)
            //{
            //    Console.WriteLine($"{vlogger.Key} : {vlogger.Value.Count} - {vloggersWithPeopleTheyFollow[vlogger.Key].Count}");
            //}
        }
    }
}