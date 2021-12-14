using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_9_Smoke_Basin
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Day 9 - Smoke Basis");
            List<string> lines = new List<string>();

           
            List<List<int>> everyLinesInt = new List<List<int>>();

            foreach (string line in System.IO.File.ReadLines(@"../../../DAY_9.txt"))
            {
                lines.Add(line);

            }
            int numOfLines = lines.Count();

            for (int i = 0; i < numOfLines; i++)
            {
                List<int> linesInt = new List<int>();
                foreach (char num in lines[i])
                {
                    linesInt.Add(Int32.Parse(num.ToString()));
                }
                everyLinesInt.Add(linesInt);
            }

            int numOfNums = everyLinesInt[0].Count();
            int answer = 0;

            for (int k = 0; k < numOfLines; k++)
            {
                if (k == 0)
                {
                    for (int m = 0; m < numOfNums; m++)
                    {
                        if (m == 0)
                        {
                            if (everyLinesInt[k][m] < everyLinesInt[k][m + 1] && everyLinesInt[k][m] < everyLinesInt[k + 1][m])
                            {
                                answer = answer + everyLinesInt[k][m] + 1;
                            }
                        }
                        if (m == numOfNums - 1)
                        {
                            if (everyLinesInt[k][numOfNums - 1] < everyLinesInt[k][numOfNums - 2] && everyLinesInt[k][numOfNums - 1] < everyLinesInt[k + 1][numOfNums - 1])
                            {
                                answer = answer + everyLinesInt[k][m] + 1;
                            }
                        }
                        if (m != 0 && m != numOfNums - 1)
                        {
                            if (everyLinesInt[k][m] < everyLinesInt[k][m + 1] && everyLinesInt[k][m] < everyLinesInt[k][m - 1] && everyLinesInt[k][m] < everyLinesInt[k + 1][m])
                            {
                                answer = answer + everyLinesInt[k][m] + 1;
                            }
                        }
                    }
                }
                if (k == numOfLines-1)
                {
                    for (int m = 0; m < numOfNums; m++)
                    {
                        if (m == 0)
                        {
                            if (everyLinesInt[k][m] < everyLinesInt[k][m + 1] && everyLinesInt[k][m] < everyLinesInt[k - 1][m])
                            {
                                answer = answer + everyLinesInt[k][m] + 1;
                            }
                        }
                        if (m == numOfNums - 1)
                        {
                            if (everyLinesInt[k][numOfNums - 1] < everyLinesInt[k][numOfNums - 2] && everyLinesInt[k][numOfNums - 1] < everyLinesInt[k - 1][numOfNums - 1])
                            {
                                answer = answer + everyLinesInt[k][m] + 1;
                            }
                        }
                        if (m != 0 && m != numOfNums - 1)
                        {
                            if (everyLinesInt[k][m] < everyLinesInt[k][m + 1] && everyLinesInt[k][m] < everyLinesInt[k][m - 1] && everyLinesInt[k][m] < everyLinesInt[k - 1][m])
                            {
                                answer = answer + everyLinesInt[k][m] + 1;
                            }
                        }
                    }
                }
                if (k != 0 && k!= numOfLines-1)
                {
                    for (int m = 0; m < numOfNums; m++)
                    {
                        if (m == 0)
                        {
                            if (everyLinesInt[k][m] < everyLinesInt[k][m + 1] && everyLinesInt[k][m] < everyLinesInt[k - 1][m] && everyLinesInt[k][m] < everyLinesInt[k + 1][m])
                            {
                                answer = answer + everyLinesInt[k][m] + 1;
                            }
                        }
                        if (m == numOfNums - 1)
                        {
                            if (everyLinesInt[k][numOfNums - 1] < everyLinesInt[k][numOfNums - 2] && everyLinesInt[k][numOfNums - 1] < everyLinesInt[k - 1][numOfNums - 1] && everyLinesInt[k][numOfNums - 1] < everyLinesInt[k + 1][numOfNums - 1])
                            {
                                answer = answer + everyLinesInt[k][m] + 1;
                            }
                        }
                        if (m != 0 && m != numOfNums-1)
                        {
                            if (everyLinesInt[k][m] < everyLinesInt[k][m + 1] && everyLinesInt[k][m] < everyLinesInt[k][m - 1] && everyLinesInt[k][m] < everyLinesInt[k - 1][m] && everyLinesInt[k][m] < everyLinesInt[k + 1][m])
                            {
                                answer = answer + everyLinesInt[k][m] + 1;
                            }
                        }
                    }

                }
            }

            Console.WriteLine("Answer is :  " + answer);
        }

    }
}

