using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_13_Transparent_Origami
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Day 13 - Transparent Origami");

            List<string> dots = new List<string>();
            List<int> X = new List<int>();
            List<int> Y = new List<int>();
            List<int> coordinates = new List<int>();
            List<List<char>> board = new List<List<char>>();

            foreach (string line in System.IO.File.ReadLines(@"../../../DAY_13.txt"))
            {
                dots.Add(line);
            }

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

            // folding int coordinate X
            int foldingX = 655;
            int howManyToTake = foldingX;

            for (int k = 0; k < board.Count; k++)
            { 
                for (int i = (foldingX + 1); i <= maxX; i++)
                {
                    if (board[k][i] == '#')
                    {
                        int foldedIndex = foldingX - (i - foldingX);
                        board[k][foldedIndex] = '#';
                    }
                }
            }
            
            int howManyHashes = 0;

            for (int i = 0; i < board.Count; i++)
            {
                for (int k = 0; k < foldingX ; k++)
                {       
                    if (board[i][k] == '#')
                    {
                        howManyHashes = howManyHashes + 1;
                    }
                }
            }

            Console.WriteLine("Answer:   " + howManyHashes + "  dots are visible");
        }
    }
}
