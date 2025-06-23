using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericCountMethodDoubles
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int inputLinesCount = int.Parse(Console.ReadLine());
            List<double> stringsList = new List<double>();

            for (int i = 0; i < inputLinesCount; i++)
            {
                stringsList.Add(double.Parse(Console.ReadLine()));
            }

            double elementToCompare = double.Parse(Console.ReadLine());
            Console.WriteLine(GetCountOfBiggerElements(stringsList, elementToCompare));
        }

        public static int GetCountOfBiggerElements<T>(List<T> elements, T comparedElement)
        {
            Box<double> boxWrapper = new Box<double>();
            boxWrapper.Value = double.Parse(comparedElement.ToString());

            return elements.Select(x => x).Where(x => boxWrapper.Value.CompareTo(x) < 0).ToList().Count;
        }
    }
}