using System;

namespace Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[,] field = new string[fieldSize, fieldSize];
            int totalCoalCount = 0;
            int currentRowIndex = 0;
            int currentColIndex = 0;

            for (int row = 0; row < field.GetLength(0); row++)
            {
                string[] rowData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = rowData[col];
                    if (field[row, col].Equals("c"))
                    {
                        totalCoalCount++;
                    }

                    if (field[row, col].Equals("s"))
                    {
                        currentRowIndex = row;
                        currentColIndex = col;
                    }
                }
            }

            int collectedCoal = 0;
            bool steppedOnEnd = false;
            for (int i = 0; i < commands.Length; i++)
            {
                string currentCommand = commands[i];

                if (currentCommand.Equals("left"))
                {
                    if (IsValidPosition(currentRowIndex, currentColIndex - 1, ref field))
                    {
                        currentColIndex -= 1;
                    }
                }
                else if (currentCommand.Equals("right"))
                {
                    if (IsValidPosition(currentRowIndex, currentColIndex + 1, ref field))
                    {
                        currentColIndex += 1;
                    }
                }
                else if (currentCommand.Equals("up"))
                {
                    if (IsValidPosition(currentRowIndex - 1, currentColIndex, ref field))
                    {
                        currentRowIndex -= 1;
                    }
                }
                else if (currentCommand.Equals("down"))
                {
                    if (IsValidPosition(currentRowIndex + 1, currentColIndex, ref field))
                    {
                        currentRowIndex += 1;
                    }
                }

                switch (field[currentRowIndex, currentColIndex])
                {
                    case "e":
                        steppedOnEnd = true;
                        break;
                    case "c":
                        collectedCoal++;
                        field[currentRowIndex, currentColIndex] = "*";
                        break;
                    default:
                        break;
                }

                if (!steppedOnEnd)
                {
                    if (collectedCoal == totalCoalCount)
                    {
                        Console.WriteLine($"You collected all coals! ({currentRowIndex}, {currentColIndex})");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine($"Game over! ({currentRowIndex}, {currentColIndex})");
                    return;
                }
            }

            Console.WriteLine($"{totalCoalCount - collectedCoal} coals left. ({currentRowIndex}, {currentColIndex})");
        }

        private static bool IsValidPosition(int row, int col, ref string[,] matrix)
        {
            if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
            {
                return true;
            }

            return false;
        }
    }
}
