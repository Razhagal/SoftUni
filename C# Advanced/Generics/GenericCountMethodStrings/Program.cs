using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericCountMethodStrings
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int inputLinesCount = int.Parse(Console.ReadLine());
            List<string> stringsList = new List<string>();

            for (int i = 0; i < inputLinesCount; i++)
            {
                stringsList.Add(Console.ReadLine());
            }

            string elementToCompare = Console.ReadLine();
            Console.WriteLine(GetCountOfBiggerElements(stringsList, elementToCompare));
        }

        public static int GetCountOfBiggerElements<T>(List<T> elements, T comparedElement)
        {
            Box<string> boxWrapper = new Box<string>();
            boxWrapper.Value = comparedElement.ToString();

            return elements.Select(x => x).Where(x => boxWrapper.Value.CompareTo(x) < 0).ToList().Count;
        }
    }
}