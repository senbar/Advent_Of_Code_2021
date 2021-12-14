using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_9_Smoke_Basin_Part_2
{
    class Program
    {
        static int CheckAround(int X, int Y, List<List<string>> table)
        {
            var res = 0;
            table[X][Y] = "X";

            if (table[X - 1][Y] != "9" && table[X - 1][Y] != "X")
            {
                res += CheckAround(X - 1, Y, table);
            }
            if (table[X + 1][Y] != "9" && table[X + 1][Y] != "X")
            {
                res += CheckAround(X + 1, Y, table);
            }
            if (table[X][Y - 1] != "9" && table[X][Y - 1] != "X")
            {
                res += CheckAround(X, Y - 1, table);
            }
            if (table[X][Y + 1] != "9" && table[X][Y + 1] != "X")
            {
                res += CheckAround(X, Y + 1, table);
            }
            return res += 1;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Day 9 - Smoke Basis - Part 2");
            List<string> lines = new List<string>();
            List<List<string>> everyLines = new List<List<string>>();
            int numOfNums = 0;

            foreach (string line in System.IO.File.ReadLines(@"../../../DAY_9.txt"))
            {
                lines.Add(line);
                numOfNums = line.Length;

            }
            int numOfLines = lines.Count();

            for (int i = 0; i < numOfLines; i++)
            {
                if (i == 0)
                {
                    List<string> firstLine = new List<string>();
                    for (int k = 0; k < numOfNums + 2; k++)
                    {
                        firstLine.Add("9");
                    }
                    everyLines.Add(firstLine);
                }

                List<string> line = new List<string>();
                if (true)
                {
                    line.Add("9");
                    foreach (char num in lines[i])
                    {
                        line.Add(num.ToString());
                    }
                    line.Add("9");
                }

                everyLines.Add(line);
                if (i == numOfLines - 1)
                {
                    List<string> lastLine = new List<string>();
                    for (int k = 0; k < numOfNums + 2; k++)
                    {
                        lastLine.Add("9");
                    }
                    everyLines.Add(lastLine);
                }
            }

            numOfLines = everyLines.Count();
            numOfNums = everyLines[0].Count();

            List<int> basins = new List<int>();

            for (int k = 0; k < numOfLines; k++)
            {
                for (int m = 0; m < numOfNums; m++)
                {
                    if (everyLines[k][m] == "9")
                    {
                        continue;
                    }
                    if (everyLines[k][m] == "X")
                    {
                        continue;
                    }

                    int basin = CheckAround(k, m, everyLines);
                    basins.Add(basin);
                    Console.WriteLine(basin);
                }

            }

            var top = basins.OrderBy(x => x).TakeLast(3).ToList();
            Console.Write("answer:     ");
            Console.WriteLine( top[0]*top[1]*top[2]);


        }

    }
}

