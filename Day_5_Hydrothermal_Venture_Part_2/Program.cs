using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_5_Hydrothermal_Venture
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Day 5 - Hydrothermal Venture! - Part 2");

            List<List<string>> lines = new List<List<string>>();

            List<int> X1 = new List<int>();
            List<int> Y1 = new List<int>();
            List<int> X2 = new List<int>();
            List<int> Y2 = new List<int>();

            foreach (string line in System.IO.File.ReadLines(@"../../../DAY_5.txt"))
            {
                lines.Add(line.Split().Where(x => (x != " -> ")).ToList());
            }

            int numOfLines = lines.Count();

            for (int i = 0; i < numOfLines; i++)
            {
                lines[i].RemoveAt(1);
                string[] startingPoint = lines[i][1].Split(',');
                int firstX = Convert.ToInt32(startingPoint[0]);
                int firstY = Convert.ToInt32(startingPoint[1]);
                X1.Add(firstX);
                Y1.Add(firstY);
                string[] finishPoint = lines[i][0].Split(',');
                int secondX = Convert.ToInt32(finishPoint[0]);
                int secondY = Convert.ToInt32(finishPoint[1]);
                X2.Add(secondX);
                Y2.Add(secondY);
            }

            // below:  how may lines and rows should have 2D array 

            int maxX = 0;
            int maxY = 0;

            if (X1.Max() >= X2.Max())
            {
                maxX = X1.Max();
            }
            if (X1.Max() < X2.Max())
            {
                maxX = X2.Max();
            }
            if (Y1.Max() >= Y2.Max())
            {
                maxY = Y1.Max();
            }
            if (Y1.Max() < Y2.Max())
            {
                maxY = Y2.Max();
            }

            int[,] array2D;

            if (maxX >= maxY)
            {
                array2D = new int[maxX + 1, maxX + 1];
            }
            else
            {
                array2D = new int[maxY + 1, maxY + 1];
            }

            for (int z = 0; z < numOfLines; z++)
            {
                if (X1[z] == X2[z])
                {
                    array2D[X1[z], Y1[z]] += 1;

                    if (Y1[z] > Y2[z])
                    {
                        int between = Y1[z] - Y2[z];
                        for (int p = 1; p < between; p++)
                        {
                            array2D[X1[z], (Y1[z] - p)] += 1;
                        }
                    }

                    if (Y1[z] < Y2[z])
                    {
                        int between = Y2[z] - Y1[z];
                        for (int p = 1; p < between; p++)
                        {
                            array2D[X1[z], (Y1[z] + p)] += 1;
                        }
                    }

                    array2D[X2[z], Y2[z]] += 1;
                }
                if (Y1[z] == Y2[z])
                {
                    array2D[X1[z], Y1[z]] += 1;

                    if (X1[z] > X2[z])
                    {
                        int between = X1[z] - X2[z];
                        for (int p = 1; p < between; p++)
                        {
                            array2D[(X1[z] - p), Y1[z]] += 1;
                        }
                    }

                    if (X1[z] < X2[z])
                    {
                        int between = X2[z] - X1[z];
                        for (int p = 1; p < between; p++)
                        {
                            array2D[(X1[z] + p), Y1[z]] += 1;
                        }
                    }

                    array2D[X2[z], Y2[z]] += 1;
                }
                if (Math.Abs(Y1[z] - Y2[z]) == Math.Abs(X1[z] - X2[z]))
                {
                    
                    array2D[X1[z], Y1[z]] += 1;

                    if (X1[z] > X2[z] && Y1[z] > Y2[z])
                    {
                        int between = X1[z] - X2[z];
                        for (int p = 1; p < between; p++)
                        {
                            array2D[(X1[z] - p), (Y1[z] - p)] += 1;
                        }
                    }

                    if (X1[z] < X2[z] && Y1[z] < Y2[z])
                    {
                        int between = X2[z] - X1[z];
                        for (int p = 1; p < between; p++)
                        {
                            array2D[(X1[z] + p), (Y1[z] + p)] += 1;
                        }
                    }

                    if (X1[z] > X2[z] && Y1[z] < Y2[z])
                    {
                        int between = X1[z] - X2[z];
                        for (int p = 1; p < between; p++)
                        {
                            array2D[(X1[z] - p), (Y1[z] + p)] += 1;
                        }
                    }

                    if (X1[z] < X2[z] && Y1[z] > Y2[z])
                    {
                        int between = X2[z] - X1[z];
                        for (int p = 1; p < between; p++)
                        {
                            array2D[(X1[z] + p), (Y1[z] - p)] += 1;
                        }
                    }

                    array2D[X2[z], Y2[z]] += 1;
                }
            }

            int numberOfPointsUpToTwo = 0;

            foreach (var point in array2D)
            {
                if (point >= 2)
                {
                    numberOfPointsUpToTwo++;
                }
            }

            Console.WriteLine("Answer is: " + numberOfPointsUpToTwo);
        }
    }
}



