using System;

namespace RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputDimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int inputRows = int.Parse(inputDimensions[0]);
            int inputCols = int.Parse(inputDimensions[1]);
            string[,] field = new string[inputRows, inputCols];

            int playerRowIndex = 0;
            int playerColIndex = 0;
            for (int row = 0; row < field.GetLength(0); row++)
            {
                string inputRow = Console.ReadLine();
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = inputRow[col].ToString();

                    if (field[row, col].Equals("P"))
                    {
                        playerRowIndex = row;
                        playerColIndex = col;
                    }
                }
            }

            string directionsCommand = Console.ReadLine();
            bool hasEscaped = false;
            bool hasDied = false;
            int newRowIndex = 0;
            int newColIndex = 0;
            for (int i = 0; i < directionsCommand.Length; i++)
            {
                string currentDirection = directionsCommand[i].ToString();
                if (currentDirection.Equals("L"))
                {
                    newRowIndex = playerRowIndex;
                    newColIndex = playerColIndex - 1;
                }
                else if (currentDirection.Equals("R"))
                {
                    newRowIndex = playerRowIndex;
                    newColIndex = playerColIndex + 1;
                }
                else if (currentDirection.Equals("U"))
                {
                    newRowIndex = playerRowIndex - 1;
                    newColIndex = playerColIndex;
                }
                else if (currentDirection.Equals("D"))
                {
                    newRowIndex = playerRowIndex + 1;
                    newColIndex = playerColIndex;
                }

                if (IsLeavingTheField(newRowIndex, newColIndex, ref field))
                {
                    hasEscaped = true;
                }

                if (hasEscaped)
                {
                    field[playerRowIndex, playerColIndex] = ".";
                    MultiplyBunnies(ref field);
                    PrintField(ref field);
                    Console.WriteLine($"won: {playerRowIndex} {playerColIndex}");
                    break;
                }
                else
                {
                    field[playerRowIndex, playerColIndex] = ".";
                    playerRowIndex = newRowIndex;
                    playerColIndex = newColIndex;

                    if (field[playerRowIndex, playerColIndex].Equals("B"))
                    {
                        hasDied = true;
                    }
                    else
                    {
                        field[playerRowIndex, playerColIndex] = "P";
                    }
                }

                MultiplyBunnies(ref field);
                if (field[playerRowIndex, playerColIndex].Equals("B"))
                {
                    // A bunny ate the player
                    hasDied = true;
                }

                if (hasDied)
                {
                    PrintField(ref field);
                    Console.WriteLine($"dead: {playerRowIndex} {playerColIndex}");
                    break;
                }
            }
        }

        private static bool IsLeavingTheField(int row, int col, ref string[,] field)
        {
            if (row < 0 || row >= field.GetLength(0) || col < 0 || col >= field.GetLength(1))
            {
                return true;
            }

            return false;
        }

        private static bool IsValidPosition(int row, int col, ref string[,] field)
        {
            if (row >= 0 && row < field.GetLength(0) && col >= 0 && col < field.GetLength(1))
            {
                return true;
            }

            return false;
        }

        private static void MultiplyBunnies(ref string[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (field[row, col].Equals("B"))
                    {
                        if (IsValidPosition(row, col - 1, ref field) && !IsAlreadyBunny(row, col - 1, ref field))
                        {
                            field[row, col - 1] = "b";
                        }

                        if (IsValidPosition(row, col + 1, ref field) && !IsAlreadyBunny(row, col + 1, ref field))
                        {
                            field[row, col + 1] = "b";
                        }

                        if (IsValidPosition(row - 1, col, ref field) && !IsAlreadyBunny(row - 1, col, ref field))
                        {
                            field[row - 1, col] = "b";
                        }

                        if (IsValidPosition(row + 1, col, ref field) && !IsAlreadyBunny(row + 1, col, ref field))
                        {
                            field[row + 1, col] = "b";
                        }
                    }
                }
            }

            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (field[row, col].Equals("b"))
                    {
                        field[row, col] = "B";
                    }
                }
            }
        }

        private static bool IsAlreadyBunny(int row, int col, ref string[,] field)
        {
            return field[row, col].Equals("B");
        }

        private static void PrintField(ref string[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}