using System;
using System.Linq;

namespace MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputDimentions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rowsCount = inputDimentions[0];
            int colsCount = inputDimentions[1];
            string[,] matrix = new string[rowsCount, colsCount];

            for (int row = 0; row < rowsCount; row++)
            {
                string[] inputRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < colsCount; col++)
                {
                    matrix[row, col] = inputRow[col];
                }
            }

            string command = Console.ReadLine();
            while (!command.Equals("END"))
            {
                string[] commandParams = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (commandParams.Length == 5)
                {
                    if (commandParams[0].Equals("swap"))
                    {
                        int firstRowIndex = int.Parse(commandParams[1]);
                        int firstColIndex = int.Parse(commandParams[2]);
                        int secondRowIndex = int.Parse(commandParams[3]);
                        int secondColIndex = int.Parse(commandParams[4]);
                        if (IsValidPosition(firstRowIndex, firstColIndex, secondRowIndex, secondColIndex, ref matrix))
                        {
                            string tempValue = matrix[firstRowIndex, firstColIndex];
                            matrix[firstRowIndex, firstColIndex] = matrix[secondRowIndex, secondColIndex];
                            matrix[secondRowIndex, secondColIndex] = tempValue;

                            PrintMatrix(ref matrix);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                command = Console.ReadLine();
            }
        }

        private static bool IsValidPosition(int firstRow, int firstCol, int secondRow, int secondCol, ref string[,] matrix)
        {
            if (firstRow < 0 || firstRow >= matrix.GetLength(0) ||
                firstCol < 0 || firstCol >= matrix.GetLength(1) ||
                secondRow < 0 || secondRow >= matrix.GetLength(0) ||
                secondCol < 0 || secondCol >= matrix.GetLength(1))
            {
                return false;
            }

            return true;
        }

        private static void PrintMatrix(ref string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
