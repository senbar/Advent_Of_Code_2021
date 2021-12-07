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

            double howManyZeros = 0;
            double howManyOnes = 0;
            double howManyTwos = 0;
            double howManyThrees = 0;
            double howManyFours = 0;
            double howManyFives = 0;
            double howManySixs = 0;
            double howManySevens = 0;
            double howManyEights = 0;

            for (int k = 0; k < fishes.Count; k++)
            {
                if (fishes[k] == 0)
                {
                    howManyZeros++;
                }
                if (fishes[k] == 1)
                {
                    howManyOnes++;
                }
                if (fishes[k] == 2)
                {
                    howManyTwos++;
                }
                if (fishes[k] == 3)
                {
                    howManyThrees++;
                }
                if (fishes[k] == 4)
                {
                    howManyFours++;
                }
                if (fishes[k] == 5)
                {
                    howManyFives++;
                }
                if (fishes[k] == 6)
                {
                    howManySixs++;
                }
                if (fishes[k] == 7)
                {
                    howManySevens++;
                }
                if (fishes[k] == 8)
                {
                    howManyEights++;
                }
            }
            double howManyFishesAtTheEnd = 0;
            for (int z = 1; z < 257; z++)
            {
                double howManyZerosNow = howManyOnes;
                double howManyOnesNow = howManyTwos;
                double howManyTwosNow = howManyThrees;
                double howManyThreesNow = howManyFours;
                double howManyFoursNow = howManyFives;
                double howManyFivesNow = howManySixs;
                double howManySixsNow = howManySevens + howManyZeros;
                double howManySevensNow = howManyEights;
                double howManyEightsNow = howManyZeros;

                howManyZeros = howManyZerosNow;
                howManyOnes = howManyOnesNow;
                howManyTwos = howManyTwosNow;
                howManyThrees = howManyThreesNow;
                howManyFours = howManyFoursNow;
                howManyFives = howManyFivesNow;
                howManySixs = howManySixsNow;
                howManySevens = howManySevensNow;
                howManyEights = howManyEightsNow;

                howManyFishesAtTheEnd = checked(howManyZeros + howManyOnes + howManyTwos + howManyThrees + howManyFours + howManyFives + howManySixs + howManySevens + howManyEights);
            }
            
            Console.WriteLine("Answer:   " + howManyFishesAtTheEnd + "  fishes");
        }
    }
}
