using System;
using System.Collections.Generic;

namespace ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> carNumbers = new HashSet<string>();

            string command = Console.ReadLine();
            while (!command.Equals("END"))
            {
                string[] splitCommand = command.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string direction = splitCommand[0];
                string carNumber = splitCommand[1];

                if (direction.Equals("IN"))
                {
                    carNumbers.Add(carNumber);
                }
                else if (direction.Equals("OUT"))
                {
                    carNumbers.Remove(carNumber);
                }

                command = Console.ReadLine();
            }

            if (carNumbers.Count > 0)
            {
                foreach (var number in carNumbers)
                {
                    Console.WriteLine(number);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
