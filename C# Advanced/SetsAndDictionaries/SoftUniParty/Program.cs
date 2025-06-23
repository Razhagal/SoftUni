using System;
using System.Collections.Generic;

namespace SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vipGuests = new HashSet<string>();
            HashSet<string> regularGuests = new HashSet<string>();

            bool partyHasStarted = false;
            bool isVipGuest = false;
            string input = Console.ReadLine();
            while (!input.Equals("END"))
            {
                if (input.Equals("PARTY"))
                {
                    partyHasStarted = true;
                }
                else
                {
                    isVipGuest = int.TryParse(input[0].ToString(), out _);
                    if (partyHasStarted)
                    {
                        if (isVipGuest)
                        {
                            vipGuests.Remove(input);
                        }
                        else
                        {
                            regularGuests.Remove(input);
                        }
                    }
                    else
                    {
                        if (isVipGuest)
                        {
                            vipGuests.Add(input);
                        }
                        else
                        {
                            regularGuests.Add(input);
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(vipGuests.Count + regularGuests.Count);
            foreach (var guest in vipGuests)
            {
                Console.WriteLine(guest);
            }

            foreach (var guest in regularGuests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
