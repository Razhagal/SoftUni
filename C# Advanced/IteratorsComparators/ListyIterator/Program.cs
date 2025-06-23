using System;

namespace ListyIterator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ListyIterator<string> iterator = null;

            Action<string, ListyIterator<string>> commandExecuter = (x, y) =>
            {
                switch (x)
                {
                    case "Move": Console.WriteLine(y.Move()); break;
                    case "Print": y.Print(); break;
                    case "HasNext": Console.WriteLine(y.HasNext()); break;
                    default: break;
                }
            };

            string input = Console.ReadLine();
            while (!input.Equals("END"))
            {
                string[] splitInput = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = splitInput[0];
                if (command.Equals("Create"))
                {
                    string[] createParams = new string[splitInput.Length - 1];
                    for (int i = 1; i < splitInput.Length; i++)
                    {
                        createParams[i - 1] = splitInput[i];
                    }

                    iterator = new ListyIterator<string>(createParams);
                }
                else
                {
                    commandExecuter(command, iterator);
                }

                input = Console.ReadLine();
            }
        }
    }
}