using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTextEditor
{
    class Program
    {
        /*
            1 someString - appends someString to the end of the text
            2 count - erases the last count elements from the text
            3 index - returns the element at index char from the text (if we have “klmn” and we get 3 4, the 4-th char is ‘n’)
            4 - undoes the last not undone command of type 1 / 2 and returns the text to the state before that operation
         */

        static void Main(string[] args)
        {
            int commandsCount = int.Parse(Console.ReadLine());
            Stack<string> commandsHistory = new Stack<string>();
            StringBuilder textBuilder = new StringBuilder();

            for (int i = 0; i < commandsCount; i++)
            {
                // TODO:
                // - Execute command;
                // - Add "add" and "remove" commands to the commandsHistory; - DONE
                // - Use StringBuilder for text representation*; - DONE
                // - On "add" command add the value to the text representation; - DONE
                // - On "remove" command remove the last N character from the text. In the history stack add the command with the removed text; - DONE
                // - On "undo" command pop the last recorded command from the history and "revert it" - if "remove" add the value back in, if "add" remove the test;
                // - On "preview" command just fetch the N-th char from the text representation; - DONE


                string command = Console.ReadLine();
                string[] splitCommand = command.Split(" ");

                switch (splitCommand[0])
                {
                    case "1":
                        commandsHistory.Push(command);
                        ExecuteAddCommand(splitCommand[1], ref textBuilder);
                        break;
                    case "2":
                        if (textBuilder.Length > 0)
                        {
                            string removedText = ExecuteRemoveCommandAndReturnRemoved(int.Parse(splitCommand[1]), ref textBuilder);
                            commandsHistory.Push(splitCommand[0] + " " + removedText);
                        }
                        break;
                    case "3":
                        Console.WriteLine(textBuilder[int.Parse(splitCommand[1]) - 1]);
                        break;
                    case "4":
                        ExecuteUndoCommand(ref textBuilder, ref commandsHistory);
                        break;
                }
            }
        }

        private static void ExecuteAddCommand(string textToAdd, ref StringBuilder textBuilder)
        {
            textBuilder.Append(textToAdd);
        }

        private static string ExecuteRemoveCommandAndReturnRemoved(int elementsToRemoveCount, ref StringBuilder textBuilder)
        {
            string removedText = textBuilder.ToString().Substring(textBuilder.Length - elementsToRemoveCount);
            textBuilder.Remove(textBuilder.Length - elementsToRemoveCount, elementsToRemoveCount);

            return removedText;
        }

        private static void ExecuteUndoCommand(ref StringBuilder textBuilder, ref Stack<string> historyStack)
        {
            if (historyStack.Count > 0)
            {
                string lastCommand = historyStack.Pop();
                string[] splitCommand = lastCommand.Split(" ");
                if (splitCommand[0].Equals("1"))
                {
                    RemoveTextFromEnd(splitCommand[1], ref textBuilder);
                }
                else if (splitCommand[0].Equals("2"))
                {
                    ExecuteAddCommand(splitCommand[1], ref textBuilder);
                }
            }
        }

        private static void RemoveTextFromEnd(string textToRemove, ref StringBuilder textBuilder)
        {
            textBuilder.Remove(textBuilder.ToString().LastIndexOf(textToRemove), textToRemove.Length);
        }
    }
}
