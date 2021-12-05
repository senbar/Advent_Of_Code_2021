using System;
using System.Collections.Generic;

namespace Advent_Of_Code_2021_DAY_1_PART_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advent of Code - DAY 1 - PART 2");

            int numberOfLine = 0;
            int increase = 0;

            List<int> previousList = new List<int>();
            int num = 0;

            foreach (string line in System.IO.File.ReadLines(@"../../../DAY_1.txt"))
            {
                numberOfLine++;
                num = Convert.ToInt32(line);

                if (numberOfLine < 4)
                {
                    previousList.Add(num);

                }

                else
                {
                        
                    if (previousList.Count < (previousList.Count - previousList[0] + num))
                    {
                        increase++;
                    }

                    previousList.RemoveAt(0);
                    previousList.Add(num);
                }

            }

            Console.WriteLine("Answer is:  " + increase);
        }
    }
}
