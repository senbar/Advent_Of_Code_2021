using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent_Of_Code_2021_DAY_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advent of code - Day 3");

            List<int> listOfZeros = new List<int>();
            List<int> listOfOnes = new List<int>();
            List<int> finalListGamma = new List<int>();
            List<int> finalListEpsilon = new List<int>();

            int lineLength = 0;


            foreach (string line in System.IO.File.ReadLines(@"../../../DAY_3.txt"))
            {
                lineLength = line.Length;

                if (listOfOnes.Count == 0 && listOfZeros.Count == 0)
                {
                    for (int i = 0; i < lineLength; i++)
                    {
                        listOfOnes.Add(0);
                        listOfZeros.Add(0);
                        finalListGamma.Add(0);
                        finalListEpsilon.Add(0);
                    }
                }

                for (int i = 0; i < lineLength; i++)
                {
                    string value = line.Substring(i, 1);

                    if (value == "0")
                    {
                        listOfZeros[i] = listOfZeros[i] + 1;
                    }
                    else
                    {
                        listOfOnes[i] = listOfOnes[i] + 1;
                    }
                }
            }

            for (int i = 0; i < lineLength; i++)
            {
                if (listOfOnes[i] > listOfZeros[i])
                {
                    finalListGamma[i] = 1;
                }
                else
                {
                    finalListGamma[i] = 0;
                }
            }

            for (int i = 0; i < lineLength; i++)
            {
                if (finalListGamma[i] == 1)
                {
                    finalListEpsilon[i] = 0;
                }
                if (finalListGamma[i] == 0)
                {
                    finalListEpsilon[i] = 1;
                }
            }

            List<int> sum = new List<int>();

            for (int i = 0; i < lineLength; i++)
            {
                if (finalListGamma[i] == 1)
                {
                    int partOfSum = (int)Math.Pow(2, (lineLength-i-1));
                    sum.Add(partOfSum);
                }
            }

            double gamma = sum.Sum(item => item);

            List<int> sumE = new List<int>();

            for (int i = 0; i < lineLength; i++)
            {
                if (finalListEpsilon[i] == 1)
                {
                    int partOfSum = (int)Math.Pow(2, (lineLength-i-1));
                    sumE.Add(partOfSum);
                }
            }

            double epsilon = sumE.Sum(item => item);

            Console.WriteLine("The ansewer is: " + gamma + " * " + epsilon + " = " + (gamma * epsilon));
        }
    }
}
