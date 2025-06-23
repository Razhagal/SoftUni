using System;
using System.Collections.Generic;

namespace UniqueUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            HashSet<string> usernames = new HashSet<string>();

            for (int i = 0; i < count; i++)
            {
                string username = Console.ReadLine();
                if (!usernames.Contains(username))
                {
                    usernames.Add(username);
                }
            }

            foreach (var user in usernames)
            {
                Console.WriteLine(user);
            }
        }
    }
}
