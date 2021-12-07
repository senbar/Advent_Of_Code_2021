using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_6_Lanternfish
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Day 6 - Lanternfish ");
            List<string> linesOfFishes = new List<string>();

            List<int> fishes = new List<int>();

            foreach (string line in System.IO.File.ReadLines(@"../../../DAY_6.txt"))
            {
                linesOfFishes.Add(line);
            }

            int numOfFishesLines = linesOfFishes.Count();

            for (int i = 0; i < numOfFishesLines; i++)
            {
                fishes.AddRange(linesOfFishes[i].Split(',').Select(x => Convert.ToInt32(x)).ToList());    
            }

            for (int z = 1; z < 81; z++)
            {
                int fishesCount = fishes.Count();

                for (int k = 0; k < fishesCount; k++)
                {
                    fishes[k] = fishes[k] - 1;
                    if(fishes[k] == -1)
                    {
                        fishes.Add(8);
                        fishes[k] = 6;
                    }
                }   
            }
            int howManyFishesAtTheEnd = fishes.Count();
            Console.WriteLine("Answer:   " + howManyFishesAtTheEnd + "  fishes");
        }
    }
}
