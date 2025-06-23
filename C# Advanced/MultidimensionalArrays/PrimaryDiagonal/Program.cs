using System;
using System.Linq;

namespace PrimaryDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int[,] matrix = new int[matrixSize, matrixSize];

            int diagonalSum = 0;
            for (int row = 0; row < matrixSize; row++)
            {
                int[] rowValues = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = rowValues[col];
                    if (row == col)
                    {
                        diagonalSum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine(diagonalSum);
        }
    }
}
