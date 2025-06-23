using System;

namespace KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[,] board = new string[size, size];

            for (int row = 0; row < board.GetLength(0); row++)
            {
                string inputRow = Console.ReadLine();
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = inputRow[col].ToString();
                }
            }
            
            int knightsRemoved = 0;
            while (true)
            {
                int maxTargetsCount = 0;
                int currentStrongestRowIndex = 0;
                int currentStrongestColIndex = 0;
                for (int row = 0; row < board.GetLength(0); row++)
                {
                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        int targetsCount = 0;
                        if (board[row, col].Equals("K"))
                        {
                            int knightHitRow = row - 1;
                            int knightHitCol = col - 2;
                            targetsCount += CheckForKnightInPosition(knightHitRow, knightHitCol, ref board);

                            knightHitCol = col + 2;
                            targetsCount += CheckForKnightInPosition(knightHitRow, knightHitCol, ref board);

                            knightHitRow = row - 2;
                            knightHitCol = col - 1;
                            targetsCount += CheckForKnightInPosition(knightHitRow, knightHitCol, ref board);

                            knightHitCol = col + 1;
                            targetsCount += CheckForKnightInPosition(knightHitRow, knightHitCol, ref board);

                            knightHitRow = row + 1;
                            knightHitCol = col - 2;
                            targetsCount += CheckForKnightInPosition(knightHitRow, knightHitCol, ref board);

                            knightHitCol = col + 2;
                            targetsCount += CheckForKnightInPosition(knightHitRow, knightHitCol, ref board);

                            knightHitRow = row + 2;
                            knightHitCol = col - 1;
                            targetsCount += CheckForKnightInPosition(knightHitRow, knightHitCol, ref board);

                            knightHitCol = col + 1;
                            targetsCount += CheckForKnightInPosition(knightHitRow, knightHitCol, ref board);
                        }

                        if (targetsCount > maxTargetsCount)
                        {
                            maxTargetsCount = targetsCount;
                            currentStrongestRowIndex = row;
                            currentStrongestColIndex = col;
                        }
                    }
                }

                if (maxTargetsCount > 0)
                {
                    board[currentStrongestRowIndex, currentStrongestColIndex] = "0";
                    knightsRemoved++;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(knightsRemoved);
        }

        private static int CheckForKnightInPosition(int row, int col, ref string[,] board)
        {
            if (IsValidPosition(row, col, ref board) && board[row, col].Equals("K"))
            {
                return 1;
            }

            return 0;
        }

        private static bool IsValidPosition(int row, int col, ref string[,] boardMatrix)
        {
            if (row < 0 || row >= boardMatrix.GetLength(0) || col < 0 || col >= boardMatrix.GetLength(1))
            {
                return false;
            }

            return true;
        }
    }
}
