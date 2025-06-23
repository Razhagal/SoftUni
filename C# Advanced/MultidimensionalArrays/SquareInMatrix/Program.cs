using System;
using System.Linq;

namespace SquareInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputDimentions = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int rowsCount = inputDimentions[0];
            int colsCount = inputDimentions[1];
            string[,] matrix = new string[rowsCount, colsCount];

            for (int row = 0; row < rowsCount; row++)
            {
                string[] inputRow = Console.ReadLine().Split(" ");
                for (int col = 0; col < colsCount; col++)
                {
                    matrix[row, col] = inputRow[col];
                }
            }

            int squaresFound = 0;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (matrix[row, col].Equals(matrix[row, col + 1]) &&
                        matrix[row,col].Equals(matrix[row + 1, col]) &&
                        matrix[row, col].Equals(matrix[row + 1, col + 1]))
                    {
                        squaresFound++;
                    }
                }
            }

            Console.WriteLine(squaresFound);
        }
    }
}
