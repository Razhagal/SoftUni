using System;
using System.Globalization;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DateModifier dateModifier = new DateModifier();

            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            int daysDifference = dateModifier.GetDaysDifference(firstDate, secondDate);
            Console.WriteLine(daysDifference);
        }
    }
}