using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_7_The_Treachery_of_Whales_Part_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Day 7 - The trachery of whales - Part 2");
            List<string> linesOfCrabs = new List<string>();

            List<int> crabs = new List<int>();

            foreach (string line in System.IO.File.ReadLines(@"../../../DAY_7.txt"))
            {
                linesOfCrabs.Add(line);
            }

            int numOfCrabsLines = linesOfCrabs.Count();

            for (int i = 0; i < numOfCrabsLines; i++)
            {
                crabs.AddRange(linesOfCrabs[i].Split(',').Select(x => Convert.ToInt32(x)).ToList());
            }

            int minCrab = crabs.Min();
            int maxCrab = crabs.Max();

            List<int> fuel = new List<int>();

            for (int i = minCrab; i <= maxCrab; i++)
            {
                int fuelOfOne = 0;

                foreach (var crab in crabs)
                {
                    int oneCrabFuel = Math.Abs(crab - i);
                    int fuelOfOneCrab = 0;

                    for (int k = 0; k <= oneCrabFuel; k++)
                    {
                        fuelOfOneCrab = fuelOfOneCrab + (oneCrabFuel - k);
                    }

                    fuelOfOne = fuelOfOne + fuelOfOneCrab;
                }

                fuel.Add(fuelOfOne);
            }

            int answer = fuel.Min();
            Console.WriteLine("Answer:  " + answer);
        }
    }
}
