using System;
using System.Collections.Generic;

namespace Day_11_Dumbo_Octopus
{
    class Program
    {
        static int Step(int X, int Y, int xCount, int yCount, List<List<int>> board, int flasesOfStep)
        {

            if (Y < yCount && X != 0 && X < xCount && Y != 0 && board[X][Y] >= 10)
            {
                board[X + 1][Y + 1]++;
                board[X + 1][Y]++;
                board[X + 1][Y - 1]++;
                board[X][Y + 1]++;
                board[X][Y - 1]++;
                board[X - 1][Y + 1]++;
                board[X - 1][Y]++;
                board[X - 1][Y - 1]++;
                flasesOfStep++;
                board[X][Y] = -1000;
                flasesOfStep += Step(X - 1, Y - 1, xCount, yCount, board, 0);
                flasesOfStep += Step(X - 1, Y, xCount, yCount, board, 0);
                flasesOfStep += Step(X - 1, Y + 1, xCount, yCount, board, 0);
                flasesOfStep += Step(X, Y - 1, xCount, yCount, board, 0);
                flasesOfStep += Step(X, Y + 1, xCount, yCount, board, 0);
                flasesOfStep += Step(X + 1, Y, xCount, yCount, board, 0);
                flasesOfStep += Step(X + 1, Y - 1, xCount, yCount, board, 0);
                flasesOfStep += Step(X + 1, Y + 1, xCount, yCount, board, 0);

            }
            if (X == 0 && Y == 0 && board[X][Y] >= 10)
            {
                board[X + 1][Y]++;
                board[X + 1][Y + 1]++;
                board[X][Y + 1]++;
                flasesOfStep++;
                board[X][Y] = -1000;
                flasesOfStep += Step(X + 1, Y, xCount, yCount, board, 0);
                flasesOfStep += Step(X + 1, Y + 1, xCount, yCount, board, 0);
                flasesOfStep += Step(X, Y + 1, xCount, yCount, board, 0);

            }
            if (X == 0 && Y != 0 && Y < yCount && board[X][Y] >= 10)
            {
                board[X][Y - 1]++;
                board[X + 1][Y - 1]++;
                board[X + 1][Y]++;
                board[X + 1][Y + 1]++;
                board[X][Y + 1]++;
                flasesOfStep++;
                board[X][Y] = -1000;
                flasesOfStep += Step(X, Y - 1, xCount, yCount, board, 0);
                flasesOfStep += Step(X + 1, Y - 1, xCount, yCount, board, 0);
                flasesOfStep += Step(X + 1, Y, xCount, yCount, board, 0);
                flasesOfStep += Step(X + 1, Y + 1, xCount, yCount, board, 0);
                flasesOfStep += Step(X, Y + 1, xCount, yCount, board, 0);

            }
            if (X == 0 && Y == yCount && board[X][Y] >= 10)
            {
                board[X + 1][Y]++;
                board[X + 1][Y - 1]++;
                board[X][Y - 1]++;
                flasesOfStep++;
                board[X][Y] = -1000;
                flasesOfStep += Step(X, Y - 1, xCount, yCount, board, 0);
                flasesOfStep += Step(X + 1, Y, xCount, yCount, board, 0);
                flasesOfStep += Step(X + 1, Y - 1, xCount, yCount, board, 0);
            }
            if (Y == yCount && X != 0 && X < xCount && board[X][Y] >= 10)
            {
                board[X - 1][Y]++;
                board[X - 1][Y - 1]++;
                board[X][Y - 1]++;
                board[X + 1][Y - 1]++;
                board[X + 1][Y]++;
                flasesOfStep++;
                board[X][Y] = -1000;
                flasesOfStep += Step(X - 1, Y, xCount, yCount, board, 0);
                flasesOfStep += Step(X - 1, Y - 1, xCount, yCount, board, 0);
                flasesOfStep += Step(X, Y - 1, xCount, yCount, board, 0);
                flasesOfStep += Step(X + 1, Y, xCount, yCount, board, 0);
                flasesOfStep += Step(X + 1, Y - 1, xCount, yCount, board, 0);
            }
            if (Y == yCount && X == xCount && board[X][Y] >= 10)
            {

                board[X - 1][Y]++;
                board[X - 1][Y - 1]++;
                board[X][Y - 1]++;
                flasesOfStep++;
                board[X][Y] = -1000;
                flasesOfStep += Step(X - 1, Y, xCount, yCount, board, 0);
                flasesOfStep += Step(X - 1, Y - 1, xCount, yCount, board, 0);
                flasesOfStep += Step(X, Y - 1, xCount, yCount, board, 0);
            }
            if (X == xCount && Y < yCount && Y != 0 && board[X][Y] >= 10)
            {
                board[X][Y - 1]++;
                board[X - 1][Y - 1]++;
                board[X - 1][Y]++;
                board[X - 1][Y + 1]++;
                board[X][Y + 1]++;
                flasesOfStep++;
                board[X][Y] = -1000;
                flasesOfStep += Step(X - 1, Y - 1, xCount, yCount, board, 0);
                flasesOfStep += Step(X - 1, Y, xCount, yCount, board, 0);
                flasesOfStep += Step(X - 1, Y + 1, xCount, yCount, board, 0);
                flasesOfStep += Step(X, Y - 1, xCount, yCount, board, 0);
                flasesOfStep += Step(X, Y + 1, xCount, yCount, board, 0);
            }
            if (X == xCount && Y == 0 && board[X][Y] >= 10)
            {

                board[X - 1][Y]++;
                board[X - 1][Y + 1]++;
                board[X][Y + 1]++;
                flasesOfStep++;
                board[X][Y] = -1000;
                flasesOfStep += Step(X - 1, Y, xCount, yCount, board, 0);
                flasesOfStep += Step(X - 1, Y + 1, xCount, yCount, board, 0);
                flasesOfStep += Step(X, Y + 1, xCount, yCount, board, 0);
            }
            if (Y == 0 && X != 0 && X < xCount && board[X][Y] >= 10)
            {
                board[X - 1][Y]++;
                board[X - 1][Y + 1]++;
                board[X][Y + 1]++;
                board[X + 1][Y + 1]++;
                board[X + 1][Y]++;
                flasesOfStep++;
                board[X][Y] = -1000;
                flasesOfStep += Step(X - 1, Y, xCount, yCount, board, 0);
                flasesOfStep += Step(X - 1, Y + 1, xCount, yCount, board, 0);
                flasesOfStep += Step(X, Y + 1, xCount, yCount, board, 0);
                flasesOfStep += Step(X + 1, Y, xCount, yCount, board, 0);
                flasesOfStep += Step(X + 1, Y + 1, xCount, yCount, board, 0);
            }

            return flasesOfStep;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Day 11 - Dumbo Octopus");

            List<List<int>> board = new List<List<int>>();
            List<string> oneStringLine = new List<string>();


            foreach (string line in System.IO.File.ReadLines(@"../../../DAY_11.txt"))
            {
                oneStringLine.Add(line);
            }
            for (int k = 0; k < oneStringLine.Count; k++)
            {
                List<int> oneLine = new List<int>();

                for (int n = 0; n < oneStringLine[0].Length; n++)
                {
                    char p = oneStringLine[k][n];
                    string numString = p.ToString();
                    int num = Convert.ToInt32(numString);
                    oneLine.Add(num);
                }

                board.Add(oneLine);
            }

            int lines = board.Count - 1;
            int columns = oneStringLine.Count - 1;
            int flases = 0;

            for (int times = 0; times < 100; times++)
            {
                for (int p = 0; p <= lines; p++)
                {
                    for (int m = 0; m <= columns; m++)
                    {
                        board[p][m]++;

                    }
                }
                for (int p = 0; p <= lines; p++)
                {
                    for (int m = 0; m <= columns; m++)
                    {
                        flases += Step(m, p, columns, lines, board, 0);

                    }
                }
                for (int p = 0; p <= lines; p++)
                {
                    for (int m = 0; m <= columns; m++)
                    {
                        if (board[p][m] >= 10 || board[p][m] < 0)
                        {
                            board[p][m] = 0;
                        }
                    }
                }
                for (int p = 0; p <= lines; p++)
                {
                    for (int m = 0; m <= columns; m++)
                    {
                        Console.Write(board[p][m] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                Console.WriteLine();

            }

            Console.WriteLine(flases);


        }
    }
}
