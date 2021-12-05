using System;
using System.Collections.Generic;
using System.Linq;

namespace DAY_3_Binary_Diagnostic_PART_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advent of code - Day 3");

            int zeros = 0;
            int ones = 0;

            List<string> listOfLines = new List<string>();

            int lineLength = 0;
            foreach (string line in System.IO.File.ReadLines(@"../../../DAY_3.txt"))
            {
                lineLength = line.Length;
            }

            for (int i = 0; i < lineLength; i++)
            {
                if (i == 0)
                {
                    foreach (string line in System.IO.File.ReadLines(@"../../../DAY_3.txt"))
                    {
                        listOfLines.Add(line);
                        string value = line.Substring(i, 1);

                        if (value == "0")
                        {
                            zeros += 1;
                        }
                        else
                        {
                            ones += 1;
                        }
                    }
                }
                int num = listOfLines.Count;
                if (i > 0)
                {
                    foreach (string oneLine in listOfLines)
                    {
                        string value = oneLine.Substring(i, 1);
                        if (value == "0")
                        {
                            zeros += 1;
                        }
                        else
                        {
                            ones += 1;
                        }
                    }
                }
                if (zeros <= ones && listOfLines.Count > 1)
                {
                    for (int n = 0; n < num; n++)
                    {
                        string nLine = listOfLines[n];
                        string value = nLine.Substring(i, 1);
                        if (value == "0")
                        {
                            listOfLines.Remove(nLine);
                            n = n - 1;
                            num = num - 1;
                        }
                    }
                }
                if (zeros > ones && listOfLines.Count > 1)
                {
                    for (int n = 0; n < num; n++)
                    {
                        string nLine = listOfLines[n];
                        string value = nLine.Substring(i, 1);
                        if (value == "1")
                        {
                            listOfLines.Remove(nLine);
                            n = n - 1;
                            num = num - 1;
                        }
                    }
                }
                ones = 0;
                zeros = 0;
            }

            string oxygen = listOfLines[0];
            List<int> sumOxygen = new List<int>();
            for (int i = 0; i < lineLength; i++)
            {
                if (oxygen.Substring(i, 1) == "1")
                {
                    int partOfSum = (int)Math.Pow(2, (lineLength - i - 1));
                    sumOxygen.Add(partOfSum);
                }
            }
            int ox = sumOxygen.Sum(item => item);

            Console.WriteLine("First parameter - oxygen generator rating: " + oxygen + " in decimal: " + ox);
            listOfLines.Clear();

            foreach (string line in System.IO.File.ReadLines(@"../../../DAY_3.txt"))
            {
                lineLength = line.Length;
            }
            for (int a = 0; a < lineLength; a++)
            {
                if (a == 0)
                {
                    foreach (string line in System.IO.File.ReadLines(@"../../../DAY_3.txt"))
                    {
                        listOfLines.Add(line);
                        string value = line.Substring(a, 1);

                        if (value == "0")
                        {
                            zeros += 1;
                        }
                        else
                        {
                            ones += 1;
                        }
                    }
                }
                if (a > 0)
                {
                    foreach (string oneLine in listOfLines)
                    {
                        string value = oneLine.Substring(a, 1);
                        if (value == "0")
                        {
                            zeros += 1;
                        }
                        else
                        {
                            ones += 1;
                        }
                    }
                }
                int num = listOfLines.Count;
                if (ones < zeros && listOfLines.Count > 1)
                {
                    for (int n = 0; n < num; n++)
                    {
                        string nLine = listOfLines[n];
                        string value = nLine.Substring(a, 1);
                        if (value == "0")
                        {
                            listOfLines.Remove(nLine);
                            n = n - 1;
                            num = num - 1;
                        }
                    }
                }
                if (ones >= zeros && listOfLines.Count > 1)
                {
                    for (int n = 0; n < num; n++)
                    {
                        string nLine = listOfLines[n];
                        string value = nLine.Substring(a, 1);
                        if (value == "1")
                        {
                            listOfLines.Remove(nLine);
                            n = n - 1;
                            num = num - 1;
                        }
                    }
                }
                ones = 0;
                zeros = 0;
            }

            string co = listOfLines[0];
            List<int> sumCo = new List<int>();
            for (int i = 0; i < lineLength; i++)
            {
                if (co.Substring(i, 1) == "1")
                {
                    int partOfSum = (int)Math.Pow(2, (lineLength - i - 1));
                    sumCo.Add(partOfSum);
                }
            }

            int cox = sumCo.Sum(item => item);
            Console.WriteLine("First parameter - CO2 scrubber rating: " + co + " in decimal: " + cox);
            Console.WriteLine("Answer: " + ox + " * " + cox + " = " + (ox * cox));
        }
    }
}