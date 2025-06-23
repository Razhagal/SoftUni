using System;
using System.Collections.Generic;

namespace Stack
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CustomStack<int> customStack = new CustomStack<int>();

            string input = Console.ReadLine();
            while (!input.Equals("END"))
            {
                string[] splitInput = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                string command = splitInput[0];
                if (command.Equals("Push"))
                {
                    for (int i = 1; i < splitInput.Length; i++)
                    {
                        customStack.Push(int.Parse(splitInput[i]));
                    }
                }
                else if (command.Equals("Pop"))
                {
                    if (customStack.Count == 0)
                    {
                        Console.WriteLine("No elements");
                    }
                    else
                    {
                        customStack.Pop();
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var item in customStack)
            {
                Console.WriteLine(item);
            }

            foreach (var item in customStack)
            {
                Console.WriteLine(item);
            }
        }
    }
}