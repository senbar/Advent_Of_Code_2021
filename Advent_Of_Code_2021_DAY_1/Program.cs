using System;

namespace Advent_Of_Code_2021_DAY_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advent of Code - DAY 1");

            int increase = 0;
            int? previousNumber = null;

            foreach (string line in System.IO.File.ReadLines(@"../../../DAY_1.txt"))
            {
                int num = Convert.ToInt32(line);

                if (num > previousNumber && previousNumber!=null)
                {
                    increase++;
                }

                previousNumber = num;

            }
     
            Console.WriteLine("Answer is:  " + increase);


        }
    }
}
