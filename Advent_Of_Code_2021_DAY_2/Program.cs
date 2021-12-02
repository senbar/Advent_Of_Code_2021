using System;

namespace Advent_Of_Code_2021_DAY_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advent of code - Day 2");
            int horiozontal = 0;
            int depth = 0;

            foreach (string line in System.IO.File.ReadLines(@"../../../DAY_2.txt"))
            {

                string direction = line.Substring(0, line.IndexOf(" "));
                string number = line.Substring(line.IndexOf(" ") + 1);
                int num = Convert.ToInt32(number);
               
                if (direction == "forward")
                {
                    horiozontal = horiozontal + num;
                }
                if (direction == "up")
                {
                    depth = depth - num;
                }
                if (direction == "down")
                {
                    depth = depth + num;
                }
            }

            Console.WriteLine("Horizontal position: " + horiozontal);
            Console.WriteLine("Depth: " + depth);
            Console.WriteLine("Answer: " + horiozontal + " * " + depth + " = " + (horiozontal * depth));
        }
    }
}
