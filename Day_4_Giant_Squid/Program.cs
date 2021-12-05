using System;
using System.Collections.Generic;
using System.Linq;


namespace Day_4_Giant_Squid
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Advent of code - DAY 4 - Giant Squid");

            string bingoNums = null;
            int lineLength = 0;
            List<string> listOfLines = new List<string>();

            List<List<List<string>>> listOfBingoTables = new List<List<List<string>>>();
            List<string> bingoNumsTable = new List<string>();

            foreach (string line in System.IO.File.ReadLines(@"../../../DAY_4.txt"))
            {
                lineLength = line.Length;

                if (line.Length > 14)
                {
                    bingoNums = line;
                    for (int i = 0; i < bingoNums.Length; i++)
                    {
                        if (bingoNums.Substring(i, 1) == ",")
                        {
                            if (bingoNums.Substring(i + 1, 1) != "," && bingoNums.Length <= i + 2)
                            {
                                string oneSignNum = bingoNums.Substring(i + 1, 1);
                                bingoNumsTable.Add(oneSignNum);
                                break;
                            }
                            if (bingoNums.Substring(i + 1, 1) != "," && bingoNums.Substring(i + 2, 1) == ",")
                            {
                                string oneSignNum = bingoNums.Substring(i + 1, 1);
                                bingoNumsTable.Add(oneSignNum);
                            }
                            if (bingoNums.Substring(i + 1, 1) != "," && bingoNums.Substring(i + 2, 1) != ",")
                            {
                                string firstSign = bingoNums.Substring(i + 1, 1);
                                string secondSign = bingoNums.Substring(i + 2, 1);
                                string twoSignNum = firstSign + secondSign;
                                bingoNumsTable.Add(twoSignNum);

                            }
                        }
                        if (i == 0)
                        {
                            if (bingoNums.Substring(i, 1) != ",")
                            {
                                if (bingoNums.Substring(i + 1, 1) == ",")
                                {
                                    string oneSignNum = bingoNums.Substring(i, 1);
                                    bingoNumsTable.Add(oneSignNum);
                                }
                                if (bingoNums.Substring(i + 1, 1) != ",")
                                {
                                    string firstSign = bingoNums.Substring(i, 1);
                                    string secondSign = bingoNums.Substring(i + 1, 1);
                                    string twoSignNum = firstSign + secondSign;
                                    bingoNumsTable.Add(twoSignNum);
                                    i += 1;
                                }
                            }
                        }
                    }
                }
                if (line.Length == 0 || line.Length == 14)
                {
                    listOfLines.Add(line);
                }
            }

            for (int i = 0; i < listOfLines.Count; i++)
            {
                List<List<string>> bingoTable = new List<List<string>>();
                string lineOfList = listOfLines[i];

                if (lineOfList == "")
                {
                    for (int p = 1; p < 6; p++)
                    {
                        bingoTable.Add(listOfLines[p + i].Split().Where(x => (x != "")).ToList());

                    }
                    listOfBingoTables.Add(bingoTable);
                }
            }

            bool won = false;
            int wonIndex = -1;
            string calledNum = "";

            for (int i = 0; i < bingoNumsTable.Count; i++)
            {
                string checkingNum = bingoNumsTable[i];

                foreach (List<List<string>> tableList in listOfBingoTables)
                {
                    foreach (List<string> row in tableList)
                    {
                        for (int x = 0; x < 5; x++)
                        {
                            if (row[x] == checkingNum)
                            {
                                row[x] = "XX";
                            }
                        }
                    }
                }
                int n = 0;
                foreach (List<List<string>> tableList in listOfBingoTables)
                {
                    for (int x = 0; x < 5; x++)
                    {
                        if (tableList[x][0] == "XX" && tableList[x][1] == "XX" && tableList[x][2] == "XX" && tableList[x][3] == "XX" && tableList[x][4] == "XX")
                        {
                            won = true;
                            wonIndex = n;
                            calledNum = checkingNum;
                            break;
                        }
                        if (tableList[0][x] == "XX" && tableList[1][x] == "XX" && tableList[2][x] == "XX" && tableList[3][x] == "XX" && tableList[4][x] == "XX")
                        {
                            won = true;
                            wonIndex = n;
                            calledNum = checkingNum;
                            break;
                        }
                    }
                    if (won)
                    {
                        break;
                    }
                    n++;
                }
                if (won)
                    break;
            }
            var wonBingoTable = listOfBingoTables[wonIndex];
            List<int> arrayOfLeftNum = new List<int>();
            for (int k = 0; k < 5; k++)
            {
                for (int t = 0; t < 5; t++)
                {
                    if (wonBingoTable[k][t] != "XX")
                    {
                        int leftNums = Convert.ToInt32(wonBingoTable[k][t]);
                        arrayOfLeftNum.Add(leftNums);
                    }
                }
            }
            int epsilon = arrayOfLeftNum.Sum(item => item);
            int calledNumber = Convert.ToInt32(calledNum);
            int finalAnswer = epsilon * calledNumber;
            Console.WriteLine("Winning Bingo Board is : " + wonIndex);
            Console.WriteLine("Answer is: " + finalAnswer);
        }
    }
}