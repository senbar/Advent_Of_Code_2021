using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_13_Transparent_Origami
{
    class Program
    {
        static void Xfolding(int X, int maxX, List<List<char>> board)
        {
            for (int k = 0; k < board.Count; k++)
            {
                for (int i = (X + 1); i < maxX; i++)
                {
                    if (board[k][i] == '#')
                    {
                        int foldedIndex = X - (i - X);
                        board[k][foldedIndex] = '#';
                    }
                }
                board[k] = board[k].Take(X).ToList();
            }
        }
        static void Yfolding(int Y, int maxY, ref List<List<char>> board)
        {
            for (int i = 0; i < board[0].Count; i++)
            {
                for (int k = (Y + 1); k < maxY; k++)
                {
                    if (board[k][i] == '#')
                    {
                        int foldedIndex = Y - (k - Y);
                        board[foldedIndex][i] = '#';
                    }
                }
            }
            board = board.Take(Y).ToList();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Day 13 - Transparent Origami");

            List<string> dots = new List<string>();
            List<string> folding = new List<string>();
            List<int> X = new List<int>();
            List<int> Y = new List<int>();
            List<int> coordinates = new List<int>();
            List<List<char>> board = new List<List<char>>();
            List<string> foldingList = new List<string>();
            

            foreach (string line in System.IO.File.ReadLines(@"../../../DAY_13.txt"))
            {
                dots.Add(line);
            }
            foreach (string line in System.IO.File.ReadLines(@"../../../DAY_13_folding.txt"))
            {
                folding.Add(line);
            }
            foreach (string line in folding)
            {
                string foldingXYandNum = line.Substring(11);
                foldingList.Add(foldingXYandNum);
            }

            // spliting string into 2 
            int numOfDots = dots.Count();

            for (int i = 0; i < numOfDots; i++)
            {
                coordinates.AddRange(dots[i].Split(',').Select(x => Convert.ToInt32(x)).ToList());
            }

            for (int i = 0; i < coordinates.Count; i = i + 2)
            {
                X.Add(coordinates[i]);
            }

            for (int i = 1; i < coordinates.Count; i = i + 2)
            {
                Y.Add(coordinates[i]);
            }

            int maxX = X.Max();
            int maxY = Y.Max();

            // board full of "."
            for (int i = 0; i <= maxY; i++)
            {
                List<char> XList = new List<char>();
                XList = Enumerable.Repeat('.', maxX + 1).ToList();
                board.Add(XList);
            }
            // board with added hashes (with coordinates X and Y)
            for (int i = 0; i < numOfDots; i++)
            {
                int y = Y[i];
                int x = X[i];
                board[y][x] = '#';
            }

            // folding coordinate X or Y
            foreach (string line in foldingList)
            {
                if(line.StartsWith("x="))
                {
                    string fX = line.Substring(2);
                    int foldX = Convert.ToInt32(fX);
                    int max = board[0].Count;
                    Xfolding(foldX, max, board);
                }
                if(line.StartsWith("y="))
                {
                    string fY = line.Substring(2);
                    int foldY = Convert.ToInt32(fY);
                    int max = board.Count;
                    Yfolding(foldY, max, ref board);
                }
            }

            //count hashes at the end
            int howManyHashes = 0;

            for (int k = 0; k < board.Count; k++)
            {
                for (int i = 0; i < board[0].Count; i++)
                {
                    if (board[k][i] == '#')
                    {
                        howManyHashes = howManyHashes + 1;
                    }
                }
            }
            // printing
            for (int k = 0; k < board.Count ; k++)
            {
                Console.WriteLine();
                for (int i = 0; i < board[k].Count; i++)
                {
                    if (board[k][i] == '#')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(board[k][i]);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(board[k][i]);
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("Answer:   " + howManyHashes + "  dots are visible");
        }
    }
}

