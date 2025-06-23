using System;
using System.Linq;

namespace DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int[,] matrix = new int[matrixSize, matrixSize];

            int primaryDiagonalSum = 0;
            int secondaryDiagonalSum = 0;
            for (int row = 0; row < matrixSize; row++)
            {
                int[] rowValues = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = rowValues[col];
                    if (row == col)
                    {
                        primaryDiagonalSum += matrix[row, col];
                    }

                    if (col == matrixSize - row - 1)
                    {
                        secondaryDiagonalSum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine(Math.Abs(primaryDiagonalSum - secondaryDiagonalSum));
        }
    }
}
