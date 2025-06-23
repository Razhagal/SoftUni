using System;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] inputRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputRow[col];
                }
            }

            string[] inputBombsPos = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < inputBombsPos.Length; i++)
            {
                int[] bombPosIndexes = inputBombsPos[i].Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int bombRow = bombPosIndexes[0];
                int bombCol = bombPosIndexes[1];

                if (IsValidPosition(bombRow, bombCol, ref matrix))
                {
                    if (matrix[bombRow, bombCol] > 0)
                    {
                        if (IsValidPosition(bombRow - 1, bombCol - 1, ref matrix) && matrix[bombRow - 1, bombCol - 1] > 0)
                        {
                            // Top-Left
                            matrix[bombRow - 1, bombCol - 1] -= matrix[bombRow, bombCol];
                        }

                        if (IsValidPosition(bombRow - 1, bombCol, ref matrix) && matrix[bombRow - 1, bombCol] > 0)
                        {
                            // Top-Center
                            matrix[bombRow - 1, bombCol] -= matrix[bombRow, bombCol];
                        }

                        if (IsValidPosition(bombRow - 1, bombCol + 1, ref matrix) && matrix[bombRow - 1, bombCol + 1] > 0)
                        {
                            // Top-Right
                            matrix[bombRow - 1, bombCol + 1] -= matrix[bombRow, bombCol];
                        }

                        if (IsValidPosition(bombRow, bombCol - 1, ref matrix) && matrix[bombRow, bombCol - 1] > 0)
                        {
                            // Middle-Left
                            matrix[bombRow, bombCol - 1] -= matrix[bombRow, bombCol];
                        }

                        if (IsValidPosition(bombRow, bombCol + 1, ref matrix) && matrix[bombRow, bombCol + 1] > 0)
                        {
                            // Middle-Right
                            matrix[bombRow, bombCol + 1] -= matrix[bombRow, bombCol];
                        }

                        if (IsValidPosition(bombRow + 1, bombCol - 1, ref matrix) && matrix[bombRow + 1, bombCol - 1] > 0)
                        {
                            // Bottom-Left
                            matrix[bombRow + 1, bombCol - 1] -= matrix[bombRow, bombCol];
                        }

                        if (IsValidPosition(bombRow + 1, bombCol, ref matrix) && matrix[bombRow + 1, bombCol] > 0)
                        {
                            // Bottom-Center
                            matrix[bombRow + 1, bombCol] -= matrix[bombRow, bombCol];
                        }

                        if (IsValidPosition(bombRow + 1, bombCol + 1, ref matrix) && matrix[bombRow + 1, bombCol + 1] > 0)
                        {
                            // Bottom-Right
                            matrix[bombRow + 1, bombCol + 1] -= matrix[bombRow, bombCol];
                        }

                        matrix[bombRow, bombCol] = 0;
                    }
                }
            }

            int aliveCellsCount = 0;
            int aliveCellsValuesSum = 0;
            string matrixString = string.Empty;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrixString += (matrix[row, col] + " ");
                    if (matrix[row, col] > 0)
                    {
                        aliveCellsCount++;
                        aliveCellsValuesSum += matrix[row, col];
                    }
                }

                matrixString += Environment.NewLine;
            }

            Console.WriteLine($"Alive cells: {aliveCellsCount}");
            Console.WriteLine($"Sum: {aliveCellsValuesSum}");
            Console.WriteLine(matrixString);
        }

        private static bool IsValidPosition(int row, int col, ref int[,] matrix)
        {
            if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
            {
                return true;
            }

            return false;
        }
    }
}
